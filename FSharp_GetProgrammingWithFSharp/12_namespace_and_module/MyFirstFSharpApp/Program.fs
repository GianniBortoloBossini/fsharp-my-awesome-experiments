// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Domain
open Operations

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let gianni = {
        FirstName = "Gianni"
        LastName = "Bossini"
        Age = 41
    }    

    let printInitials s =
        printfn "%s" s

    gianni
    |> getInitials
    |> printInitials

    printfn "%b" <| isOlderThan gianni 78
    

    0 // return an integer exit code