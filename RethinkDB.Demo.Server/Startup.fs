namespace RethinkDB.Demo.Server

open Owin
open Microsoft.Owin
open System
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.Http.Owin
open Microsoft.AspNet.SignalR
open Microsoft.Owin.Cors

[<Sealed>]
type Startup() =

    member __.Configuration(builder: IAppBuilder) =
        let broadcaster = new Broadcaster()
        let config = HubConfiguration()

        builder.Map("/signalr", fun map -> 
            map.UseCors(CorsOptions.AllowAll) |> ignore
            map.RunSignalR(HubConfiguration( EnableJSONP = true)) |> ignore
        ) |> ignore
