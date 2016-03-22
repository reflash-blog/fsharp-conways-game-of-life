namespace GameOfLifeFSharp

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type UtilityTests() = 
    
    [<TestMethod>]
    member this.``Test array in bounds is true``() =
      Utility.InArrayRange 1 1 2
      |> should be True

    [<TestMethod>]
    member this.``Test array in bounds is false``() =
      Utility.InArrayRange 3 3 3
      |> should be False
    
    [<TestMethod>]
    member this.``Test fold by sum [1;2;3] equals 6``() =
      [1;2;3]
      |> Utility.FoldBySum
      |> should equal 6