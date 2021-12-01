module Operations

open Domain

let getInitials customer =
    String.concat "" [customer.FirstName.[0].ToString(); customer.LastName.[0].ToString()]

let isOlderThan customer age =
    customer.Age > age
