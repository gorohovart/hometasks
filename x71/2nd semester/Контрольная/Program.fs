module Huffman

type CodeTree = 
  | Fork of left: CodeTree * right: CodeTree * chars: char list * weight: int
  | Leaf of char: char * weight: int


// code tree

let createCodeTree (chars: char list) : CodeTree = 
    failwith "Not implemented"

// decode

type Bit = int

let rec decode (tree: CodeTree) (bits: Bit list) : char list = 
    match bits with
    | [] -> []
    | lst ->
        let rec decodeFirst tree1 lst : (char * Bit List) =
              match lst with 
              | 0 :: tl -> match tree1 with
                           | Leaf (x, i) -> (x, tl)
                           | Fork (tree2,_,_,_) -> decodeFirst tree2 tl
              | 1 :: tl -> match tree1 with
                           | Fork (tree2, Leaf (x,_),_,_) -> (x, tl)

        let decF = decodeFirst tree lst
        match decF with
        | (x, tl) -> x :: (decode tree tl)

// encode
let rec encode (tree: CodeTree) (text: char list) : Bit list = 
    match text with
    | [] -> []
    | head :: tail ->
        let rec findHd tree1 hd : Bit List =
              match tree1 with 
              | Leaf (hd, i) -> [0]
              | Fork (tree2, Leaf (x,_),_,_) -> if x = hd then [1]
                                                else 0 :: (findHd tree2 hd)

        (findHd tree head)@(encode tree tail)

let tree = Fork ( Fork (Leaf ('a', 3), Leaf('b', 2), ['a'; 'b'], 5), Fork (Leaf ('c', 2), Leaf('d', 1), ['c'; 'd'], 3) , ['a'; 'b'; 'c'; 'd'], 8)
let text = [a;a;b;c;a;b;c;d]
printfn "%A" (encode tree text)

