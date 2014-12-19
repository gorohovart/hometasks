//Artem Gorokhov (c) 2013
//Hexic check

module main

open hexic
open System

let main =
    printfn ("Input size of the field: ")
    let size = Convert.ToInt32(Console.ReadLine())
    printfn ("Input number of moves: ")
    let moveNum = Convert.ToInt32(Console.ReadLine())

    let hexic = new Hexic(size)
    let mutable sum = 0
    for i in 1 .. moveNum do
        printfn "State %A:" i
        hexic.printField()
        sum <- sum + hexic.doMove()
        
    printf ("Your score is: %A\n") sum