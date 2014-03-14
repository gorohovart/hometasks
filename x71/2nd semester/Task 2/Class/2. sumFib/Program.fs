let max = 4L * 1000L * 1000L

let fibonachiSum = 
    let rec fib a b = 
        if b >= max then
            0L
        else if (a + b) % 2L = 0L then
            (a + b) + fib b (a + b)
        else
            fib b (a + b)
    fib 1L 1L

printfn "%A" fibonachiSum