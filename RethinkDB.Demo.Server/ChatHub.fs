namespace RethinkDB.Demo.Server

open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs

module Hubs =

    type ChatMessage = {Nick : string; Message : string}

    type IChatClientHub =
        abstract member Send : ChatMessage -> unit

    [<HubName("ChatHub")>]
    type ChatHub() =
        inherit Hub<IChatClientHub>()

        member this.SendMessage msg =
            this.Clients.All.Send(msg)
