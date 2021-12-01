(*
    Let’s put this into practice with a simple example: driving a car. You want to be able to
    write code that allows you to drive() a car, tracking the amount of petrol (gas) used.
    Depending on the distance you drive, you should use up a different amount of petrol.
*)

// MUTABLE SCENARIO
let mutable m_petrol = 100.0
let m_drive distance =
    if distance = "far" then m_petrol <- m_petrol / 2.0
    elif distance = "medium" then m_petrol <- m_petrol - 10.0
    else m_petrol <- m_petrol - 1.0
m_drive("far")
m_drive("medium")
m_drive("short")
m_petrol

// IMMUTABLE SCENARIO
let im_drive distance im_petrol =
    if distance = "far" then im_petrol / 2.0
    elif distance = "medium" then im_petrol - 10.0
    else im_petrol - 1.0

100.0
    |> im_drive "far"
    |> im_drive "medium"
    |> im_drive "short"

(*
    Now you try
    Let’s see how to make some changes to your drive code:
    1 Instead of using a string to represent how far you’ve driven, use an integer.
    2 Instead of far, check whether the distance is more than 50.
    3 Instead of medium, check whether the distance is more than 25.
    4 If the distance is > 0, reduce petrol by 1.
    5 If the distance is 0, make no change to the petrol
*)
let num_drive num_distance gas =
    if num_distance > 50 then gas / 2.0
    elif num_distance > 25 then gas - 10.0
    else gas - 1.0

100.0
    |> num_drive 70
    |> num_drive 30
    |> num_drive 5