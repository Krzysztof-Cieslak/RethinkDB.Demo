namespace RethinkDB.Demo.Client

open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript
open Helpers
open System.Collections.Generic
open System

[<ReflectedDefinition>]
module Chat =
    type ChatProps () = class end
    type ChatState = {Data : Message.MessageProps[]}
    type Chat () =
        interface ComponentSpec<ChatProps, ChatState>
        interface Component<ChatProps, ChatState>

    let private handle (cb : Chat) (cp : Message.MessageProps) =
        let messages = cb.state.Data
        let messages' = Array.append messages [|cp|]
        cb.setState({Data = messages'})

    let private getInitialState () =
        {Data = [||]}

    let private render (cb : Chat) =
        let attr = [("className", "Chat")] |> createObject

        let MessageList = React.getComponent "MessageList"
        let MessageForm = React.getComponent "MessageForm"

        Globals.createElement("div", attr,
            Globals.createElement("h1", null, "Messages"),
            Globals.createElement(MessageList, {MessageList.Data = cb.state.Data}),
            Globals.createElement(MessageForm, {MessageForm.onMessageSubmit = handle cb})
        )

    let register () =
        let cb = Chat()
        cb.``render <-``(fun _ -> JS.this |> render |> unbox<ReactElement<_>>)
        cb.``getInitialState <-``(fun _ -> getInitialState ())
        cb |> React.registerComponent "Chat"
