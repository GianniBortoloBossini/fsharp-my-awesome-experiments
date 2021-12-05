open System
open System.IO

let sequenceOfNumbers = File.ReadAllText("./sequence.txt").Split(",")

let countFilteredBy (f : ('a -> bool)) (array : 'a[]) : int =
    Array.fold
        (fun acc item -> if f item
                         then acc + 1
                         else acc)
        0 array

let toArray2D (lines: int[] array) =
    Array2D.init lines.Length lines.[0].Length (fun row column -> lines.[row].[column]) 

let toArray (arr: 'T [,]) = 
    arr |> Seq.cast<'T> |> Seq.toArray

type Board = {
    mutable Win: bool
    Numbers: int[,]
}

let rec createBoard (head: int array) (tail: int[] array) (acc: int[] ResizeArray) (result: Board ResizeArray) =
    if (head = [||] || tail = [||]) && acc.Count > 0 then 
        if head <> [||] then acc.Add(head)
        let tmp = acc.ToArray()
        let tmpMatrix = toArray2D tmp
        result.Add({ Win = false ; Numbers = tmpMatrix })
        acc.Clear()
        if tail = [||] then result else createBoard tail.[0] tail.[1..] acc result
    else 
        acc.Add(head)
        createBoard tail.[0] tail.[1..] acc result

let boards =
    File.ReadAllLines("./boards.txt")
    |> Array.map(fun line -> line.Replace("  ", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries))
    |> Array.map(fun row -> Array.map(fun elem -> int(elem)) row)

let emptyAcc = ResizeArray<int[]>()
let emptyResult = ResizeArray<Board>()
let matrixBoards = createBoard boards.[0] boards.[1..] emptyAcc emptyResult

let mutable lastNumber = -1
let mutable sumUnmarked = 0
for number in sequenceOfNumbers do
    for m in matrixBoards do
        if not m.Win then
            lastNumber <- int(number)
            let rowNumber = (Array2D.length1 m.Numbers)
            let colNumber = (Array2D.length2 m.Numbers)
            for r in 0 .. rowNumber - 1 do
                for c in 0 .. colNumber - 1 do
                    if not m.Win && m.Numbers[r,c] = int(number) then 
                        m.Numbers[r,c] <- -1        
                    m.Win <- m.Win || colNumber = (countFilteredBy (fun i -> i = -1) m.Numbers[*,c])
                m.Win <- m.Win || rowNumber = (countFilteredBy (fun i -> i = -1) m.Numbers[r,*])
            
            if m.Win = true then            
                sumUnmarked <- 0        
                for r in 0 .. rowNumber - 1 do
                    for c in 0 .. colNumber - 1 do
                        if m.Numbers[r,c] <> -1 then 
                            sumUnmarked <- sumUnmarked + m.Numbers[r,c]

lastNumber * sumUnmarked