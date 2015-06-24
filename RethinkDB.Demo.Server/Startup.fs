namespace RethinkDB.Demo.Server

open Owin
open Microsoft.Owin
open System
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.Http.Owin
open Microsoft.AspNet.SignalR

[<Sealed>]
type Startup() =

    member __.Configuration(builder: IAppBuilder) =
        //let broadcaster = new Broadcaster()
        builder.MapSignalR() |> ignore
