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

    let app () =
        do bootstrapReact ()
        ()
