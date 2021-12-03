open System.IO

type Rating =
| OXIGEN
| CO2

let getRows (lines: string array)=
    lines.Length

let countFilteredBy (f : ('a -> bool)) (array : 'a[]) : int =
    Array.fold
        (fun acc item -> if f item
                         then acc + 1
                         else acc)
        0 array

let toArray2D (lines: string array) =
    Array2D.init lines.Length lines.[0].Length (fun row column -> lines.[row].[column]) 

let transpose (matrix: char[,]) =
    Array2D.init (matrix |> Array2D.length2) (matrix |> Array2D.length1) (fun r c -> matrix.[c,r])

let toDecimal (binary: seq<char>) =
    int(
        binary
        |> Seq.rev 
        |> Seq.mapi(fun i v -> (2.0 ** i) * if v = '1' then 1.0 else 0.0) 
        |> Seq.sum
    )

let getRating rating =
    let mutable lines = File.ReadAllLines "./input.txt"
    let columns = lines[0].Length

    for index in 0 .. columns - 1 do
        if lines.Length > 1 then
            let matrix = lines |> toArray2D |> transpose
            let numberOfOne = matrix[index, *] |> countFilteredBy(fun x -> x = '1')
            let numberOfZero = matrix[index, *] |> countFilteredBy(fun x -> x = '0')
            let discriminator = 
                match rating with
                | OXIGEN -> if numberOfOne >= numberOfZero then '1' else '0'
                | CO2 -> if numberOfOne >= numberOfZero then '0' else '1'
            lines <- Array.filter (fun x -> x[index] = discriminator) lines
    lines[0] |> Seq.toArray |> toDecimal

let oxigenRating = getRating OXIGEN
let co2Rating = getRating CO2

oxigenRating * co2Rating