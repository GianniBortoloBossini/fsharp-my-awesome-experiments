open System.IO

let filePath = "./input.txt"
let readLines filePath = File.ReadLines(filePath)

let mutable previousDepth = 0
let mutable cycles = 0

let isIncreased currentDepth =
    let increased = cycles > 0 && currentDepth > previousDepth
    cycles <- cycles + 1
    previousDepth <- currentDepth
    increased

let count =
    filePath 
    |> readLines  
    |> Seq.map(fun x -> if isIncreased(int(x)) = true then 1 else 0)
    |> Seq.sum

printfn  "%d" count