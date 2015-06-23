namespace RethinkDB.Demo.Client

open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript
open Helpers
open System.Collections.Generic
open System

open SignalRProvider


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
        signalR.hub.url <- "http://localhost:81/ChatHub"
        let serverHub = new Hubs.ChatHub(signalR.hub)
        let clientHub = new Hubs.ChatClientHub()

        clientHub.Send <- (fun msg -> Globals.console.log msg )
        clientHub.Register(signalR.hub )
        signalR.hub.start () |> ignore
        ()

    let app () =
        do bootstrapReact ()
        do bootstrapSignalR ()