#r "packages/FAKE/tools/FakeLib.dll"
#r "packages/FAKE.IIS/tools/Fake.IIS.dll"
#r "Microsoft.Web.Administration"

open Fake
open Fake.IISHelper
open Fake.AssemblyInfoFile



let buildDir = "./build"
let releaseDir = "./release"
let applicationOutput = "RethinkDB.Demo.App"
let targetPath =  @"c:\inetpub\wwwroot\RethinkDBDemo"

let serverAppName = "RethinkDB.Demo.Server"
let serverAppProj = "RethinkDB.Demo.Server.fsproj"

let clientGeneratorName = "RethinkDB.Demo.Client"
let clientGeneratorProj = "RethinkDB.Demo.Client.fsproj"
let clientGeneratorExe = buildDir @@ "RethinkDB.Demo.Client.exe"
let clientGeneratorOutput = applicationOutput @@ "app" @@ "app.js"


let webBuildPath = buildDir @@ "_PublishedWebsites" @@ serverAppName

Target "Clean" (fun _ -> CleanDir buildDir)

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

Target "ConfigIIS" (fun _ ->
    let siteName = "RethinkDBDemo"
    let appPool = "RethinkDBDemo.appPool"
    let port = ":81:"

    (IIS
        (Site siteName "http" port @"C:\inetpub\wwwroot" appPool)
        (ApplicationPool appPool true "v4.0")
        (Some(Application "/" targetPath)))
)

Target "Deploy" (fun _ ->
    CleanDir targetPath
    CopyRecursive webBuildPath targetPath true
    |> Log "Files copied: "
    System.Diagnostics.Process.Start("http://localhost:81/") |> ignore
)

"Clean"
  ==> "BuildServer"
  ==> "BuildClient"
  =?> ("ConfigIIS", hasBuildParam "ConfigIIS")
  ==> "Deploy"

RunTargetOrDefault "Deploy"
