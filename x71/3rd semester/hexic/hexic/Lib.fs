//Artem Gorokhov (c) 2013
//Hexic library

//Spent around 6 hours

module hexic

open System


type Iter(size) = 
    let mutable ax = 1
    let mutable ay = 1
    let mutable bx = 2
    let mutable by = 1
    let mutable cx = 1
    let mutable cy = 2

    let mutable currHex = Some((ax, ay), (bx, by), (cx, cy))

    member this.getCurrHex() =  match currHex with Some(x) -> x

    member iter.isCurrentHexSome() =
        match currHex with
        | Some(_) -> true
        | _ -> false

    member this.next() = 
      if currHex <> None then
        match ax with
        | Odd -> if ay = by then 
                                ay <- ay + 1
                                cx <- cx + 1
                 elif ay < size then
                                cx <- cx - 1
                                cy <- cy + 1
                                by <- by + 1
                 elif bx < size then 
                                ax <- ax + 1
                                bx <- bx + 1
                                ay <- 1
                                by <- 1
                                cx <- bx
                                cy <- 2
                 else currHex <- None
        | Even -> if ay = by then
                                cx <- cx - 1
                                by <- by + 1
                  elif by < size then
                                ay <- ay + 1
                                cx <- cx + 1
                                cy <- cy + 1
                  elif bx < size then
                                ax <- ax + 1
                                bx <- bx + 1
                                ay <- 1
                                by <- 1
                                cx <- ax
                                cy <- 2
                  else currHex <- None
      
        if currHex <> None then currHex <- Some((ax, ay), (bx, by), (cx, cy))

