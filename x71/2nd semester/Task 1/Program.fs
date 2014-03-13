// Gorokhov Artem (c) 2014
// 2nd semester HW 1

//1 List elements sum
let rec listSum list =
    match list with
    | head :: tail -> (head + listSum tail)
    | [] -> 0

printfn "listSum = %A" (listSum [1; 2; 3])

//2 Lists concatenation
let rec listAppend list1 list2 =
    match list1 with
    | head :: tail -> (head :: (listAppend tail list2))
    | [] -> list2

printfn "listAppend: %A" (listAppend [1; 2; 3] [4; 5])

//3 new element to end of list
let rec listAddToEnd list x =
    match list with
    | head :: tail -> (head :: (listAddToEnd tail x))
    | [] -> [x]

printfn "listAddToEnd: %A" (listAddToEnd [1; 2; 3] 4)

//4 list filter
let rec listFilter f list = 
    match list with
    | head :: tail -> 
        if f head then
            head :: (listFilter f tail)
        else
            listFilter f tail
    | [] -> []              

printfn "listFilter: %A" (listFilter (fun x -> x % 2 = 0) [1..10]) //print even

//6 generate list of squares
let sqr x = x * x

let genSqrList n = 
    let rec sqrList i n = 
        if i = n then 
            [sqr i]
        else
            (sqr i) :: (sqrList (i + 1) n)
    sqrList 1 n

printfn "genSqrList: %A" (genSqrList 8)