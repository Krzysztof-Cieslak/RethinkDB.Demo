namespace RethinkDB.Demo.Client

open System.IO
open FunScript

module Generator =
    [<EntryPoint>]
    let main argv =        
        let code = Compiler.compileWithoutReturn(<@@ RethinkDB.Demo.Client.App.app() @@>)
        File.WriteAllText(argv.[0], code)
        printfn "%A" argv
        0 // return an integer exit code
