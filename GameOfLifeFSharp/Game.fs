namespace GameOfLifeFSharp

type Game =

    static member NeighborsAt(x : int, y: int, states : int [][]) : int =
        [for i in [(x-1)..(x+1)] do 
         for j in [(y-1)..(y+1)] do 
         if ((i <> x || j <> y) && 
              Utility.InArrayRange i j states.Length) 
         then yield states.[i].[j];] 
        |> Utility.FoldBySum

    static member Step(states : int [][]) : int[][] = 
        [| for x in 0..states.Length - 1 do 
           yield [| for y in 0..states.[0].Length - 1 do  
                         match Game.NeighborsAt(x,y,states) with 
                          | 3 -> yield 1
                          | 2 -> yield states.[x].[y]
                          | _ -> yield 0
                   |] 
          |]

    static member IsGameOver (states : int[][]) : bool =
        [for record in states do 
         for state in record do 
         if state = 1 
         then yield state]
        |> List.isEmpty


    
