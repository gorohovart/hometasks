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

let rec reduction = function
    | App ((L A), B) -> reduction (shift (N 0) (N -1) (substitution (N 0) (shift (N 0) (N 1) B) A))
    | L t -> L(reduction t)
    | App (A, B) -> reduction <| App(reduction A, reduction B)
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

let writeToFile path ast =
    File.WriteAllLines (path, astToList ast)
        
[<EntryPoint>]
let main argv = 
    let path = argv.[0]
    (*let ast = App(L(App(L(App (N 1, N 0)), N 1)), L(N 0))
    let ast5 = App(L(App(L(N 0), N 0)), N 0)
    let ast4 = L(L(L(App( App( L(L(App( App(N 2, N 1), N 0))), N 1 ), N 2 ))))
    let ast1 = App(L(L(L(App( App( L(L(App( App(N 2, N 1), N 0))), N 1 ), N 2 )))), L(L(L(App( App( L(L(App( App(N 2, N 1), N 0))), N 1 ), N 2 )))))
    
    let astList1 = astToList ast
    let astList2 = Seq.toList <| File.ReadAllLines path
    printfn "%A" (List.forall2 (fun (a:string) (b:string) -> let aa = if a.Contains "\n" then a.Remove(a.IndexOf "\n") else a
                                                             let bb = if b.Contains "\n" then b.Remove(b.IndexOf "\n") else b
                                                             aa.Equals(bb)) astList1 astList2)
    *)
    let ast = readInput path
    printfn "Your input:\n%s" (ast.ToString())
    let reduced = reduction ast
    printfn "Reduced:\n%s" (reduced.ToString())
    writeToFile "result.txt" reduced
    0
