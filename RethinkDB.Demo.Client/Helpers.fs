namespace RethinkDB.Demo.Client

open System
open System.Collections.Generic
open FunScript
open FunScript.TypeScript
open FunScript.TypeScript.React

[<ReflectedDefinition>]
module Helpers =
    type Element with
        [<FunScript.JSEmitInline("({0}.value)")>]
        member __.value with get() : string = failwith "never" and set (v : string) : unit = failwith "never"

    module JS =
        [<JSEmitInline("this")>]
        let this<'O> :  'O = failwith "never"

        [<FunScript.JSEmitInline("require({0})")>]
        let require (path : string) : 'T = failwith "never"

    let createObject (lst : list<string * 'a>) =
        let t = Dictionary<string,obj>()
        lst |> List.iter(fun i -> t.Add(fst i, snd i ))
        t

    let (==>) a b = a, box<obj> b

    module React =
        let private classContainer = new Dictionary<string, ComponentClass<obj>>()

        let registerComponent name (cmpnt : obj) =
            let cl = Globals.createClass(unbox<ComponentSpec<_,_>>(cmpnt))
            classContainer.Add(name, cl)

        let getComponent name =
            classContainer.[name] |> unbox<ComponentClass<'T>>
