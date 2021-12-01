type Disk =
| HardDisk of RPM : int * Platters:int
| SolidState 
| MMC of NumberOfPins:int

let slowHardDisk = HardDisk(5400,5)
let spindledHardDisk = HardDisk(10000, 7)
let mmcTrivial = MMC(3)
let ssd = SolidState

let generateDescription disk =
    match disk with
    | HardDisk(5400,5) -> "Seeking very slowly!"
    | HardDisk(rpm, 7) -> sprintf "I have 7 splindles and RPM %d!" rpm
    | MMC(3) -> "I have 3 pins!"
    | _ -> "Common device"

printfn "%s" <| generateDescription slowHardDisk
printfn "%s" <| generateDescription spindledHardDisk
printfn "%s" <| generateDescription mmcTrivial
printfn "%s" <| generateDescription ssd