open System.IO
open System

let positions = 
    File.ReadAllLines("./positions.txt").[0].Split(",")
    |> Seq.map (fun x -> int(x)) 

let min = positions |> Seq.min
let max = positions |> Seq.max

printfn "{%A}" <| positions
printfn "{%d}" <| min
printfn "{%d}" <| max

[ min .. max ]   
    |> Seq.map(fun x -> 
                positions
                |> Seq.map(fun p -> 
                               let steps = Math.Abs(p - x)
                               let cost = [1 .. steps] |> Seq.sum
                               cost
                           )
                |> Seq.sum)
    |> Seq.min