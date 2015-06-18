namespace RethinkDB.Demo.Client

open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript
open Helpers
open System.Collections.Generic
open System


[<ReflectedDefinition>]
module App =

    let app () =
        do Message.register()
        do MessageList.register()
        do MessageForm.register()
        do Chat.register()
        React.getComponent "Chat"
        |> Globals.createElement
        |> fun e ->  Globals.render(e, Globals.document.getElementById("example"))
        |> ignore
