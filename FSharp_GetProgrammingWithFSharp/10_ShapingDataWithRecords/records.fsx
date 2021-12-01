type Address = 
    {
        Street: string
        Town: string
        City: string
    }
type Customer = 
    {
        Forename: string
        Surname: string
        Age: int
        Address: Address
        EmailAddress: string
    }

// Dichiarazione multiline di un record
let customer = 
    {
        Forename = "Gianni"
        Surname = "Bossini"
        Age = 41
        EmailAddress = "gianni.bossini@codiceplastico.com"
        Address = {
            Street = "Piazza Diaz 9"
            City = "Lumezzane"
            Town = "Brescia"
    }
}

// Dichiarazione inline di un record
type SimpleCustomer =
    {
        Name: string
        Age: int
    }
let simpleCustomer = {Name = "Gianni Bossini"; Age = 41}

let nextYearCustomer = {  
    simpleCustomer 
        with 
            Age = 42 
    }

type Person = 
    {
        Name: string
        Age: int
    }

let isStessaPersona p1 p2 =
    p1 = p2

let persona1 = {Name = "Giancarlo"; Age = 34}
let persona2 = {Name = "Giancarlo"; Age = 34}

printfn "Stessa persona? %b" <| isStessaPersona persona1 persona2

let persona3 = {Name = "Giancarlo"; Age = 34}
let persona4 = {Name = "Giancarlo"; Age = 32}

printfn "Stessa persona? %b" <| isStessaPersona persona3 persona4






type ExternalProgram =
    {
        Name1 : string   
    }
type InternalProgram (name2, name3) =
    let mutable name2 = name2
    let mutable name3 = name3
    
    member val Name2 = name2
    member x.Name3 with get() = name3 and set(value) = name3 <- value

let ext = { Name1 = "ciao" }
ext
let mutable int = InternalProgram("ciao", "bye")
int.Name2
// int.Name2 <- "hello" // NON COMPILA!!!
// printfn "Poi: %s" int.Name2

int.Name3 <- "aaaa"
printfn "After: %s" int.Name3


type ListInfoObj(lst) =
    let count = Array.length lst

    member __.Count = count

let infoObj = ListInfoObj(List.toArray [1..10])
infoObj.Count

type ListInfoRecord = {
    Count1: int
}
let reco = 
    { 
        Count1 = (List.toArray [1..10]).Length
    }
reco.Count1