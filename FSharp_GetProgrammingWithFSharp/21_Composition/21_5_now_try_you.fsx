type Disk =
| SSD
| MMC of Pins:int
| HD of RPM : int * Platters:int
| USB

let describe disk = 
    match disk with
    | SSD -> "I'm a newfangled SSD."
    | MMC(Pins=1) -> "I have only 1 pin."
    | MMC(pins) when pins < 5 -> "I'm an MMC with a few pins."
    | MMC(pins) -> sprintf "I'm an MMC with %d pins." pins
    | HD(5400, _) -> "I'm a slow hard disk."
    | HD(_, 7) -> "I have 7 spindles!"
    | HD(_, _) -> "I'm a hard disk"
    | _ -> "Unknown device"

let mutable disk = SSD
printfn "%s" <| describe disk

disk <- MMC(Pins=1)
printfn "%s" <| describe disk

disk <- MMC(Pins=4)
printfn "%s" <| describe disk

disk <- MMC(Pins=5)
printfn "%s" <| describe disk

disk <- HD(RPM=5400,Platters=9)
printfn "%s" <| describe disk

disk <- HD(RPM=12000,Platters=7)
printfn "%s" <| describe disk

disk <- HD(RPM=12000,Platters=8)
printfn "%s" <| describe disk

disk <- USB
printfn "%s" <| describe disk