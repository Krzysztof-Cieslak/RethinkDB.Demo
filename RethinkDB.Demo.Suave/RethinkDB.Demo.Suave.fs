namespace RethinkDB.Demo

open Suave
open Suave.Types
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Successful
open Suave.Http.Files
open Suave.Http.RequestErrors
open Suave.Logging
open Suave.Web
open Suave.Utils
open System
open System.Net
open Suave.Sockets
open Suave.Sockets.Control
open Suave.WebSocket

open RethinkDb
open RethinkDb.Newtonsoft.Configuration
open Newtonsoft.Json

open System.Collections.Generic

module RethinkDB =
    type Message = {
        id: string
        date: string
        nick: string
        message : string
      }

    let connection () =
        let connectionFactory = ConfigurationAssembler.CreateConnectionFactory("example");
        connectionFactory.Get()

    let registerBroadcaster handler = async {
        let conn = connection ()
        Query.Db("test").Table("Messages").Changes()
        |> conn.StreamChangesAsync
        |> handler }

    let saveMessage (msg : Message) =
        let conn = connection ()
        Query.Db("test").Table<Message>("Messages").Insert( msg )
        |> conn.Run
        |> ignore


module Suave =
    let private clients = List()

    type MessageDto = {Date : System.DateTime; Text : string; Author : string }

    let echo (webSocket : WebSocket) =
        fun cx ->
            clients.Add webSocket
            socket {
                let loop = ref true
                while !loop do
                    let! msg = webSocket.read()
                    match msg with
                    | (Text, data, true) ->

                        data
                        |> UTF8.toString
                        |> fun n -> JsonConvert.DeserializeObject<MessageDto>(n)
                        |> fun n -> {RethinkDB.id = System.Guid.NewGuid().ToString(); RethinkDB.message = n.Text; RethinkDB.date = n.Date.ToString(); RethinkDB.nick = n.Author}
                        |> RethinkDB.saveMessage
                    | (Ping, _, _) -> do! webSocket.send Pong [||] true
                    | (Close, _, _) ->
                        do! webSocket.send Close [||] true
                        clients.Remove webSocket |> ignore
                        loop := false
                    | _ -> ()
                }

    let sendAll msg =
        let msg' = JsonConvert.SerializeObject msg |> UTF8.bytes
        clients |> Seq.iter (fun w ->  w.send Text msg' true |> Async.Ignore |> Async.Start)
        ()

    let app : WebPart =
        choose [ path "/websocket" >>= handShake echo
                 GET >>= choose [ path "/" >>= file "index.html"
                                  browseHome ]
                 NOT_FOUND "Found no handlers." ]

    let rec private handler (enumerator : IAsyncEnumerator<DmlResponseChange<_>>) =
        enumerator.MoveNext().Wait()
        enumerator.Current.NewValue
        |> fun (n : RethinkDB.Message) ->
            {Date = DateTime.Parse n.date; Text = n.message; Author = n.nick }
        |> sendAll
        handler enumerator
        ()

    [<EntryPoint>]
    let main _ =
        RethinkDB.registerBroadcaster handler |> Async.Start
        startWebServer { defaultConfig with logger = Loggers.ConsoleWindowLogger LogLevel.Verbose} app
        0
