// Weitere Informationen zu F# unter "http://fsharp.net".

module CalcLib

let rec fib n = (if ( n <= 1) then 1 else fib(n-2) + fib(n-1))

let getNeighbor x y = (x + y)

