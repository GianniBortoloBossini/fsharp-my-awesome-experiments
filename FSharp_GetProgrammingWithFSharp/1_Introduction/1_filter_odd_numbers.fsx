(* F# *)
//let getOddnumber n = n % 2 <> 0
//[1..100] |> Seq.filter getOddnumber |> printfn "%A"

[1..100] |> Seq.filter (fun x -> x % 2 <> 0) |> printfn "%A"
    



(* C# *)
// Console.Writeline(Enumerate.Range(1, 100).Where(n => n % 2 != 0));