open System.IO

let compute (command: string array) =
    if command.[0] = "forward" then (int(command.[1]), 0)
    elif command.[0] = "down" then (0, int(command.[1]))
    elif command.[0] = "up" then (0, int(command.[1]) * -1)
    else failwith "Not implemented command"

let multiply (ff, fd) =
    ff * fd

File.ReadAllLines("./input.txt")
|> Seq.map(fun line -> compute (line.Split ' '))
|> Seq.reduce(fun (fp, dp) (fc, dc) -> (fp + fc, dp + dc))
|> multiply
|> printfn "%d"