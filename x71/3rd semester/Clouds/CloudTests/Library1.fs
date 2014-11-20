module CloudTests.Tests
 
open NUnit.Framework
open NSubstitute
open FsCheck
open Clouds
open FsUnit

let test (isShining : bool, speed : int, dayLight : DayLightType, expectedCreature : CreatureType, expectedCourier : CourierType) =
    let luminary = Substitute.For<ILuminary>()
    let wind = Substitute.For<IWind>()
    let dayLightMock = Substitute.For<IDayLight>()
    let magic = Substitute.For<IMagic>()
    let courier = Substitute.For<ICourier>()

    ignore <| luminary.IsShining.Returns(isShining) 
    ignore <| wind.Speed.Returns(speed)
    ignore <| dayLightMock.Current.Returns(dayLight)
    ignore <| magic.CallDaemon().Returns(courier)
    ignore <| magic.CallStork().Returns(courier)

    let creature = (new Cloud(dayLightMock, luminary, wind, magic)).Create()

    (creature.getType) |> should equal expectedCreature
    if expectedCourier = Stork then ignore <| magic.Received().CallStork()
    else ignore <| magic.Received().CallDaemon()
    
    courier.Received().GiveBaby(creature)

[<Test>] 
let ``test 1`` () =  test (false, 1, DayLightType.Morning, CreatureType.Piglet, Stork)
[<Test>] 
let ``test 2`` () =  test (false, 1, DayLightType.Evening, CreatureType.Kitten, Daemon)
[<Test>] 
let ``test 3`` () =  test (false, 6, DayLightType.Morning, CreatureType.Piglet, Stork)
[<Test>] 
let ``test 4`` () =  test (false, 4, DayLightType.Night, CreatureType.Bat, Daemon)
[<Test>] 
let ``test 5`` () =  test (false, 10, DayLightType.Morning, CreatureType.Balloon, Stork)
[<Test>] 
let ``test 6`` () =  test (false, 6, DayLightType.Noon, CreatureType.Bearcub, Daemon)
[<Test>] 
let ``test 7`` () =  test (false, 0, DayLightType.Noon, CreatureType.Hedgehog, Stork)
[<Test>] 
let ``test 8`` () =  test (false, 0, DayLightType.Night, CreatureType.Hedgehog, Daemon)
[<Test>] 
let ``test 9`` () =  test (true, 1, DayLightType.Night, CreatureType.Piglet, Daemon)
[<Test>] 
let ``test 10`` () =  test (true, 1, DayLightType.Noon, CreatureType.Hedgehog, Daemon)
[<Test>] 
let ``test 11`` () =  test (true, 0, DayLightType.Evening, CreatureType.Kitten, Stork)
[<Test>] 
let ``test 12`` () =  test (true, 0, DayLightType.Night, CreatureType.Bat, Daemon)
[<Test>] 
let ``test 13`` () =  test (true, 0, DayLightType.Morning, CreatureType.Puppy, Stork)
[<Test>] 
let ``test 14`` () =  test (true, 10, DayLightType.Evening, CreatureType.Balloon, Stork)
[<Test>] 
let ``test 15`` () =  test (true, 1, DayLightType.Morning, CreatureType.Piglet, Stork)
[<Test>] 
let ``test 16`` () =  test (true, 6, DayLightType.Evening, CreatureType.Puppy, Stork)
[<Test>] 
let ``test 17`` () =  test (true, 9, DayLightType.Night, CreatureType.Bat, Daemon)
