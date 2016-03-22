namespace GameOfLifeFSharp

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit

[<TestClass>]
type GameTests() = 
    
    [<TestMethod>]
    member this.``Test left upper corner neighbors is 0``() =
      (0, 0, [|
                [|0; 0; 0|]; 
                [|0; 0; 0|]; 
                [|0; 0; 0|]
              |]) 
      |> Game.NeighborsAt 
      |> should equal 0

    [<TestMethod>]
    member this.``Test left upper corner neighbors is 3``() =
      (0, 0, [|
                [|0; 1; 0|]; 
                [|1; 1; 0|]; 
                [|0; 0; 0|]
              |]) 
      |> Game.NeighborsAt 
      |> should equal 3

    [<TestMethod>]
    member this.``Test center item has 8 neighbors``() =
      (1, 1, [|
                [|1; 1; 1|]; 
                [|1; 1; 1|]; 
                [|1; 1; 1|]
              |]) 
      |> Game.NeighborsAt 
      |> should equal 8

    [<TestMethod>]
    member this.``Test live cell with no neighbors dies``() =
      [|
        [|1; 0; 0|]; 
        [|0; 0; 0|]; 
        [|0; 0; 0|]
       |]
      |> Game.Step 
      |> should equal [|
        [|0; 0; 0|]; 
        [|0; 0; 0|]; 
        [|0; 0; 0|]
       |]

    [<TestMethod>]
    member this.``Test live cell with 1 neighbor dies``() =
      [|
        [|1; 1; 0|]; 
        [|0; 0; 0|]; 
        [|0; 0; 0|]
       |]
      |> Game.Step 
      |> should equal [|
        [|0; 0; 0|]; 
        [|0; 0; 0|]; 
        [|0; 0; 0|]
       |]

    [<TestMethod>]
    member this.``Test live cell with 2 neighbors stays alive``() =
      [|
        [|1; 1; 1|]; 
        [|0; 0; 0|]; 
        [|0; 0; 0|]
       |]
      |> Game.Step 
      |> should equal [|
        [|0; 1; 0|]; 
        [|0; 1; 0|]; 
        [|0; 0; 0|]
       |]

    [<TestMethod>]
    member this.``Test live cell with 3 neighbors stays alive``() =
      [|
        [|1; 1; 1|]; 
        [|0; 1; 0|]; 
        [|0; 0; 0|]
       |]
      |> Game.Step 
      |> should equal [|
        [|1; 1; 1|]; 
        [|1; 1; 1|]; 
        [|0; 0; 0|]
       |]

    [<TestMethod>]
    member this.``Test live cell with 4 neighbors dies``() =
      [|
        [|1; 1; 1|]; 
        [|1; 1; 0|]; 
        [|0; 0; 0|]
       |]
      |> Game.Step 
      |> should equal [|
        [|1; 0; 1|]; 
        [|1; 0; 1|]; 
        [|0; 0; 0|]
       |]

    [<TestMethod>]
    member this.``Test dead cell with 3 neighbors becomes alive``() =
      [|
        [|1; 1; 1|]; 
        [|0; 0; 0|]; 
        [|0; 0; 0|]
       |]
      |> Game.Step 
      |> should equal [|
        [|0; 1; 0|]; 
        [|0; 1; 0|]; 
        [|0; 0; 0|]
       |]

    [<TestMethod>]
    member this.``Test dead cell with not exactly 3 neighbors stays dead``() =
      [|
        [|0; 1; 0|]; 
        [|0; 0; 1|]; 
        [|0; 0; 0|]
       |]
      |> Game.Step 
      |> should equal [|
        [|0; 0; 0|]; 
        [|0; 0; 0|]; 
        [|0; 0; 0|]
       |]

    [<TestMethod>]
    member this.``Test all zeroes state is game over``() =
      [|
        [|0; 0; 0|]; 
        [|0; 0; 0|]; 
        [|0; 0; 0|]
      |]
      |> Game.IsGameOver 
      |> should be True



    
