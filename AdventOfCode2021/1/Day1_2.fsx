open System.IO

let filePath = "./input.txt"
let readLines filePath = File.ReadLines(filePath)

let mutable previousDepth = 0
let mutable count = 0
let mutable cycles = 0

let isIncreased currentDepthSlice =
    let currentDepth = currentDepthSlice |> Seq.reduce(fun x y -> (int(x) + int(y)).ToString())
    let increased = cycles > 0 && int(currentDepth) > previousDepth
    cycles <- cycles + 1
    previousDepth <- int(currentDepth)
    increased

filePath 
|> readLines  
|> Seq.windowed 3 
|> Seq.iter(fun x -> count <- count + (if isIncreased(x) = true then 1 else 0))


printfn  "%d" count