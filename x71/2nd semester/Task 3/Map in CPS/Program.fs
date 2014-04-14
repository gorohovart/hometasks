// Gorokhov Artem (c) 2014
// 2nd semester HW 3
// Map in continuation passing style
let rec listMapCPS f l g =
    match l with
    | hd :: tl -> f hd (fun x -> listMapCPS f tl (fun y -> g (x :: y)))
    | [] -> g []

let sqr' x f = f (x * x)

let list = [1..10]

listMapCPS sqr' list  (printfn "%A ")
