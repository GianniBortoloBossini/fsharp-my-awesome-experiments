type User = {
    Name: string
    Phone: string option
    Email: string option
}

let user = {
    Name = "Gianni"
    Phone = None
    Email = None
}

printfn $"User name: {user.Name}"