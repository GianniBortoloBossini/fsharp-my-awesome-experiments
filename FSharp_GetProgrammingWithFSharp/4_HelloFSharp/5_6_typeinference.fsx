let greet name surname =
    sprintf "Hello %s %s" name surname
printfn "%s" <| greet "Gianni" "Bossini"

let addExplicit (a: int, b:int) = a + b
printfn "%d" <| addExplicit (4, 5)

let addInferenced a b = a + b
printfn "%d" <| addInferenced 4 5

// let getLength name = sprintf "Name is %d letters." name.Length // <- non compila perchè il compilatore non riesce a desumere il ripo del parametro "name"
let getLength (name:string) = sprintf "Name is %d letters." name.Length
let getLength (name) = sprintf "Name is %d letters." <| String.length name
let foo(name) = "Hello! " + getLength(name)





open System.Collections.Generic

let numbers = List<_>() // <- F# effettua la type inference anche sui generics, per cui posso indicare _, oppure... 
numbers.Add(10)
numbers.Add(20)
let otherNumbers = List() // <- ... omettere del tutto il tipo!!!
otherNumbers.Add(10)
otherNumbers.Add(20)




let createList first second =
    let output = List()
    output.Add(first)
    output.Add(second)
    output

createList 1 7
// createList 1 "a" // <- non compila perchè i tipi non sono uguali!