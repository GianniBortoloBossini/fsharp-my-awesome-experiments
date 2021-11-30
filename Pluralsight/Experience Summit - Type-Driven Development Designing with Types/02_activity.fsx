open System

type RectangleType = {
    Width: float 
    Height: float
}

type CircleType = {
    Radius: float
}

type SquareType = {
    Side: float
}

type Shape = 
| Rectangle of RectangleType
| Circle of CircleType
| Square of SquareType


let calculatetArea (s: Shape): float =
    match s with
    | Rectangle r -> r.Height * r.Width
    | Circle c -> (c.Radius ** 2.0) * Math.PI
    | _ -> failwith "not implemented"

Circle({Radius = 3.6})
|> calculatetArea
|> printfn "Circle area: %f"

Rectangle({Height = 1.7; Width = 4.2})
|> calculatetArea
|> printfn "Rectangle area: %f"