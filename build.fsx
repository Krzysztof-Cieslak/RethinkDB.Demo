#r "packages/FAKE/tools/FakeLib.dll"
#r "packages/FAKE.IIS/tools/Fake.IIS.dll"

open Fake
open Fake.AssemblyInfoFile
open System

let buildDir = "./build"
let releaseDir = "./release"
let applicationOutput = "RethinkDB.Demo.App"

let serverAppName = "RethinkDB.Demo.Suave"
let serverAppProj = "RethinkDB.Demo.Suave.fsproj"

let clientGeneratorName = "RethinkDB.Demo.Client"
let clientGeneratorProj = "RethinkDB.Demo.Client.fsproj"
let clientGeneratorExe = buildDir @@ "RethinkDB.Demo.Client.exe"
let clientGeneratorOutput = applicationOutput @@ "client" @@ "client.js"
let serverExe ="RethinkDB.Demo.Suave.exe"

let webBuildPath = buildDir @@ "_PublishedWebsites" @@ serverAppName

let browserify = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) @@ "npm" @@ "browserify.cmd"


Target "Default" DoNothing

Target "BuildServer" (fun _ ->
    !! (serverAppName @@ serverAppProj)
    |> MSBuildRelease buildDir "Build"
    |> fun lst ->
        killProcess "RethinkDB.Demo.Suave"
        !! (applicationOutput @@ "*.*") -- (applicationOutput @@ "index.html")|> DeleteFiles
        CopyFiles (applicationOutput) lst
    Diagnostics.ProcessStartInfo(FileName = serverExe, WorkingDirectory = applicationOutput )
    |> Diagnostics.Process.Start
    |> ignore
)

Target "BuildClient" (fun _ ->
    !! (clientGeneratorName @@ clientGeneratorProj)
    |> MSBuildRelease buildDir "Build"
    |> Log "Build-Output: "

    let result = ExecProcess (fun info ->
            info.FileName <- clientGeneratorExe
            info.Arguments <- clientGeneratorOutput) System.TimeSpan.MaxValue
    if result <> 0 then failwithf "Error during running ClientGenerator "
)

Target "Browserify" (fun _ ->
    let result = ExecProcess (fun info ->
            info.FileName <- browserify
            info.WorkingDirectory <- applicationOutput @@ "client"
            info.Arguments <- "client.js > app.js -r material-ui") System.TimeSpan.MaxValue
    if result <> 0 then failwithf "Error during running ClientGenerator "
)


"BuildClient"
  ==> "Browserify"
  ==> "Default"

"BuildServer"
  ==> "Default"

RunTargetOrDefault "Default"
