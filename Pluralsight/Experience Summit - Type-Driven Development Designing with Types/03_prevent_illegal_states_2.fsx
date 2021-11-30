type PhoneType = {
    PhoneNumber: int
}

type EmailType = {
    EmailAddress: string
}

type ContactMethodType = 
| Phone of PhoneType
| Email of EmailType
| PhoneAndEmail of {| P: PhoneType; E: EmailType |}

type User = {
    Name: string
    ContactMethod: ContactMethodType
}

let userWithPhone = {
    Name = "Gianni"
    ContactMethod = Phone { PhoneNumber = 222_111 }
}

let userWithEmail = {
    Name = "Gianni"
    ContactMethod = Email { EmailAddress = "a@a.it" }
}

let userWithBoth = {
    Name = "Gianni"
    ContactMethod = PhoneAndEmail {| E = { EmailAddress = "a@a.it" }; P = { PhoneNumber = 111_111 } |}
}

let printContactMethod contactMethod =
    match contactMethod with
    | Phone p -> sprintf $"phone number ({p.PhoneNumber})"
    | Email e -> sprintf $"email ({e.EmailAddress})"
    | PhoneAndEmail pe -> sprintf $"phone number ({pe.P.PhoneNumber}) and email ({pe.E.EmailAddress})"

printfn "%s has got %s" userWithPhone.Name <| printContactMethod(userWithPhone.ContactMethod)
printfn "%s has got %s" userWithEmail.Name <| printContactMethod(userWithEmail.ContactMethod)
printfn "%s has got %s" userWithBoth.Name <|  printContactMethod(userWithBoth.ContactMethod)
