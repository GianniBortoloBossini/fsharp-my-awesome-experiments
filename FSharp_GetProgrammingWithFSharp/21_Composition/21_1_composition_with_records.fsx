type Disk = { SizeGb : int }
type Computer = { Manufacturer : string; Disks : Disk list }

let myPc = 
    {
        Manufacturer = "Asus"   
        Disks = [
            { SizeGb = 100 }
            { SizeGb = 200 }
            { SizeGb = 300 }
        ]
    }

printfn "%s" <| $"My {myPc.Manufacturer} with {myPc.Disks.Length} disks."