open System.IO

let filePath = "./input.txt"
let readLines filePath = File.ReadLines(filePath)

let mutable previousDepth = 0
let mutable count = 0
let mutable cycles = 0

let isIncreased currentDepth =
    let increased = cycles > 0 && currentDepth > previousDepth
    cycles <- cycles + 1
    previousDepth <- currentDepth
    increased

filePath 
|> readLines  
|> Seq.iter(fun x -> count <- count + (if isIncreased(int(x)) = true then 1 else 0))

printfn  "%d" count