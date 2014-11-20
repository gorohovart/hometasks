module Clouds


let private rnd = new System.Random()

type DayLightType = 
    | Morning
    | Noon
    | Evening
    | Night

type CreatureType = 
    | Puppy
    | Kitten
    | Hedgehog
    | Bearcub
    | Piglet
    | Bat
    | Balloon

type CourierType = 
    | Stork
    | Daemon

type Creature (creature : CreatureType) =
    member x.getType() = creature //?

type IDayLight =
    abstract Current : DayLightType

type ILuminary =
    abstract IsShining : bool

type IWind =
    abstract Speed : int

type ICourier =
    abstract member GiveBaby : Creature -> Unit

type IMagic =
    abstract member CallStork : Unit -> ICourier
    abstract member CallDaemon : Unit -> ICourier

type Daylight () = 
    interface IDayLight with
        member x.Current = 
            match rnd.Next(4) with 
            | 0 -> DayLightType.Morning
            | 1 -> DayLightType.Noon
            | 2 -> DayLightType.Evening
            | 3 -> DayLightType.Night
            | _ -> failwith "wat??"

type Luminary () = 
    interface ILuminary with
        member x.IsShining = rnd.Next(2) = 0

type Wind () = 
    interface IWind with
        member x.Speed = rnd.Next(11)

type Courier (t : CourierType) = 
    interface ICourier with
        member x.GiveBaby _ = ()  //???

type Magic () = 
    interface IMagic with  
        member x.CallStork () = new Courier(CourierType.Stork) :> ICourier
        member x.CallDaemon () = new Courier(CourierType.Daemon) :> ICourier

type Cloud (dayLight: IDayLight, luminary : ILuminary, wind: IWind, magic: IMagic) =
    member private x.InternalCreate() =
        if luminary.IsShining then
            match dayLight.Current with
            | DayLightType.Morning -> if wind.Speed = 0 then    CreatureType.Hedgehog, magic.CallStork()
                                      elif wind.Speed < 5 then  CreatureType.Kitten,   magic.CallStork()
                                      elif wind.Speed < 10 then CreatureType.Piglet,   magic.CallStork()
                                      else                      CreatureType.Balloon,  magic.CallDaemon()
            | DayLightType.Noon    -> if wind.Speed = 0 then    CreatureType.Hedgehog, magic.CallStork()
                                      elif wind.Speed < 5 then  CreatureType.Kitten,   magic.CallStork()
                                      elif wind.Speed < 10 then CreatureType.Bearcub,  magic.CallStork()
                                      else                      CreatureType.Balloon,  magic.CallDaemon()
            | DayLightType.Evening -> if wind.Speed = 0 then    CreatureType.Hedgehog, magic.CallStork()
                                      elif wind.Speed < 5 then  CreatureType.Kitten,   magic.CallDaemon()
                                      elif wind.Speed < 10 then CreatureType.Piglet,   magic.CallStork()
                                      else                      CreatureType.Balloon,  magic.CallDaemon()
            | DayLightType.Night   -> if wind.Speed = 0 then    CreatureType.Hedgehog, magic.CallDaemon()
                                      elif wind.Speed < 10 then CreatureType.Bat,      magic.CallDaemon()
                                      else                      CreatureType.Balloon,  magic.CallDaemon()
        else
            match dayLight.Current with
            | DayLightType.Morning -> if wind.Speed = 0 then    CreatureType.Puppy,    magic.CallStork()
                                      elif wind.Speed < 6 then  CreatureType.Piglet,   magic.CallStork()
                                      elif wind.Speed < 10 then CreatureType.Puppy,    magic.CallStork()
                                      else                      CreatureType.Balloon,  magic.CallStork()
            | DayLightType.Noon    -> if wind.Speed = 0 then    CreatureType.Kitten,   magic.CallStork()
                                      elif wind.Speed < 6 then  CreatureType.Hedgehog, magic.CallDaemon()
                                      elif wind.Speed < 10 then CreatureType.Puppy,    magic.CallStork()
                                      else                      CreatureType.Balloon,  magic.CallStork()
            | DayLightType.Evening -> if wind.Speed = 0 then    CreatureType.Kitten,   magic.CallStork()
                                      elif wind.Speed < 6 then  CreatureType.Hedgehog, magic.CallDaemon()
                                      elif wind.Speed < 10 then CreatureType.Puppy,    magic.CallStork()
                                      else                      CreatureType.Balloon,  magic.CallStork()
            | DayLightType.Night   -> if wind.Speed = 0 then    CreatureType.Bat,      magic.CallDaemon()
                                      elif wind.Speed < 6 then  CreatureType.Piglet,   magic.CallDaemon()
                                      elif wind.Speed < 10 then CreatureType.Bat,      magic.CallStork()
                                      else                      CreatureType.Balloon,  magic.CallStork()
 
    member x.Create() =
      let creatureType, cour = x.InternalCreate()
      let creature = new Creature(creatureType)   
      cour.GiveBaby(creature)
      creature