namespace RethinkDB.Demo.Server

open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs



type ChatMessage = {Date : System.DateTime; Nick : string; Message : string}

type IChatClientHub =
    abstract member Send : ChatMessage -> unit

[<HubName("ChatHub")>]
type ChatHub() =
    inherit Hub<IChatClientHub>()

    member this.SendMessage msg =
        this.Clients.All.Send(msg)
        this.Clients.All.Send({msg with Message = msg.Message + "2"})
        "Message Send"

module Brodcaster =
    let context = GlobalHost.ConnectionManager.GetHubContext<ChatHub, IChatClientHub>()
    let timer = new System.Timers.Timer(2000.0)
    timer.Elapsed.Add(fun _ ->
        { Date = System.DateTime.Now
          Nick = System.Guid.NewGuid().ToString()
          Message = System.IO.Path.GetRandomFileName() }
        |> context.Clients.All.Send
     )
