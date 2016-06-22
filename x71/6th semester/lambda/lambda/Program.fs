open System
open System.IO

type Tree =
    | L of (Tree)
    | App of (Tree * Tree)
    | N of (int)
    override this.ToString() =
        match this with
        | N n -> n.ToString()
        | L A -> "\." + A.ToString()
        | App (L A, App (B, C)) -> "(" + A.ToString() + ") (" + B.ToString() + ")"
        | App (A, App (B, C)) -> A.ToString() + " (" + B.ToString() + ")"
        | App (L A, B) -> "(" + A.ToString() + ") " + B.ToString()
        | App (A, B) -> A.ToString() + " " + B.ToString()

let rec shift (N c) (N i) = function
    | N n -> N (if n < c then n else n+i)
    | L A -> L (shift (N(c + 1)) (N i) A)
    | App (A, B) -> App (shift (N c) (N i) A, shift (N c) (N i) B)

let rec substitution (N m) (N e) = function
    | N n -> N (if n = m then e else n)
    | L A -> L (substitution (N (m+1)) (shift (N 0) (N 1) (N e)) A)
    | App (A, B) -> App(substitution (N m) (N e) A, substitution (N m) (N e) B)

let rec reduction = function
    | App ((L A), B) -> shift (N 0) (N -1) (substitution (N 0) (shift (N 0) (N 1) B) A)
    | L t -> L(reduction t)
    | App (A, B) -> reduction <| App(reduction A, reduction B)
    | c -> c

let readInput path =
    let rec parseInput = function
        | (hd:string) :: tl -> 
            if hd.Contains "\\" then
                let A, toParse = parseInput tl
                (L A), toParse
            elif hd.Contains "@" then
                let A, toParse = parseInput tl
                match toParse with
                | [] -> failwith "Wrong number of args in application(< 2)."
                | _ -> let B, toParse2 = parseInput toParse
                       (App(A, B)), toParse2
            else (N(int hd)), tl
        | [] -> failwith "Wrong number of args."
    let inputList = Seq.toList <| File.ReadAllLines path
    let result, tail = parseInput inputList
    match tail with
    | [] -> result
    | _ -> failwith "Too much args."

[<EntryPoint>]
let main argv = 
    let path = argv.[0]
    let ast1 = L(App(L(App (N 1, N 0)), N 1))
    let ast2 = L(L(L(App( App( L(L(App( App(N 2, N 1), N 0))), N 1 ), N 2 ))))
    let ast = readInput path
    let reduced = reduction ast

    printfn "%A" (ast.ToString())
    printfn "%A" (reduced.ToString())
    0
