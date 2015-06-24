#r "packages/FAKE/tools/FakeLib.dll"
#r "packages/FAKE.IIS/tools/Fake.IIS.dll"

open Fake
open Fake.AssemblyInfoFile
open System

let buildDir = "./build"
let releaseDir = "./release"
let applicationOutput = "RethinkDB.Demo.App"

let serverAppName = "RethinkDB.Demo.Server"
let serverAppProj = "RethinkDB.Demo.Server.fsproj"

let clientGeneratorName = "RethinkDB.Demo.Client"
let clientGeneratorProj = "RethinkDB.Demo.Client.fsproj"
let clientGeneratorExe = buildDir @@ "RethinkDB.Demo.Client.exe"
let clientGeneratorOutput = applicationOutput @@ "client.js"

let webBuildPath = buildDir @@ "_PublishedWebsites" @@ serverAppName

let browserify = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) @@ "npm" @@ "browserify.cmd"

Target "ClientDev" DoNothing
Target "ServerDev" DoNothing

Target "Clean" (fun _ -> CleanDir buildDir
                         DeleteDir buildDir)

Target "BuildServer" (fun _ ->
    RestorePackages()
    !! (serverAppName @@ serverAppProj)
    |> MSBuildRelease buildDir "Build"
    |> Log "Build-Output: "
)

Target "BuildClient" (fun _ ->
    RestorePackages()
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
            info.WorkingDirectory <- applicationOutput
            info.Arguments <- "client.js > app.js -r material-ui") System.TimeSpan.MaxValue
    if result <> 0 then failwithf "Error during running ClientGenerator "
)

Target "CopyClientToBuildDir" (fun _ ->
    CopyRecursive applicationOutput  webBuildPath true
    |> Log "Files copied: "
)

Target "Deploy" (fun _ ->
    DeleteDir (applicationOutput @@ "bin" )
    CopyRecursive webBuildPath applicationOutput true
    |> Log "Files copied: "
    System.Diagnostics.Process.Start("http://localhost:81/index.html") |> ignore
)

"Clean"
   ==> "BuildServer"
   ==> "Deploy"
   ==> "ServerDev"

"BuildClient"
  ==> "Browserify"
  ==> "ClientDev"
  ==> "CopyClientToBuildDir"
  ==> "Deploy"

RunTargetOrDefault "Deploy"
