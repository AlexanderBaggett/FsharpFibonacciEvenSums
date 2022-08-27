open System;
open System.Collections.Generic;
//optimize for speed
let fibDict = new Dictionary<int,int>();

[<Literal>]
let limit = 4000000

let rec fib number:int =
    if fibDict.ContainsKey(number) then fibDict[number]
    else
        let buildNewNumber number =
            match number with
            | 1 | 2 -> 1
            | number -> fib(number - 1) + fib(number-2)

        let newValue = buildNewNumber number
        fibDict.Add(number,newValue)
        newValue

let result =
    Seq.initInfinite(fun x -> x + 1)
    |> Seq.map(fib)
    |> Seq.filter(fun x  -> x % 2 = 0)
    |> Seq.takeWhile(fun x -> x < limit)
    |> Seq.sum

Console.WriteLine(result);

Console.ReadKey |> ignore
