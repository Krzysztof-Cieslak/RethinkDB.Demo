namespace RethinkDB.Demo.Server


open RethinkDb
open RethinkDb.Newtonsoft.Configuration
open Newtonsoft.Json

module RethinkDBConnection =

    type Message = {
        // OptionConverter from http://gorodinski.com/blog/2013/01/05/json-dot-net-type-converters-for-f-option-list-tuple/
        // Allows None to be converted to null by JSON.NET
        //[<JsonConverter(typeof<JsonConverters.OptionConverter>)>]
        // NullHandlingValue: don't emit value if value is null. Let RethinkDB generate an ID.
        [<JsonProperty(NullValueHandling = NullValueHandling.Ignore)>]
        id: int option;
        date: System.DateTime;
        nick: string
        message : string
      }

    let connection () =
        let connectionFactory = ConfigurationAssembler.CreateConnectionFactory("example");
        connectionFactory.Get()
