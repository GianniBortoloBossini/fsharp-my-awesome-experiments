open System.IO

let toArray2D (lines: string array) =
    Array2D.init lines.Length lines.[0].Length (fun row column -> lines.[row].[column]) 

let transpose (matrix: char[,]) =
    Array2D.init (matrix |> Array2D.length2) (matrix |> Array2D.length1) (fun r c -> matrix.[c,r])

let toSeq (matrix: char[,]) =
    seq { for i in 0 .. ((matrix |> Array2D.length1) - 1) do yield matrix[i, *] }

let countFilteredBy (f : ('a -> bool)) (array : 'a[]) : int =
    Array.fold
        (fun acc item -> if f item
                         then acc + 1
                         else acc)
        0 array

let toDecimal (binary: seq<char>) =
    int(
        binary
        |> Seq.rev 
        |> Seq.mapi(fun i v -> (2.0 ** i) * if v = '1' then 1.0 else 0.0) 
        |> Seq.sum
    )

let calculateIndices (gamma: seq<char>) =
    let epsilon = Seq.map (fun x -> if x = '1' then '0' else '1') gamma
    let gammaResult = gamma |> toDecimal
    let epsilonResult = epsilon |> toDecimal

    gammaResult * epsilonResult

let result =
    File.ReadAllLines "./input.txt"
    |> toArray2D
    |> transpose
    |> toSeq
    |> Seq.map(fun x -> if (x |> countFilteredBy (fun x -> x = '1')) > (x |> countFilteredBy (fun x -> x = '0')) then '1' else '0')
    |> calculateIndices 

printfn "%d" <| result