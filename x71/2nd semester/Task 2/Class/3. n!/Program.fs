// Gorokhov Artem (c) 2014
// 2nd semester HW 2
// Sum of numbers of 100!

let rec sum n = 
    if n < 10I then n
    else n % 10I + sum (n / 10I)
let rec factorial n =
    if n = 1 then 1I
    else 
        (System.Numerics.BigInteger n) * factorial (n - 1)

printfn "%A" (sum (factorial 100))
