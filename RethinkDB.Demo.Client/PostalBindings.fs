namespace FunScript.TypeScript

open FunScript
open FunScript.TypeScript

type Globals = interface end
type PostalChannel = interface end
type PostalConfiguration = interface end
type PostalEnvelope = interface end
type PostalStatic = interface end
type PostalSubscriptionChannelCollection = interface end
type PostalSubscriptionCollection = interface end
type PostalSubscriptionDefinition = interface end
type PostalSubscriptionQuery = interface end
type PostalChannelDefinition =
    inherit PostalChannel

namespace FunScript.TypeScript

[<AutoOpen>]
module PostalExtensions =


    type Globals with
        [<FunScript.JSEmitInline("(window.postal)")>]
        static member postal with get() : FunScript.TypeScript.PostalStatic = failwith "never" and set (v : FunScript.TypeScript.PostalStatic) : unit = failwith "never"

    type FunScript.TypeScript.PostalChannel with
        [<FunScript.JSEmitInline("({0}.channel)")>]
        member __.channel with get() : string = failwith "never" and set (v : string) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.topic)")>]
        member __.topic with get() : string = failwith "never" and set (v : string) : unit = failwith "never"

    type FunScript.TypeScript.PostalChannelDefinition with
        [<FunScript.JSEmitInline("({0}.subscribe({1}, {2}))")>]
        member __.subscribe(topic : string, callback : System.Func<obj, FunScript.TypeScript.PostalEnvelope, obj>) : FunScript.TypeScript.PostalSubscriptionDefinition = failwith "never"
        [<FunScript.JSEmitInline("({0}.subscribe = {1})")>]
        member __.``subscribe <-``(func : System.Func<string, System.Func<obj, FunScript.TypeScript.PostalEnvelope, obj>, FunScript.TypeScript.PostalSubscriptionDefinition>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.publish({1}, {2}))")>]
        member __.publish(topic : string, data : obj) : obj = failwith "never"
        [<FunScript.JSEmitInline("({0}.publish = {1})")>]
        member __.``publish <-``(func : System.Func<string, obj, obj>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.publish({1}))")>]
        member __.publish(env : FunScript.TypeScript.PostalEnvelope) : obj = failwith "never"
        [<FunScript.JSEmitInline("({0}.publish = {1})")>]
        member __.``publish <-``(func : System.Func<FunScript.TypeScript.PostalEnvelope, obj>) : unit = failwith "never"


    type FunScript.TypeScript.PostalConfiguration with
        [<FunScript.JSEmitInline("({0}.resolver)")>]
        member __.resolver with get() : obj = failwith "never" and set (v : obj) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.DEFAULT_CHANNEL)")>]
        member __.DEFAULT_CHANNEL with get() : string = failwith "never" and set (v : string) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.SYSTEM_CHANNEL)")>]
        member __.SYSTEM_CHANNEL with get() : string = failwith "never" and set (v : string) : unit = failwith "never"


    type FunScript.TypeScript.PostalEnvelope with

        [<FunScript.JSEmitInline("({0}.channel)")>]
        member __.channel with get() : string = failwith "never" and set (v : string) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.topic)")>]
        member __.topic with get() : string = failwith "never" and set (v : string) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.timeStamp)")>]
        member __.timeStamp with get() : obj = failwith "never" and set (v : obj) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.data)")>]
        member __.data with get() : obj = failwith "never" and set (v : obj) : unit = failwith "never"

    type FunScript.TypeScript.PostalStatic with

        [<FunScript.JSEmitInline("({0}.addWireTap({1}))")>]
        member __.addWireTap(wireTap : System.Func<obj, FunScript.TypeScript.PostalEnvelope,obj>) : obj = failwith "never"
        [<FunScript.JSEmitInline("({0}.addWireTap = {1})")>]
        member __.``addWireTap <-``(func : System.Func<System.Func<obj, FunScript.TypeScript.PostalEnvelope, obj>, obj>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.channel({?1}))")>]
        member __.channel(?channelName : string) : FunScript.TypeScript.PostalChannelDefinition = failwith "never"
        [<FunScript.JSEmitInline("({0}.channel = {1})")>]
        member __.``channel <-``(func : System.Func<string, FunScript.TypeScript.PostalChannelDefinition>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.configuration)")>]
        member __.configuration with get() : FunScript.TypeScript.PostalConfiguration = failwith "never" and set (v : FunScript.TypeScript.PostalConfiguration) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.getSubscribersFor({?1}))")>]
        member __.getSubscribersFor(?options : FunScript.TypeScript.PostalSubscriptionQuery) : array<FunScript.TypeScript.PostalSubscriptionDefinition> = failwith "never"
        [<FunScript.JSEmitInline("({0}.getSubscribersFor = {1})")>]
        member __.``getSubscribersFor <-``(func : System.Func<FunScript.TypeScript.PostalSubscriptionQuery, array<FunScript.TypeScript.PostalSubscriptionDefinition>>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.linkChannels({1}, {2}))")>]
        member __.linkChannels(source : FunScript.TypeScript.PostalChannel, destination : FunScript.TypeScript.PostalChannel) : array<FunScript.TypeScript.PostalSubscriptionDefinition> = failwith "never"
        [<FunScript.JSEmitInline("({0}.linkChannels = {1})")>]
        member __.``linkChannels <-``(func : System.Func<FunScript.TypeScript.PostalChannel, FunScript.TypeScript.PostalChannel, array<FunScript.TypeScript.PostalSubscriptionDefinition>>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.linkChannels({1}, {2}))")>]
        member __.linkChannels(source : FunScript.TypeScript.PostalChannel, destination : array<FunScript.TypeScript.PostalChannel>) : array<FunScript.TypeScript.PostalSubscriptionDefinition> = failwith "never"
        [<FunScript.JSEmitInline("({0}.linkChannels = {1})")>]
        member __.``linkChannels <-``(func : System.Func<FunScript.TypeScript.PostalChannel, array<FunScript.TypeScript.PostalChannel>, array<FunScript.TypeScript.PostalSubscriptionDefinition>>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.noConflict())")>]
        member __.noConflict() : FunScript.TypeScript.PostalStatic = failwith "never"
        [<FunScript.JSEmitInline("({0}.noConflict = {1})")>]
        member __.``noConflict <-``(func : System.Func<FunScript.TypeScript.PostalStatic>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.publish({1}))")>]
        member __.publish(env : FunScript.TypeScript.PostalEnvelope) : FunScript.TypeScript.PostalEnvelope = failwith "never"
        [<FunScript.JSEmitInline("({0}.publish = {1})")>]
        member __.``publish <-``(func : System.Func<FunScript.TypeScript.PostalEnvelope, FunScript.TypeScript.PostalEnvelope>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.reset())")>]
        member __.reset() : obj = failwith "never"
        [<FunScript.JSEmitInline("({0}.reset = {1})")>]
        member __.``reset <-``(func : System.Func<obj>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.subscribe({1}))")>]
        member __.subscribe(options : FunScript.TypeScript.PostalSubscriptionDefinition) : FunScript.TypeScript.PostalSubscriptionDefinition = failwith "never"
        [<FunScript.JSEmitInline("({0}.subscribe = {1})")>]
        member __.``subscribe <-``(func : System.Func<FunScript.TypeScript.PostalSubscriptionDefinition, FunScript.TypeScript.PostalSubscriptionDefinition>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.subscriptions)")>]
        member __.subscriptions with get() : FunScript.TypeScript.PostalSubscriptionCollection = failwith "never" and set (v : FunScript.TypeScript.PostalSubscriptionCollection) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.unsubscribe({1}))")>]
        member __.unsubscribe(sub : FunScript.TypeScript.PostalSubscriptionDefinition) : obj = failwith "never"
        [<FunScript.JSEmitInline("({0}.unsubscribe = {1})")>]
        member __.``unsubscribe <-``(func : System.Func<FunScript.TypeScript.PostalSubscriptionDefinition, obj>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.unsubscribeFor())")>]
        member __.unsubscribeFor() : obj = failwith "never"
        [<FunScript.JSEmitInline("({0}.unsubscribeFor = {1})")>]
        member __.``unsubscribeFor <-``(func : System.Func<obj>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.unsubscribeFor({1}))")>]
        member __.unsubscribeFor(postalSubscriptionQuery : obj) : obj = failwith "never"
        [<FunScript.JSEmitInline("({0}.unsubscribeFor = {1})")>]
        member __.``unsubscribeFor <-``(func : System.Func<obj, obj>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.wiretaps)")>]
        member __.wiretaps with get() : System.Func<obj, FunScript.TypeScript.PostalEnvelope, array<obj>> = failwith "never" and set (v : System.Func<obj, FunScript.TypeScript.PostalEnvelope, array<obj>>) : unit = failwith "never"

    type FunScript.TypeScript.PostalSubscriptionChannelCollection with

        [<FunScript.JSEmitInline("({0}[{1}])")>]
        member __.Item with get(i : string) : array<FunScript.TypeScript.PostalSubscriptionDefinition> = failwith "never" and set (i : string) (v : array<FunScript.TypeScript.PostalSubscriptionDefinition>) : unit = failwith "never"

    type FunScript.TypeScript.PostalSubscriptionCollection with

        [<FunScript.JSEmitInline("({0}[{1}])")>]
        member __.Item with get(i : string) : FunScript.TypeScript.PostalSubscriptionChannelCollection = failwith "never" and set (i : string) (v : FunScript.TypeScript.PostalSubscriptionChannelCollection) : unit = failwith "never"

    type FunScript.TypeScript.PostalSubscriptionDefinition with

        [<FunScript.JSEmitInline("({0}.channel)")>]
        member __.channel with get() : string = failwith "never" and set (v : string) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.topic)")>]
        member __.topic with get() : string = failwith "never" and set (v : string) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.callback)")>]
        member __.callback with get() : System.Func<obj, FunScript.TypeScript.PostalEnvelope, obj> = failwith "never" and set (v : System.Func<obj, FunScript.TypeScript.PostalEnvelope, obj>) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.unsubscribe())")>]
        member __.unsubscribe() : obj = failwith "never"
        [<FunScript.JSEmitInline("({0}.unsubscribe = {1})")>]
        member __.``unsubscribe <-``(func : System.Func<obj>) : unit = failwith "never"


    type FunScript.TypeScript.PostalSubscriptionQuery with

        [<FunScript.JSEmitInline("({0}.channel)")>]
        member __.channel with get() : string = failwith "never" and set (v : string) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.topic)")>]
        member __.topic with get() : string = failwith "never" and set (v : string) : unit = failwith "never"
        [<FunScript.JSEmitInline("({0}.context)")>]
        member __.context with get() : obj = failwith "never" and set (v : obj) : unit = failwith "never"
