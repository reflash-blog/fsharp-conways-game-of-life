namespace GameOfLifeFSharp

type Utility =
    static member FoldBySum list : int =
        List.sum list

    static member InArrayRange x y upperBound : bool =
        x >= 0 && 
        y >= 0 && 
        x < upperBound && 
        y < upperBound
