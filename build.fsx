#r "packages/FAKE/tools/FakeLib.dll"
#r "packages/FAKE.IIS/tools/Fake.IIS.dll"
#r "Microsoft.Web.Administration"

open Fake
open Fake.IISHelper
open Fake.AssemblyInfoFile

let buildDir = "./build"
let targetPath =  @"c:\inetpub\wwwroot\RethinkDBDemo"
let serverAppName = "RethinkDB.Demo.Server"
let serverAppProj = "RethinkDB.Demo.Server.fsproj"
let webBuildPath = buildDir @@ "_PublishedWebsites" @@ serverAppName

Target "Clean" (fun _ -> CleanDir buildDir)

Target "BuildServer" (fun _ ->
    RestorePackages()
    !! ("." @@ serverAppName @@ serverAppProj)
    |> MSBuildRelease buildDir "Build"
    |> Log "Build-Output: "
)

Target "Deploy" (fun _ ->
    let siteName = "RethinkDBDemo"
    let appPool = "RethinkDBDemo.appPool"
    let port = ":81:"
    CleanDir targetPath

    CopyRecursive webBuildPath targetPath true
    |> Log "Files copied: "
    (IIS
        (Site siteName "http" port @"C:\inetpub\wwwroot" appPool)
        (ApplicationPool appPool true "v4.0")
        (Some(Application "" targetPath)))
    System.Diagnostics.Process.Start("http://localhost:81/") |> ignore
)

"Clean"
  ==> "BuildServer"
  ==> "Deploy"

RunTargetOrDefault "Deploy"
