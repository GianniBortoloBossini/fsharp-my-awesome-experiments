open System.IO

type Direction =
| HORIZONTAL
| VERTICAL
| DIAGONAL

type Point = { X: int; Y: int}

type Move = { 
    Start: Point
    Stop: Point } with
    member this.Direction =
        if this.Start.X = this.Stop.X then Direction.HORIZONTAL
        elif this.Start.Y = this.Stop.Y then Direction.VERTICAL
        else Direction.DIAGONAL

let moves =
    File.ReadAllLines("./moves.txt")
    |> Seq.map(fun m -> m.Split(" -> "))
    |> Seq.map(fun m -> {
        Start = { X = int(m[0].Split(",")[0]); Y = int(m[0].Split(",")[1]) }
        Stop = { X = int(m[1].Split(",")[0]); Y = int(m[1].Split(",")[1]) } })

let xMax = 
    moves
    |> Seq.map(fun m -> if m.Start.X > m.Stop.X then m.Start.X else m.Stop.X)
    |> Seq.max

let yMax = 
    moves
    |> Seq.map(fun m -> if m.Start.Y > m.Stop.Y then m.Start.Y else m.Stop.Y)
    |> Seq.max

let field = Array2D.init (xMax + 1) (yMax + 1) (fun r c -> 0)

let rec diagonal (yhead: int) (ytail: int[]) (xhead: int) (xtail: int[]) =
    field[xhead, yhead] <- (field[xhead, yhead] + 1)
    if (Array.length xtail) > 0 then
        diagonal ytail.[0] ytail[1..] xtail.[0] xtail[1..]

for m in moves do
    if m.Direction = Direction.HORIZONTAL then
        if m.Start.Y >= m.Stop.Y then
            for i = m.Start.Y downto m.Stop.Y do
                field[m.Start.X, i] <- (field[m.Start.X, i] + 1)
        else
            for i = m.Start.Y to m.Stop.Y do
                field[m.Start.X, i] <- (field[m.Start.X, i] + 1)
    elif m.Direction = Direction.VERTICAL then
        if m.Start.X >= m.Stop.X then 
            for i = m.Start.X downto m.Stop.X do
                field.[i, m.Start.Y] <- (field[i, m.Start.Y] + 1)
        else 
            for i = m.Start.X to m.Stop.X do
                field.[i, m.Start.Y] <- (field[i, m.Start.Y] + 1)    
    else
        let mutable xpositions = Seq.empty
        let mutable ypositions = Seq.empty

        if m.Start.X >= m.Stop.X then 
            xpositions <- seq {for x = m.Start.X downto m.Stop.X do yield x}
        else 
            xpositions <- seq {for x = m.Start.X to m.Stop.X do yield x}

        if m.Start.Y >= m.Stop.Y then
            ypositions <- seq {for y = m.Start.Y downto m.Stop.Y do yield y}
        else
            ypositions <- seq {for y = m.Start.Y to m.Stop.Y do yield y}
        
        diagonal (Seq.toArray ypositions).[0] (Seq.toArray ypositions).[1..] (Seq.toArray xpositions).[0] (Seq.toArray xpositions).[1..]

let mutable result = 0
for r in 0 .. (Array2D.length1 field) - 1 do
    for c in 0 .. (Array2D.length2 field) - 1 do
        result <- result + if field[r, c] >= 2 then 1 else 0