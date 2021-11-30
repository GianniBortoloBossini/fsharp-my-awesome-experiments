type ContactMethod =
| Phone of int
| Email of string

type UserId = { Value: int }

type User = {
    Id: UserId
    Name: string
    Contact: ContactMethod
}

let user1 = {
    Id = { Value = 1 }
    Name = "Gianni Bossini"
    Contact = Email "gianni@bossini.it"
}

let user2 = {
    Id = { Value = 2 }
    Name = "Silvia Casella"
    Contact = Phone 340_9678
}

let user1Id = user1.Id.Value