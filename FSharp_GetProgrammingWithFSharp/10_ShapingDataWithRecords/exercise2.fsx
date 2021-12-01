let add10To = List.map((+) 10)
let r =
    [1..10]
    |> add10To
    |> List.toArray
r




let doubleAndIncr = 
    (*) 2 >> (+) 1

let r2 =
    10
    |> doubleAndIncr





let double x =
    x * 2
let add1 x =
    x + 1

let r3 = 
    10
    |> double
    |> add1
r3

// Functions composition
// x |> (g >> f) = x |> g |> f = f (g x)
let doubleAndAdd =
    double >> add1

let r4 = 
    10
    |> doubleAndAdd
r4

let doubleAndAdd2 x =
    x
    |> double 
    |> add1

let r5 = 
    10
    |> doubleAndAdd2
r5


