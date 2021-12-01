open System
open System.Net
open System.Windows.Forms

(* ORIGINAL *)
//let webClient = new WebClient()
//let fsharpOrg = webClient.DownloadString(Uri "http://fsharp.org")
//let browser = new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill, DocumentText = fsharpOrg)
//let form = new Form(Text = "Hello from F#!")
//form.Controls.Add browser
//form.Show()

(* REFACTORED *)
let navigate (url) = 

    let downloadContent(url) =
        let webClient = new WebClient() 
        webClient.DownloadString(Uri url)
    
    let loadContentInTheBrowser content =
        new WebBrowser(ScriptErrorsSuppressed = true, 
        Dock = DockStyle.Fill,
        DocumentText = content)

    let show browser =
        let form = new Form(Text = "Hello from F#!")    
        form.Controls.Add browser
        form.Show()

    url
        |> downloadContent
        |> loadContentInTheBrowser
        |> show

navigate "http://fsharp.org"