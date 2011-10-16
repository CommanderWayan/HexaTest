// Weitere Informationen zu F# unter "http://fsharp.net".

module CalcLib

let rec fib n = (if ( n <= 1) then 1 else fib(n-2) + fib(n-1))

let evenList = [|(0,-1); (1,-1); (1,0); (0,1); (-1,0); (-1,-1)|]
let oddList = [|(0,-1); (1,0); (1,1); (0,1); (-1,1); (-1,0)|]
let tupleAdd a b = (fun (x,y) -> (a+x,b+y))
let getNeighbors x y = 
    (if ((x % 2) = 0) then evenList else oddList)
    |> Array.map (tupleAdd x y)
    |> Array.map (fun (x,y) -> Microsoft.Xna.Framework.Point(x,y))

