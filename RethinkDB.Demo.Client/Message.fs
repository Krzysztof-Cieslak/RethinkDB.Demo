namespace RethinkDB.Demo.Client

open FunScript.TypeScript.Mui
open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript
open Helpers
open System.Collections.Generic
open System

[<ReflectedDefinition>]
module Message =
    type MessageProps = {Date : System.DateTime; Text : string; Author : string}
    type MessageState () = class end
    type Message () =
        interface ComponentSpec<MessageProps, MessageState>
        interface Component<MessageProps, MessageState>

    let private render (c : Message) =
        let attr = [("className", "message")] |> createObject
        let dt = c.props.Date
        let z= dt.ToShortTimeString()
        let message = sprintf "[%s] %s : %s" z c.props.Author c.props.Text

        Globals.createElement("div", attr,
            Globals.createElement("span", null, message))

    let register (material : mui, tm : ThemeManager) =
        let m = Message()
        m.``render <-``(fun _ -> JS.this |> render |> unbox<ReactElement<_>>)
        m.``getChildContext <-``(fun _ -> [("muiTheme", tm.getCurrentTheme())] |> createObject :> obj )
        m.childContextTypes <- ([("muiTheme", Globals.PropTypes._object.isRequired )] |> createObject :> obj)
        m |> React.registerComponent "Message"
