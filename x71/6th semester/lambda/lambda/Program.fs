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
        | App (A, B) -> "(" + A.ToString() + ") (" + B.ToString() + ")"

let rec shift (N c) (N i) = function
    | N n -> N (if n < c then n else n+i)
    | L A -> L (shift (N(c + 1)) (N i) A)
    | App (A, B) -> App (shift (N c) (N i) A, shift (N c) (N i) B)

let rec substitution (N e) (N m) = function
    | N n -> N (if n = m then e else n)
    | L A -> L (substitution (shift (N 0) (N 1) (N e)) (N (m+1)) A)
    | App (A, B) -> App(substitution (N e) (N m) A, substitution (N e) (N m) B)

let rec reduction = function
    | App ((L A), B) -> shift (N 0) (N -1) (substitution(shift (N 0) (N 1) B) (N 0) A)
    | L t -> L(reduction t)
    | App (A, B) -> App(reduction A, reduction B)
    | c -> c

[<EntryPoint>]
let main argv = 
    let path = argv.[0]
    let ast = L(App(L(App (N 1, N 0)), N 1))
    
    let reduced = reduction ast

    printfn "%A" (ast.ToString())
    printfn "%A" (reduced.ToString())
    0
