// Gorokhov Artem (c) 2014
// Map in continuation passing style
module MapCPS

let rec listMapCPS f l g =
    match l with
    | hd :: tl -> f hd (fun x -> listMapCPS f tl (fun y -> g (x @ y)))
    | [] -> g []