type Hexic(size) =
    let scoreTable = [|0; 0; 0; 3; 6; 12; 24; 48; 96; 192; 384|]
    let mutable field = Array2D.create (size + 2) (size + 2) 0
    let mutable size = size
    let colorNum = 5
    let rnd = new Random()
    
    let moveDownAndFill(field : int[,]) =
        let mutable last = size

        let moveNearest(x, y) =
            let mutable flag = true
            let mutable i = y + 1
            while (i <= size)&&(flag) do
                if field.[x, i] <> 0 then field.[x, y] <- field.[x, i]
                                          field.[x, i] <- 0
                                          flag <- false
                i <- i + 1
        
        let fillTop(x, y) = 
            for i in y .. size do
                field.[x, i] <- rnd.Next(1, colorNum + 1)

        for i in 1 .. size do
            for j in 1 .. size do
                if (field.[i, j] = 0)&&(last = size) then moveNearest(i, j)
                if (field.[i, j] = 0)&&(last = size) then last <- j
            fillTop(i, last)
            last <- size


        for i in 1 .. size do
            for j in 1 .. size do
                if field.[i, j] = 0 then raise (System.ArgumentException("zero!"))


    let explodeHex(hex, field : int[,]) = 
        match hex with
        | (ax, ay), (bx, by), (cx, cy) -> 
            field.[ax, ay] <- 0
            field.[bx, by] <- 0
            field.[cx, cy] <- 0

    let scoreAndExplodeHex(hex, field : int[,]) = 
        let mutable num = 0
        match hex with
        | (ax, ay), (bx, by), (cx, cy) -> 
            if field.[ax, ay] <> 0 then field.[ax, ay] <- 0
                                        num <- num + 1 
            if field.[bx, by] <> 0 then field.[bx, by] <- 0
                                        num <- num + 1
            if field.[cx, cy] <> 0 then field.[cx, cy] <- 0
                                        num <- num + 1
        num
    

    let isHexOneColor(hex, field : int[,]) = 
        match hex with
        | (ax, ay), (bx, by), (cx, cy) -> 
            if ((field.[ax, ay] <> 0) && (field.[ax, ay] = field.[bx, by]) && (field.[cx, cy] = field.[bx, by])) then
                true
            else
                false

    let explodeMatches(field) = 
        let mutable isRemoval = true
        let iter = new Iter(size)

        while isRemoval do
            isRemoval <- false
            while iter.isCurrentHexSome() do
                if isHexOneColor(iter.getCurrHex(), field) then explodeHex(iter.getCurrHex(), field)
                                                                isRemoval <- true
                iter.next()
            moveDownAndFill(field)
    
    let generateField() =
        for i in 0 .. size + 1 do
            for j in 0 .. size + 1 do
                if ((i = 0) || (j = 0) || (i = size + 1) || (j = size + 1)) then field.[i, j] <- 0
                else field.[i, j] <- rnd.Next(1, colorNum + 1)
        moveDownAndFill(field)
        printfn ("Field generated")
    
    let getNeighbours(hex) = 
        match hex with
        | ((ax, ay), (bx, by), (cx, cy)) ->
            match ax with
            | Odd -> if ay <> by then [((ax, ay + 1), (ax + 1, ay), (ax + 1, ay + 1));
                                       ((ax + 1, ay), (ax + 2, ay + 1), (ax + 1, ay + 1));
                                       ((ax + 1, ay), (ax + 2, ay), (ax + 2, ay + 1));
                                       ((ax + 1, ay - 1), (ax + 2, ay), (ax + 1, ay));
                                       ((ax + 1, ay - 1), (ax + 2, ay - 1), (ax + 2, ay));
                                       ((ax + 1, ay - 2), (ax + 2, ay - 1), (ax + 1, ay - 1));
                                       ((ax, ay - 1), (ax + 1, ay - 2), (ax + 1, ay - 1));
                                       ((ax, ay - 1), (ax + 1, ay - 1), (ax, ay));
                                       ((ax - 1, ay - 1), (ax, ay - 1), (ax, ay));
                                       ((ax - 1, ay - 1), (ax, ay), (ax - 1, ay));
                                       ((ax - 1, ay), (ax, ay), (ax, ay + 1));
                                       ((ax, ay), (ax + 1, ay), (ax, ay + 1))]
                     else             
                                      [((ax, ay + 1), (ax + 1, ay + 1), (ax, ay + 2));
                                       ((ax, ay + 1), (ax + 1, ay), (ax + 1, ay + 1));
                                       ((ax + 1, ay), (ax + 2, ay + 1), (ax + 1, ay + 1));
                                       ((ax + 1, ay), (ax + 2, ay), (ax + 2, ay + 1));
                                       ((ax + 1, ay - 1), (ax + 2, ay), (ax + 1, ay));
                                       ((ax, ay), (ax + 1, ay - 1), (ax + 1, ay));
                                       ((ax, ay - 1), (ax + 1, ay - 1), (ax, ay));
                                       ((ax - 1, ay - 1), (ax, ay - 1), (ax, ay));
                                       ((ax - 1, ay - 1), (ax, ay), (ax - 1, ay));
                                       ((ax - 1, ay), (ax, ay), (ax, ay + 1));
                                       ((ax - 1, ay), (ax, ay + 1), (ax - 1, ay + 1));
                                       ((ax - 1, ay + 1), (ax, ay + 1), (ax, ay + 2))]
            | Even -> if ay <> by then
                                      [((ax, ay + 1), (ax + 1, ay + 2), (ax, ay + 2));
                                       ((ax, ay + 1), (ax + 1, ay + 1), (ax + 1, ay + 2));
                                       ((ax + 1, ay + 1), (ax + 2, ay + 1), (ax + 1, ay + 2));
                                       ((ax + 1, ay + 1), (ax + 2, ay), (ax + 2, ay + 1));
                                       ((ax + 1, ay), (ax + 2, ay), (ax + 1, ay + 1));
                                       ((ax, ay), (ax + 1, ay), (ax + 1, ay + 1));
                                       ((ax, ay - 1), (ax + 1, ay), (ax, ay));
                                       ((ax - 1, ay), (ax, ay - 1), (ax, ay));
                                       ((ax - 1, ay), (ax, ay), (ax - 1, ay + 1));
                                       ((ax - 1, ay + 1), (ax, ay), (ax, ay + 1));
                                       ((ax - 1, ay + 1), (ax, ay + 1), (ax - 1, ay + 2));
                                       ((ax - 1, ay + 2), (ax, ay + 1), (ax, ay + 2))]
                      else             
                                      [((ax, ay + 1), (ax + 1, ay + 1), (ax + 1, ay + 2));
                                       ((ax + 1, ay + 1), (ax + 2, ay + 1), (ax + 1, ay + 2));
                                       ((ax + 1, ay + 1), (ax + 2, ay), (ax + 2, ay + 1));
                                       ((ax + 1, ay), (ax + 2, ay), (ax + 1, ay + 1));
                                       ((ax + 1, ay), (ax + 2, ay - 1), (ax + 2, ay));
                                       ((ax + 1, ay - 1), (ax + 2, ay - 1), (ax + 1, ay));
                                       ((ax, ay - 1), (ax + 1, ay - 1), (ax + 1, ay));
                                       ((ax, ay - 1), (ax + 1, ay), (ax, ay));
                                       ((ax - 1, ay), (ax, ay - 1), (ax, ay));
                                       ((ax - 1, ay), (ax, ay), (ax - 1, ay + 1));
                                       ((ax - 1, ay + 1), (ax, ay), (ax, ay + 1));
                                       ((ax, ay + 1), (ax + 1, ay + 1), (ax, ay + 1))]

    let scoreAndExplodeHexWithNeighbours(hex, field) = 

        let rec bfs hx = 
            let mutable num = 0
            let listOfNeighbours = getNeighbours(hex)
            let mutable listToExplode = []

            for i in listOfNeighbours do
                if isHexOneColor(i, field) then listToExplode <- i :: listToExplode

            num <- num + scoreAndExplodeHex(hx, field)

            for i in listToExplode do
                num <- num + bfs i

            num
        
        scoreTable.[bfs hex]

    let scoreAndExplodeMatches(field) = 
        let mutable isRemoval = true
        let iter = new Iter(size)
        let mutable score = 0 
        while isRemoval do
            isRemoval <- false
            while iter.isCurrentHexSome() do
                if isHexOneColor(iter.getCurrHex(), field) then score <- score + scoreAndExplodeHexWithNeighbours(iter.getCurrHex(), field)
                                                                isRemoval <- true
                iter.next()
            moveDownAndFill(field)
        score

    let rotateHex(field : int[,], hex) = 
        match hex with
        | (ax, ay), (bx, by), (cx, cy) -> let tmp = field.[ax, ay]
                                          field.[ax, ay] <- field.[bx, by]
                                          field.[bx, by] <- field.[cx, cy]
                                          field.[cx, cy] <- tmp

    let doBestRotation() = 
        let iter = new Iter(size)
        let mutable maxScore = 0
        let mutable nextStateField = Array2D.create 1 1 0
        let mutable tmp = 0

        while iter.isCurrentHexSome() do
            let mutable copiedField = Array2D.copy field
            
            rotateHex(copiedField, iter.getCurrHex())
            tmp <- scoreAndExplodeMatches(copiedField)
            if tmp > maxScore then maxScore <- tmp
                                   nextStateField <- copiedField
            
            copiedField <- Array2D.copy field
            rotateHex(copiedField, iter.getCurrHex())
            rotateHex(copiedField, iter.getCurrHex())
            tmp <- scoreAndExplodeMatches(copiedField)
            if tmp > maxScore then maxScore <- tmp
                                   nextStateField <- copiedField

            iter.next()

        field <- nextStateField
        maxScore
    do
        generateField()
    member this.doMove() = 
        
        doBestRotation()

    member this.printField() = 
        printfn "%A" field
                          