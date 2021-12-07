open System.IO

type Population = {
    Age: uint64
    Recurrence: uint64
}

let mutable currentPopulation: uint64[] = [| 0UL;0UL;0UL;0UL;0UL;0UL;0UL;0UL;0UL|]

let timers =
    File.ReadAllLines("./lanternfishes.txt")
    |> Seq.map(fun x -> x.Split(","))
    |> Seq.map(fun x -> seq {for i in x do yield uint64(i)})
    |> Seq.reduce(fun acc elem -> Seq.append acc elem)
    |> Seq.groupBy(fun i -> i)
    |> Seq.map(fun (elem, items) -> { Age = elem; Recurrence = uint64(Seq.length items) } )

for l in timers do
    currentPopulation[int(l.Age)] <- l.Recurrence

let mutable next = [| 0UL;0UL;0UL;0UL;0UL;0UL;0UL;0UL;0UL|]
for i = 1 to 256 do
    next <- [| 0UL;0UL;0UL;0UL;0UL;0UL;0UL;0UL;0UL|]
    for a = 0 to 8 do
        if a = 0 then
            next[6] <- currentPopulation[a]
            next[8] <- currentPopulation[a]
        elif a = 7 then
            next[a-1] <- next[6] + currentPopulation[a]
        else 
            next[a-1] <- currentPopulation[a]
    currentPopulation <- next
    printfn "%A" <| currentPopulation

Array.sum next