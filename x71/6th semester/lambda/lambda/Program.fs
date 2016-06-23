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
        | App (L A, App (B, C)) -> "(" + (L A).ToString() + ") (" + (App(B, C)).ToString() + ")"
        | App (A, App (B, C)) -> A.ToString() + " (" + (App(B, C)).ToString() + ")"
        | App (L A, B) -> "(" + (L A).ToString() + ") " + B.ToString()
        | App (A, B) -> A.ToString() + " " + B.ToString()


let rec shift (N c) (N i) = function
    | N n -> N (if n < c then n else n+i)
    | L A -> L (shift (N(c + 1)) (N i) A)
    | App (A, B) -> App (shift (N c) (N i) A, shift (N c) (N i) B)

let rec substitution (N m) e = function
    | N n -> if n = m then e else (N n)
    | L A -> L (substitution (N (m+1)) (shift (N 0) (N 1) e) A)
    | App (A, B) -> App(substitution (N m) e A, substitution (N m) e B)

let rec reduce = function
    | App ((L A), B) -> reduce (shift (N 0) (N -1) (substitution (N 0) (shift (N 0) (N 1) B) A))
    | L t -> L(reduce t)
    | App (a, B) -> match (reduce a) with
                    | L A -> reduce (shift (N 0) (N -1) (substitution (N 0) (shift (N 0) (N 1) B) A))
                    | A -> App(A, reduce B)
    | N n -> N n

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

let rec astToList = function
    | N n -> [n.ToString()] 
    | L A -> "\\"::(astToList A)
    | App (A, B) -> "@"::(astToList A)@(astToList B)

let writeToFile path (time : TimeSpan) ast =
    File.WriteAllLines (path, (time.ToString())::astToList ast)
        
[<EntryPoint>]
let main argv = 
    let path = argv.[0]
    let ast = readInput path
    printfn "Your input:\n%s" (ast.ToString())
    let start = System.DateTime.Now
    let reduced = reduce ast
    let time = System.DateTime.Now - start
    printfn "Reduced:\n%s" (reduced.ToString())
    writeToFile "result.txt" time reduced
    0
