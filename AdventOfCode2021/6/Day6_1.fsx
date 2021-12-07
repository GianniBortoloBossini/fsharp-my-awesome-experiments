open System.IO

let countFilteredBy (f : ('a -> bool)) (array : 'a[]) : int =
    Array.fold
        (fun acc item -> if f item
                         then acc + 1
                         else acc)
        0 array

let timers =
    File.ReadAllLines("./lanternfishes.txt")
    |> Seq.map(fun x -> x.Split(","))
    |> Seq.map(fun x -> seq {for i in x do yield int(i)})
    |> Seq.reduce(fun acc elem -> Seq.append acc elem)
    |> Seq.toArray

let rec populate (currentPopulation: int[]) (days: int) =
    let tmpPopulation = Array.map(fun i -> i - 1) currentPopulation
    let lanternReadyToGrow = countFilteredBy (fun x -> x = -1) tmpPopulation
    let updatePopulation = Array.map(fun i -> if i = -1 then 6 else i) tmpPopulation
    if days > 0 then
        let nextPopulation = Array.append updatePopulation [| for i = 0 to (lanternReadyToGrow - 1) do 8 |]
        printfn "nextPopulation: %A" <| nextPopulation
        populate nextPopulation (days - 1)
    else
        updatePopulation

populate timers 80
|> Array.length