namespace RethinkDB.Demo.Server

open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs
open RethinkDb
open RethinkDb.Newtonsoft.Configuration
open RethinkDBConnection

type Broadcaster () =
    let context = GlobalHost.ConnectionManager.GetHubContext<ChatHub, IChatClientHub>()
    let conn = connection()    

    let rec handler (enumerator : IAsyncEnumerator<DmlResponseChange<_>>) = 
        do enumerator.MoveNext().Wait()
        enumerator.Current.NewValue |>  context.Clients.All.Send
        handler enumerator
        ()

    do async { Query.Db("test").Table("Messages").Changes()
               |> conn.StreamChangesAsync
               |> handler } |> Async.Start