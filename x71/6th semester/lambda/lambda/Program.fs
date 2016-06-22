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

let rec substitution (N m) (N e) = function
    | N n -> N (if n = m then e else n)
    | L A -> L (substitution (N (m+1)) (shift (N 0) (N 1) (N e)) A)
    | App (A, B) -> App(substitution (N m) (N e) A, substitution (N m) (N e) B)

let rec reduction = function
    | App ((L A), B) -> shift (N 0) (N -1) (substitution (N 0) (shift (N 0) (N 1) B) A)
    | L t -> L(reduction t)
    | App (A, B) -> reduction <| App(reduction A, reduction B)
    | c -> c

[<EntryPoint>]
let main argv = 
    let ast1 = L(App(L(App (N 1, N 0)), N 1))
    let ast = L(L(L(App( App( L(L(App( App(N 2, N 1), N 0))), N 1 ), N 2 ))))
    let reduced = reduction ast

    printfn "%A" (ast.ToString())
    printfn "%A" (reduced.ToString())
    0
