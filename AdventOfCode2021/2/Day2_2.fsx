open System.IO

type Command =
| FORWARD
| UP
| DOWN

let compute (command: string array) =
    if command.[0] = "forward" then (Command.FORWARD, int(command.[1]), 0, 0)
    elif command.[0] = "down" then (Command.DOWN, 0, 0, int(command.[1]))
    elif command.[0] = "up" then (Command.UP, 0, 0, int(command.[1]) * -1)
    else failwith "Not implemented command"

let multiply (_, ff, fd, _) =
    ff * fd

File.ReadAllLines("./input.txt")
|> Seq.map(fun line -> compute (line.Split ' '))
|> Seq.reduce(fun (_, fp, dp, ap) (cc, fc, dc, ac) -> 
    match cc with
    | FORWARD -> (cc, fp + fc, dp + (fc * ap), ap + ac)
    | _ -> (cc, fp + fc, dp + dc, ap + ac))
|> multiply
|> printfn "%d"