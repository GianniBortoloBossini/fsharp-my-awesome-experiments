type Disk =
| HardDisk of RPM : int * Platters:int
| SolidState 
| MMC of NumberOfPins:int

let myHardDisk = HardDisk(RPM = 10000, Platters = 7)
let myHardDiskShort = HardDisk(250, 7)
let args = 300, 6
let myHardDiskTupled = HardDisk args
let mySsd = SolidState

let seek disk =
    match disk with 
    | HardDisk _ -> "Seeking loudy at a reasonable speed!"
    | MMC _ -> "Seeking quietly but slow"
    | SolidState _ -> "Already found it!"

mySsd
|> seek
|> printfn "%s"

printfn "%s" <| seek myHardDisk

