namespace RethinkDB.Demo.Server

open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs

type ChatMessage = {Nick : string; Message : string}

type IChatClientHub =
    abstract member Send : ChatMessage -> unit

[<HubName("ChatHub")>]
type ChatHub() =
    inherit Hub<IChatClientHub>()

    member this.SendMessage msg =
        this.Clients.AllExcept(this.Context.ConnectionId).Send(msg)
        "Message Send"


type Timer(interval, callback) =
    let mb = new MailboxProcessor<bool>(fun inbox ->
            async {
                let stop = ref false
                while not !stop do
                    // Sleep for our interval time
                    do! Async.Sleep interval

                    // Timers raise on threadpool threads - mimic that behavior here
                    do! Async.SwitchToThreadPool()
                    callback()

                    // Check for our stop message
                    let! msg = inbox.TryReceive(1)
                    stop := defaultArg msg false
            })

    member __.Start() = mb.Start()
    member __.Stop() = mb.Post true

type Broadcaster () =
    let context = GlobalHost.ConnectionManager.GetHubContext<ChatHub, IChatClientHub>()
    let timer = Timer(1000, fun _ ->
        { 
          Nick = System.Guid.NewGuid().ToString()
          Message = System.IO.Path.GetRandomFileName() }
        |> context.Clients.All.Send)
    do timer.Start()
