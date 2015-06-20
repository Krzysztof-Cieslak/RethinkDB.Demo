namespace RethinkDB.Demo.Client

open FunScript
open FunScript.TypeScript
open FunScript.TypeScript.Mui
open FunScript.TypeScript.React
open Helpers
open System
open System.Collections.Generic


[<ReflectedDefinition>]
module MessageForm =
    type MessageFormProps = { onMessageSubmit : Message.MessageProps -> unit }
    type MessageFormState () = class end
    type MessageForm () =
        interface ComponentSpec<MessageFormProps, MessageFormState>
        interface Component<MessageFormProps, MessageFormState>

    let private handleSay (cf : MessageForm) (e : _ ) =
        let author = cf.refs.["author"]
        let text = cf.refs.["text"]
        //TODO - change to messaging
        cf.props.onMessageSubmit { Message.Date = DateTime.Now;
                                   Message.Author = author.getValue().ToString().Trim();
                                   Message.Text = text.getValue().ToString().Trim() }
        author.setValue("")
        text.setValue("")

    let private render (m : mui) (cf : MessageForm) =
        let attr =  ["className" ==> "MessageForm" ] |> createObject
        let attr2 = ["className" ==> "nameTextBox"
                     "type" ==> "text"
                     "hintText" ==> "Your name"
                     "ref" ==> "author"] |> createObject
        let attr3 = ["type" ==> "text"
                     "className" ==> "messageTextBox"
                     "hintText" ==> "Say something..."
                     "ref" ==> "text"] |> createObject
        let attr4 = ["type" ==> "submit"
                     "className" ==> "sayButton"
                     "value" ==> "Post"
                     "label" ==> "Say"
                     "onMouseDown" ==> (handleSay cf)] |> createObject


        let Button = m.RaisedButton
        let TextField = m.TextField

        Globals.createElement("div", attr,
            Globals.createElement(TextField, attr2),
            Globals.createElement(TextField, attr3),
            Globals.createElement(Button, attr4))

    let register (material : mui, tm : ThemeManager) =
        let mf = MessageForm()
        mf.``render <-``(fun _ -> JS.this |> render material |> unbox<ReactElement<_>>)
        mf.``getChildContext <-``(fun _ -> [("muiTheme", tm.getCurrentTheme())] |> createObject :> obj )
        mf.childContextTypes <- ([("muiTheme", Globals.PropTypes._object.isRequired )] |> createObject :> obj)
        mf |> React.registerComponent "MessageForm"
