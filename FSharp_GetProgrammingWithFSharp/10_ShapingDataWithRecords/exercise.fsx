(*
Let’s practically explore some of these features of records:
1 Define a record type, such as the Address type shown earlier.
2 Create two instances of the record that have the same values.
3 Compare the two objects by using =, .Equals, and System.Object.ReferenceEquals.
4 What are the results of all of them? Why?
*)

type Address =
    {
        Street: string
        Town: string
        City: string
    }
let address1 = { Street="Piazza Diaz 9"; City="Lumezzane";Town="Brescia"}
let address2 = { Street="Piazza Diaz 9"; City="Lumezzane";Town="Brescia"}
printfn "Equals => %b" <| (address1.Equals address2)
printfn "= => %b" <| (address1 = address2)
printfn "ReferenceEquals => %b" <| (System.Object.ReferenceEquals (address1, address2))

(*
    5 Create a function that takes in a customer and, using copy-and-update syntax, sets the customer’s Age to a random number between 18 and 45.
    6 The function should then print the customer’s original and new age, before returning the updated customer record.
*)
type Person =
    {
        Name: string
        Age: int
    }
let person = { Name = "Gianni"; Age = 34 }
printf $"{person.Name} was {person.Age} years old"
let randomizePersonAge person=
    let rand = System.Random()
    { 
        person 
        with 
            Age = rand.Next(18, 45)
    }
let randomizedPersonAge = 
    person
    |> randomizePersonAge 
printfn $", but now is {randomizedPersonAge.Age} years old."