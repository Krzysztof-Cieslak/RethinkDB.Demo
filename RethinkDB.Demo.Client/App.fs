namespace RethinkDB.Demo.Client

open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript
open Helpers
open System.Collections.Generic
open System

[<ReflectedDefinition>]
module App =

    let bootstrapReact () =
        let m = JS.require<Mui.mui> "material-ui"
        let tm = m.Styles.ThemeManager()

        do Message.register(m, tm)
        do MessageList.register(m, tm)
        do MessageForm.register(m, tm)
        do Chat.register(m, tm)
        do React.getComponent "Chat"
            |> Globals.createElement
            |> fun e ->  Globals.render(e, Globals.document.getElementById("example"))
            |> ignore

    let registerWebSocket () =
        let ws = Globals.WebSocket.Create "ws://localhost:8083/websocket"
        ws.addEventListener_message(fun e ->
            let e' = e |> unbox<MessageEvent>
            createEmpty<PostalEnvelope> ()
            |> fun n ->
                n.topic <- "message.recived"
                n.data <- e'.data.ToString()
                          |> Globals.JSON.parse
                          |> unbox<Message.MessageProps>
                          |> fun d -> {d with Date = DateTime.Parse(d.Date |> unbox<string>)}
                n
            |> Globals.postal.publish
            |> ignore :> obj)

        let options = createEmpty<PostalSubscriptionDefinition>()
                      |> fun n -> n.topic <- "message.new"
                                  n.callback <- Func<_,_,_>(fun n msg ->
                                      msg.data
                                      |> unbox<Message.MessageProps>
                                      |> fun a -> a |> Globals.JSON.stringify |> ws.send
                                      |> ignore :> obj)
                                  n
        Globals.postal.subscribe(options)  |> ignore

    let app () =
        do bootstrapReact ()
        do registerWebSocket ()

        ()
