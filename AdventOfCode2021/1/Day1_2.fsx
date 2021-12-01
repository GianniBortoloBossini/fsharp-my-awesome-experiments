open System.IO

let filePath = "./input.txt"
let readLines filePath = File.ReadLines(filePath)

let mutable previousDepth = 0
let mutable cycles = 0

let isIncreased currentDepthSlice =
    let currentDepth = currentDepthSlice |> Seq.reduce(fun x y -> (int(x) + int(y)).ToString())
    let increased = cycles > 0 && int(currentDepth) > previousDepth
    cycles <- cycles + 1
    previousDepth <- int(currentDepth)
    increased

let count =
    filePath 
    |> readLines  
    |> Seq.windowed 3 
    |> Seq.map(fun x -> if isIncreased(x) = true then 1 else 0)
    |> Seq.sum


printfn  "%d" count