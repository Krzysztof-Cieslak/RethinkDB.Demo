namespace RethinkDB.Demo.Client

open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript
open Helpers
open System.Collections.Generic
open System

[<ReflectedDefinition>]
module MessageList =
    type MessageListProps = {Data : Message.MessageProps[]}
    type MessageListState () = class end
    type MessageList () =
        interface ComponentSpec<MessageListProps, MessageListState>
        interface Component<MessageListProps, MessageListState>

    let private render (cl : MessageList) =
        let attr = [("className", "messageList")] |> createObject

        let message = React.getComponent "Message"
        let messageNodes =  cl.props.Data |> Array.map(fun n -> Globals.createElement(message, n ))
        Globals.createElement("div", attr, messageNodes )


    let register () =
        let ml = MessageList ()
        ml.``render <-``(fun _ -> JS.this |> render |> unbox<ReactElement<_>>)
        //TODO - register event handler
        ml |> React.registerComponent "MessageList"
