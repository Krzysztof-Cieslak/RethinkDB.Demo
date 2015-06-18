var list_1_Tuple_2_String__String__NilTuple_2_String__String_, list_1_Tuple_2_String__String__ConsTuple_2_String__String_, list_1_Tuple_2_String__Object__NilTuple_2_String__Object_, list_1_Tuple_2_String__Object__ConsTuple_2_String__Object_, TupleString_String, TupleString_Object_, String_1_PrintFormatToString$, React__registerComponent$, React__get_classContainer$, React__getComponent$, React__classContainer, MutableDic__Add$String__Object_String_Object_, MutableDic__Add$String__ComponentClass_1_Object_String_ComponentClass_1_Object_, Message__render$, Message__register$, Message_1__ctor$, MessageProps___ctor$, MessageList__render$, MessageList__register$, MessageList_1__ctor$, MessageListProps___ctor$, MessageForm__render$, MessageForm__register$, MessageForm__handleSubmit$, MessageForm_1__ctor$, MessageFormProps___ctor$, List__Iterate$Tuple_2_String__String_Tuple_2_String__String_, List__Iterate$Tuple_2_String__Object_Tuple_2_String__Object_, List__FoldIndexedAux$Unit__Tuple_2_String__String_Unit__Tuple_2_String__String_, List__FoldIndexedAux$Unit__Tuple_2_String__Object_Unit__Tuple_2_String__Object_, List__FoldIndexed$Tuple_2_String__String__Unit_Tuple_2_String__String__Unit_, List__FoldIndexed$Tuple_2_String__Object__Unit_Tuple_2_String__Object__Unit_, List__Fold$Tuple_2_String__String__Unit_Tuple_2_String__String__Unit_, List__Fold$Tuple_2_String__Object__Unit_Tuple_2_String__Object__Unit_, List__Empty$Tuple_2_String__String_Tuple_2_String__String_, List__Empty$Tuple_2_String__Object_Tuple_2_String__Object_, List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_, List__CreateCons$Tuple_2_String__Object_Tuple_2_String__Object_, Helpers__createObject$String_String, Helpers__createObject$Object_Object_, DateTime__get_Now$, DateTime__get_Minute$, DateTime__get_Hour$, DateTime__getValueUnsafe$, DateTime__createUnsafe$, Chat__render$, Chat__register$, Chat__handle$, Chat__getInitialState$, Chat_1__ctor$, ChatState___ctor$, Array__ZeroCreate$ReactElement_1_Object_ReactElement_1_Object_, Array__MapIndexed$MessageProps__ReactElement_1_Object_MessageProps__ReactElement_1_Object_, Array__Map$MessageProps__ReactElement_1_Object_MessageProps__ReactElement_1_Object_, Array__Length$MessageProps_MessageProps_, Array__Append$MessageProps_MessageProps_, App__app$;
App__app$ = (function(unitVar0)
{
    Message__register$();
    MessageList__register$();
    MessageForm__register$();
    Chat__register$();
    var ignored0 = (React.render((React.createElement(React__getComponent$("Chat"))), ((window.document).getElementById("example"))));
});
Array__Append$MessageProps_MessageProps_ = (function(xs,ys)
{
    return xs.concat(ys);;
});
Array__Length$MessageProps_MessageProps_ = (function(xs)
{
    return xs.length;;
});
Array__Map$MessageProps__ReactElement_1_Object_MessageProps__ReactElement_1_Object_ = (function(f,xs)
{
    return Array__MapIndexed$MessageProps__ReactElement_1_Object_MessageProps__ReactElement_1_Object_((function(_arg1)
    {
      return (function(x)
      {
        return f(x);
      });
    }), xs);
});
Array__MapIndexed$MessageProps__ReactElement_1_Object_MessageProps__ReactElement_1_Object_ = (function(f,xs)
{
    var ys = Array__ZeroCreate$ReactElement_1_Object_ReactElement_1_Object_(Array__Length$MessageProps_MessageProps_(xs));
    for (var i = 0; i <= (Array__Length$MessageProps_MessageProps_(xs) - 1); i++)
    {
      ys[i] = f(i)(xs[i]);
      null;
    };
    return ys;
});
Array__ZeroCreate$ReactElement_1_Object_ReactElement_1_Object_ = (function(size)
{
    return new Array(size);;
});
ChatState___ctor$ = (function(Data)
{
    var __this = this;
    __this.Data = Data;
});
Chat_1__ctor$ = (function(unitVar0)
{
    {};
});
Chat__getInitialState$ = (function(unitVar0)
{
    return (new ChatState___ctor$([]));
});
Chat__handle$ = (function(cb,cp)
{
    var messages = (cb.state).Data;
    var messages_ = Array__Append$MessageProps_MessageProps_(messages, [cp]);
    return (cb.setState((new ChatState___ctor$(messages_))));
});
Chat__register$ = (function(unitVar0)
{
    var cb = (new Chat_1__ctor$());
    (cb.render = (function()
    {
      return Chat__render$(this);
    }));
    (cb.getInitialState = (function()
    {
      return Chat__getInitialState$();
    }));
    return React__registerComponent$("Chat", cb);
});
Chat__render$ = (function(cb)
{
    var attr = Helpers__createObject$String_String(List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("className", "Chat")), List__Empty$Tuple_2_String__String_Tuple_2_String__String_()));
    var MessageList = React__getComponent$("MessageList");
    var MessageForm = React__getComponent$("MessageForm");
    return (React.createElement("div", attr, (React.createElement("h1", null, "Messages")), (React.createElement(MessageList, (new MessageListProps___ctor$((cb.state).Data)))), (React.createElement(MessageForm, (new MessageFormProps___ctor$((function(cp)
    {
      return Chat__handle$(cb, cp);
    })))))));
});
DateTime__createUnsafe$ = (function(value,kind)
{
    var date = value == null ? new Date() : new Date(value);
    if (isNaN(date)) { throw "The string was not recognized as a valid DateTime." }
    date.kind = kind;
    return date;
});
DateTime__getValueUnsafe$ = (function(d,key,utcKind)
{
    return d.kind == utcKind ? d['getUTC'+key]() : d['get'+key]();
});
DateTime__get_Hour$ = (function(dt,unitVar1)
{
    return DateTime__getValueUnsafe$(dt, "Hours", 1);
});
DateTime__get_Minute$ = (function(dt,unitVar1)
{
    return DateTime__getValueUnsafe$(dt, "Minutes", 1);
});
DateTime__get_Now$ = (function(unitVar0)
{
    return DateTime__createUnsafe$(null, 2);
});
Helpers__createObject$Object_Object_ = (function(lst)
{
    var t = {};
    List__Iterate$Tuple_2_String__Object_Tuple_2_String__Object_((function(i)
    {
      return MutableDic__Add$String__Object_String_Object_(t, i.Items[0.000000], i.Items[1.000000]);
    }), lst);
    return t;
});
Helpers__createObject$String_String = (function(lst)
{
    var t = {};
    List__Iterate$Tuple_2_String__String_Tuple_2_String__String_((function(i)
    {
      return MutableDic__Add$String__Object_String_Object_(t, i.Items[0.000000], i.Items[1.000000]);
    }), lst);
    return t;
});
List__CreateCons$Tuple_2_String__Object_Tuple_2_String__Object_ = (function(x,xs)
{
    return (new list_1_Tuple_2_String__Object__ConsTuple_2_String__Object_(x, xs));
});
List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_ = (function(x,xs)
{
    return (new list_1_Tuple_2_String__String__ConsTuple_2_String__String_(x, xs));
});
List__Empty$Tuple_2_String__Object_Tuple_2_String__Object_ = (function()
{
    return (new list_1_Tuple_2_String__Object__NilTuple_2_String__Object_());
});
List__Empty$Tuple_2_String__String_Tuple_2_String__String_ = (function()
{
    return (new list_1_Tuple_2_String__String__NilTuple_2_String__String_());
});
List__Fold$Tuple_2_String__Object__Unit_Tuple_2_String__Object__Unit_ = (function(f,seed,xs)
{
    return List__FoldIndexed$Tuple_2_String__Object__Unit_Tuple_2_String__Object__Unit_((function(_arg1)
    {
      return (function(acc)
      {
        return (function(x)
        {
          return f(acc)(x);
        });
      });
    }), seed, xs);
});
List__Fold$Tuple_2_String__String__Unit_Tuple_2_String__String__Unit_ = (function(f,seed,xs)
{
    return List__FoldIndexed$Tuple_2_String__String__Unit_Tuple_2_String__String__Unit_((function(_arg1)
    {
      return (function(acc)
      {
        return (function(x)
        {
          return f(acc)(x);
        });
      });
    }), seed, xs);
});
List__FoldIndexed$Tuple_2_String__Object__Unit_Tuple_2_String__Object__Unit_ = (function(f,seed,xs)
{
    return List__FoldIndexedAux$Unit__Tuple_2_String__Object_Unit__Tuple_2_String__Object_(f, 0, seed, xs);
});
List__FoldIndexed$Tuple_2_String__String__Unit_Tuple_2_String__String__Unit_ = (function(f,seed,xs)
{
    return List__FoldIndexedAux$Unit__Tuple_2_String__String_Unit__Tuple_2_String__String_(f, 0, seed, xs);
});
List__FoldIndexedAux$Unit__Tuple_2_String__Object_Unit__Tuple_2_String__Object_ = (function(f,i,acc,_arg1)
{
    if ((_arg1.Tag == 1.000000)) 
    {
      var xs = _arg1.Item2;
      var x = _arg1.Item1;
      return List__FoldIndexedAux$Unit__Tuple_2_String__Object_Unit__Tuple_2_String__Object_(f, (i + 1), f(i)(acc)(x), xs);
    }
    else
    {
      return acc;
    };
});
List__FoldIndexedAux$Unit__Tuple_2_String__String_Unit__Tuple_2_String__String_ = (function(f,i,acc,_arg1)
{
    if ((_arg1.Tag == 1.000000)) 
    {
      var xs = _arg1.Item2;
      var x = _arg1.Item1;
      return List__FoldIndexedAux$Unit__Tuple_2_String__String_Unit__Tuple_2_String__String_(f, (i + 1), f(i)(acc)(x), xs);
    }
    else
    {
      return acc;
    };
});
List__Iterate$Tuple_2_String__Object_Tuple_2_String__Object_ = (function(f,xs)
{
    var _260;
    return List__Fold$Tuple_2_String__Object__Unit_Tuple_2_String__Object__Unit_((function(unitVar0)
    {
      return (function(x)
      {
        return f(x);
      });
    }), _260, xs);
});
List__Iterate$Tuple_2_String__String_Tuple_2_String__String_ = (function(f,xs)
{
    var _32;
    return List__Fold$Tuple_2_String__String__Unit_Tuple_2_String__String__Unit_((function(unitVar0)
    {
      return (function(x)
      {
        return f(x);
      });
    }), _32, xs);
});
MessageFormProps___ctor$ = (function(onMessageSubmit)
{
    var __this = this;
    __this.onMessageSubmit = onMessageSubmit;
});
MessageForm_1__ctor$ = (function(unitVar0)
{
    {};
});
MessageForm__handleSubmit$ = (function(cf,e)
{
    (e.preventDefault());
    var author = (React.findDOMNode(((cf.refs)["author"])));
    var text = (React.findDOMNode(((cf.refs)["text"])));
    var Author = (author.value).trim();
    (cf.props).onMessageSubmit((new MessageProps___ctor$(DateTime__get_Now$(), (text.value).trim(), Author)));
    (author.value) = "";
    null;
    (text.value) = "";
    return null;
});
MessageForm__register$ = (function(unitVar0)
{
    var mf = (new MessageForm_1__ctor$());
    (mf.render = (function()
    {
      return MessageForm__render$(this);
    }));
    return React__registerComponent$("MessageForm", mf);
});
MessageForm__render$ = (function(cf)
{
    var attr = Helpers__createObject$Object_Object_(List__CreateCons$Tuple_2_String__Object_Tuple_2_String__Object_((new TupleString_Object_("className", "MessageForm")), List__CreateCons$Tuple_2_String__Object_Tuple_2_String__Object_((new TupleString_Object_("onSubmit", (function(e)
    {
      return MessageForm__handleSubmit$(cf, e);
    }))), List__Empty$Tuple_2_String__Object_Tuple_2_String__Object_())));
    var attr2 = Helpers__createObject$String_String(List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("type", "text")), List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("placeholder", "Your name")), List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("ref", "author")), List__Empty$Tuple_2_String__String_Tuple_2_String__String_()))));
    var attr3 = Helpers__createObject$String_String(List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("type", "text")), List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("placeholder", "Say something...")), List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("ref", "text")), List__Empty$Tuple_2_String__String_Tuple_2_String__String_()))));
    var attr4 = Helpers__createObject$String_String(List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("type", "submit")), List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("value", "Post")), List__Empty$Tuple_2_String__String_Tuple_2_String__String_())));
    return (React.createElement("form", attr, (React.createElement("input", attr2)), (React.createElement("input", attr3)), (React.createElement("input", attr4))));
});
MessageListProps___ctor$ = (function(Data)
{
    var __this = this;
    __this.Data = Data;
});
MessageList_1__ctor$ = (function(unitVar0)
{
    {};
});
MessageList__register$ = (function(unitVar0)
{
    var ml = (new MessageList_1__ctor$());
    (ml.render = (function()
    {
      return MessageList__render$(this);
    }));
    return React__registerComponent$("MessageList", ml);
});
MessageList__render$ = (function(cl)
{
    var attr = Helpers__createObject$String_String(List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("className", "messageList")), List__Empty$Tuple_2_String__String_Tuple_2_String__String_()));
    var message = React__getComponent$("Message");
    var messageNodes = Array__Map$MessageProps__ReactElement_1_Object_MessageProps__ReactElement_1_Object_((function(n)
    {
      return (React.createElement(message, n));
    }), (cl.props).Data);
    return (React.createElement("div", attr, messageNodes));
});
MessageProps___ctor$ = (function(Date,Text,Author)
{
    var __this = this;
    __this.Date = Date;
    __this.Text = Text;
    __this.Author = Author;
});
Message_1__ctor$ = (function(unitVar0)
{
    {};
});
Message__register$ = (function(unitVar0)
{
    var m = (new Message_1__ctor$());
    (m.render = (function()
    {
      return Message__render$(this);
    }));
    return React__registerComponent$("Message", m);
});
Message__render$ = (function(c)
{
    var attr = Helpers__createObject$String_String(List__CreateCons$Tuple_2_String__String_Tuple_2_String__String_((new TupleString_String("className", "message")), List__Empty$Tuple_2_String__String_Tuple_2_String__String_()));
    var dt = (c.props).Date;
    var clo1 = String_1_PrintFormatToString$("[%d2:%d2] %s : %s");
    var message = (function(arg10)
    {
      var clo2 = clo1(arg10);
      return (function(arg20)
      {
        var clo3 = clo2(arg20);
        return (function(arg30)
        {
          var clo4 = clo3(arg30);
          return (function(arg40)
          {
            return clo4(arg40);
          });
        });
      });
    })(DateTime__get_Hour$(dt))(DateTime__get_Minute$(dt))((c.props).Author)((c.props).Text);
    return (React.createElement("div", attr, (React.createElement("span", null, message))));
});
MutableDic__Add$String__ComponentClass_1_Object_String_ComponentClass_1_Object_ = (function(dic,key,value)
{
    if (dic[key] === undefined) { dic[key] = value } else { throw 'Key already exists' };
});
MutableDic__Add$String__Object_String_Object_ = (function(dic,key,value)
{
    if (dic[key] === undefined) { dic[key] = value } else { throw 'Key already exists' };
});
React__getComponent$ = (function(name)
{
    return React__classContainer[name];
});
React__get_classContainer$ = (function()
{
    return {};
});
React__registerComponent$ = (function(name,cmpnt)
{
    var cl = (React.createClass(cmpnt));
    return MutableDic__Add$String__ComponentClass_1_Object_String_ComponentClass_1_Object_(React__classContainer, name, cl);
});
String_1_PrintFormatToString$ = (function(s)
{
    var reg = /%[+\-* ]?\d*(?:\.(\d+))?(\w)/;
    function formatToString(rep) {
        s = s.replace(reg, function(match, precision, format) {
            switch (format) {
                case "f": case "F": return precision ? rep.toFixed(precision) : rep.toFixed(6);
                case "g": case "G": return rep.toPrecision(precision);
                case "e": case "E": return rep.toExponential(precision);
                case "A": return JSON.stringify(rep);
                default:  return rep;
            }
        });
        return reg.test(s) ? formatToString : s;
    }
    return formatToString;
});
TupleString_Object_ = (function(Item0,Item1)
{
    var __this = this;
    __this.Items = [Item0, Item1];
});
TupleString_String = (function(Item0,Item1)
{
    var __this = this;
    __this.Items = [Item0, Item1];
});
list_1_Tuple_2_String__Object__ConsTuple_2_String__Object_ = (function(Item1,Item2)
{
    var __this = this;
    __this.Tag = 1.000000;
    __this._CaseName = "Cons";
    __this.Item1 = Item1;
    __this.Item2 = Item2;
});
list_1_Tuple_2_String__Object__NilTuple_2_String__Object_ = (function()
{
    var __this = this;
    __this.Tag = 0.000000;
    __this._CaseName = "Nil";
});
list_1_Tuple_2_String__String__ConsTuple_2_String__String_ = (function(Item1,Item2)
{
    var __this = this;
    __this.Tag = 1.000000;
    __this._CaseName = "Cons";
    __this.Item1 = Item1;
    __this.Item2 = Item2;
});
list_1_Tuple_2_String__String__NilTuple_2_String__String_ = (function()
{
    var __this = this;
    __this.Tag = 0.000000;
    __this._CaseName = "Nil";
});
React__classContainer = React__get_classContainer$();
App__app$()