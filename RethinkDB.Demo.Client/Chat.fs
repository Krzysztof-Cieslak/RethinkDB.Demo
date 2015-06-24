namespace RethinkDB.Demo.Client

open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript.TypeScript.Mui
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

    let private subscriptions = ResizeArray()

    let private handle (cb : Chat) (cp : Message.MessageProps) =
        let messages = cb.state.Data
        let messages' = Array.append messages [|cp|]
        cb.setState({Data = messages'})
        () :> obj

    let private getInitialState () =
        {Data = [||]}

    let private render (m : mui) (cb : Chat) =
        let attr = ["className" ==> "Chat"] |> createObject
        let attr2 = ["title" ==> "F# Chat";
                     "showMenuIconButton" ==> false ] |> createObject

        let AppBar = m.AppBar
        let MessageList = React.getComponent "MessageList"
        let MessageForm = React.getComponent "MessageForm"

        Globals.createElement("div", attr,
            Globals.createElement(AppBar, attr2),
            Globals.createElement(MessageList, {MessageList.Data = cb.state.Data}),
            Globals.createElement(MessageForm)
        )

    let private registerHandlers (cb : Chat) =
        let options = createEmpty<PostalSubscriptionDefinition>()
                      |> fun n -> n.topic <- "message.new"
                                  n.callback <- Func<_,_,_>(fun n msg ->
                                      msg.data
                                      |> unbox<Message.MessageProps>
                                      |> handle cb )
                                  n
        let t = Globals.postal.subscribe(options)
        subscriptions.Add t

        let options2 = createEmpty<PostalSubscriptionDefinition>()
                      |> fun n -> n.topic <- "message.recived"
                                  n.callback <- Func<_,_,_>(fun n msg ->
                                      msg.data
                                      |> unbox<Message.MessageProps>
                                      |> handle cb )
                                  n
        let t2 = Globals.postal.subscribe(options2)
        subscriptions.Add t2

    let private unregisterHandlers () =
        subscriptions |> Seq.iter (fun s -> s.unsubscribe() |> ignore)


    let register (material : mui, tm : ThemeManager) =
        let cb = Chat()
        cb.``render <-``(fun _ -> JS.this |> render material |> unbox<ReactElement<_>>)
        cb.``getInitialState <-``(fun _ -> getInitialState ())
        cb.``getChildContext <-``(fun _ -> [("muiTheme", tm.getCurrentTheme())] |> createObject :> obj )
        cb.childContextTypes <- ([("muiTheme", Globals.PropTypes._object.isRequired )] |> createObject :> obj)
        cb.``componentDidMount <-``(fun _ -> JS.this |> registerHandlers)
        cb.``componentWillUnmount <-``(fun _ -> unregisterHandlers ())

        cb |> React.registerComponent "Chat"
