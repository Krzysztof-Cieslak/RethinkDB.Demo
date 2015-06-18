namespace RethinkDB.Demo.Client

open FunScript.TypeScript.React
open FunScript.TypeScript
open FunScript
open Helpers
open System.Collections.Generic
open System

[<ReflectedDefinition>]
module MessageForm =
    type MessageFormProps = { onMessageSubmit : Message.MessageProps -> unit }
    type MessageFormState () = class end
    type MessageForm () =
        interface ComponentSpec<MessageFormProps, MessageFormState>
        interface Component<MessageFormProps, MessageFormState>

    let private handleSubmit (cf : MessageForm) (e : FormEvent) =
        e.preventDefault()
        let author = Globals.findDOMNode(cf.refs.["author"])
        let text = Globals.findDOMNode(cf.refs.["text"])
        //TODO - change to messaging
        cf.props.onMessageSubmit {Message.Date = DateTime.Now; Message.Author = author.value.Trim(); Message.Text = text.value.Trim() }
        author.value <- ""
        text.value <- ""

    let private render (cf : MessageForm) =
        let attr = [("className", unbox<obj>("MessageForm")); ("onSubmit", unbox<obj>(handleSubmit cf) )] |> createObject
        let attr2 = [("type", "text"); ("placeholder", "Your name"); ("ref", "author")] |> createObject
        let attr3 = [("type", "text"); ("placeholder", "Say something..."); ("ref", "text")] |> createObject
        let attr4 = [("type", "submit"); ("value", "Post");] |> createObject

        Globals.createElement("form", attr,
            Globals.createElement("input", attr2),
            Globals.createElement("input", attr3),
            Globals.createElement("input", attr4))

    let register () =
        let mf = MessageForm()
        mf.``render <-``(fun _ -> JS.this |> render |> unbox<ReactElement<_>>)
        mf |> React.registerComponent "MessageForm"
