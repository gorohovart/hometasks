// Gorokhov Artem (c) 2014
// 2nd semester HW 2
// simplification of arithmetic expression
type Expr =
    | Const of int // число
    | Var of string // переменная
    | Add of Expr * Expr // сумма
    | Sub of Expr * Expr // разность
    | Mul of Expr * Expr // произведение
    | Div of Expr * Expr // частное

let rec calc expr =
    match expr with
    | Const a -> Const a
    | Var a -> Var a
    | Add(Const a, Const b) -> Const (a + b)
    | Add(a, Const 0) | Add(Const 0, a) -> a
    | Add(a, b) -> let x = calc a
                   let y = calc b
                   Add(x, y)

    | Sub(Const a, Const b) -> Const (a - b)
    | Sub(a, Const 0) | Sub(Const 0, a) -> a
    | Sub(a, b) -> if (a = b) then Const 0
                   else let x = calc a
                        let y = calc b
                        Sub(x, y)
    
    | Mul(Const a, Const b) -> Const (a * b)
    | Mul(Const 0, a) | Mul(a, Const 0) -> Const 0
    | Mul(Const 1, a) | Mul(a, Const 1) -> calc a
    | Mul(a, b) -> let x = calc a
                   let y = calc b
                   Mul (x, y)

    | Div(Const a, Const b) -> Const (a / b)
    | Div(a, Const 1) -> calc a
    | Div(a, b) -> let x = calc a
                   let y = calc b
                   Div (x, y)

printfn "%A" (calc (Mul(Add(Var "x", Const 0), Var "c")))