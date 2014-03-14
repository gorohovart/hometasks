let GPD n =
    let rec divide m (k : int64) =
         if m = 1L then k
         else if m % k = 0L then divide (m / k) k
         else divide m (k + 1L)
    divide n 2L

printfn "%A" (GPD 600851475143L)


