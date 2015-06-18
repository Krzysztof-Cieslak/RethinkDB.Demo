namespace RethinkDB.Demo.Client

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
        let message = sprintf "[%d2:%d2] %s : %s" dt.Hour dt.Minute c.props.Author c.props.Text

        Globals.createElement("div", attr,
            Globals.createElement("span", null, message))

    let register () =
        let m = Message()
        m.``render <-``(fun _ -> JS.this |> render |> unbox<ReactElement<_>>)
        m |> React.registerComponent "Message"
