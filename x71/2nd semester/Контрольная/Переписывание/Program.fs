module Huffman

type CodeTree = 
  | Fork of left: CodeTree * right: CodeTree * chars: char list * weight: int
  | Leaf of char: char * weight: int

let weight tree = //: CodeTree -> int
    match tree with 
        | Leaf (_,x) -> x
        | Fork (_,_,_,x) -> x

let chars tree = //: CodeTree -> char list
    match tree with 
        | Leaf (x,_) -> [x]
        | Fork (_,_,x,_) -> x
 
let makeCodeTree left right = 
    Fork(left, right, (chars left) @ (chars right), weight left + weight right)

let stringZchars str = Seq.toList str

let times lst = //: char list -> (char * int) list
    let rec updateList c list =
        match list with
        | [] -> [(c, 1)]
        | (a, i) :: tl -> if a = c then (a, i + 1) :: tl
                          else (a, i) :: (updateList c tl)

    let rec time list l =
        match list with
        | [] -> l
        | head :: tail -> time tail (updateList head l)
    
    time lst []

let makeOderedLeafList (lst : (char * int) list) : CodeTree list =
    let sortedList = List.sortBy (fun elem -> match elem with | (a, b) -> b) lst
    let rec make cList =
        match cList with
        | [] -> []
        | (a, i) :: tl -> Leaf (a, i) :: (make tl)

    make sortedList

let singleton (cdList : CodeTree list) : bool =
    match cdList with
    | [] -> failwith("Error")
    | hd :: [] -> true
    | hd :: tl -> false

let combine (cdList : CodeTree list) : CodeTree list =
    
    match cdList with
    | [] -> failwith("error")
    | left :: right :: tl -> makeCodeTree left right :: tl
    | hd :: tl -> failwith("error")

let rec until is f lst=
    if is lst then until is f (f lst)
    else lst

let createCodeTree (clist: string) : CodeTree = 
    let singleList = until singleton combine (makeOderedLeafList (times (stringZchars clist)))

    match singleList with
    | hd :: [] -> hd

printfn "%A" (createCodeTree "aabcabcd")
