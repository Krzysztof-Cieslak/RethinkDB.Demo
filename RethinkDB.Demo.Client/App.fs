namespace RethinkDB.Demo.Client

open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript
open Helpers
open System.Collections.Generic
open System

open SignalRProvider
open SignalRProvider.Types
open SignalRProvider.Hubs

type ChatMessage = ``RethinkDB!Demo!Server!ChatMessage``

[<ReflectedDefinition>]
module App =
    let signalR = Globals.Dollar.signalR

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

    let bootstrapSignalR () =
        signalR.hub.url <- "http://localhost:81/signalr"
        let serverHub = new Hubs.ChatHub(signalR.hub)
        let clientHub = new Hubs.ChatClientHub()


        clientHub.Register(signalR.hub )
        signalR.hub.start() |> ignore
        clientHub,serverHub

    let registerSingalR (cHub : ChatClientHub) (sHub : ChatHub) =
        let options = createEmpty<PostalSubscriptionDefinition>()
                      |> fun n -> n.topic <- "message.new"
                                  n.callback <- Func<_,_,_>(fun n msg ->
                                      msg.data
                                      |> unbox<Message.MessageProps>
                                      |> fun a -> sHub.SendMessage(ChatMessage(Nick = a.Author, Message = a.Text));
                                      |> ignore :> obj)
                                  n
        Globals.postal.subscribe(options)  |> ignore


        cHub.Send <- fun a ->
            createEmpty<PostalEnvelope> ()
            |> fun n -> n.topic <- "message.recived"
                        n.data <- {Message.Date = DateTime.Now; Message.Author = a.Nick; Message.Text = a.Message}
                        n
            |> Globals.postal.publish
            |> ignore

    let app () =
        do bootstrapReact ()
        let cHub, sHub =  bootstrapSignalR ()
        do registerSingalR cHub sHub
        ()
