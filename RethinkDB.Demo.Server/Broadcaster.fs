namespace RethinkDB.Demo.Server

open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs

type Broadcaster () =
    let context = GlobalHost.ConnectionManager.GetHubContext<ChatHub, IChatClientHub>()
