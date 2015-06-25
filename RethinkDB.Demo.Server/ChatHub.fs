namespace RethinkDB.Demo.Server

open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs
open RethinkDb
open RethinkDb.Newtonsoft.Configuration
open RethinkDBConnection

type ChatMessage = {Nick : string; Message : string}

type IChatClientHub =
    abstract member Send : ChatMessage -> unit

[<HubName("ChatHub")>]
type ChatHub() =
    inherit Hub<IChatClientHub>()

    let conn = connection()    

    member this.SendMessage msg =
        this.Clients.AllExcept(this.Context.ConnectionId).Send(msg)
        Query.Db("test").Table<Message>("Messages")
                        .Insert( { id = None;
                                    date = System.DateTime.Now;
                                    nick = msg.Nick;
                                    message = msg.Message} )
        |> conn.Run
        |> ignore
        "Message Send"
