module ConnectTests

open FsUnit.Xunit
open Xunit

open Connect

[<Fact>]
let ``An empty board has no winner`` () =
    let board = 
        [ ". . . . .    ";
          " . . . . .   ";
          "  . . . . .  ";
          "   . . . . . ";
          "    . . . . ." ]
    winner board |> should equal None

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``X can win on a 1x1 board`` () =
    let board = ["X"]
    winner board |> should equal (Some Black)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``O can win on a 1x1 board`` () =
    let board = ["O"]
    winner board |> should equal (Some White)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Only edges does not make a winner`` () =
    let board = 
        [ "O O O X   ";
          " X . . X  ";
          "  X . . X ";
          "   X O O O" ]
    winner board |> should equal None

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Illegal diagonal does not make a winner`` () =
    let board = 
        [ "X O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   . O X . ";
          "    X X O O" ]
    winner board |> should equal None

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Nobody wins crossing adjacent angles`` () =
    let board = 
        [ "X . . .    ";
          " . X O .   ";
          "  O . X O  ";
          "   . O . X ";
          "    . . O ." ]
    winner board |> should equal None

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``X wins crossing from left to right`` () =
    let board = 
        [ ". O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   X X O X ";
          "    . O X ." ]
    winner board |> should equal (Some Black)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``O wins crossing from top to bottom`` () =
    let board = 
        [ ". O . .    ";
          " O X X X   ";
          "  O O O .  ";
          "   X X O X ";
          "    . O X ." ]
    winner board |> should equal (Some White)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``X wins using a convoluted path`` () =
    let board = 
        [ ". X X . .    ";
          " X . X . X   ";
          "  . X . X .  ";
          "   . X X . . ";
          "    O O O O O" ]
    winner board |> should equal (Some Black)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``X wins using a spiral path`` () =
    let board = 
        [ "O X X X X X X X X        ";
          " O X O O O O O O O       ";
          "  O X O X X X X X O      ";
          "   O X O X O O O X O     ";
          "    O X O X X X O X O    ";
          "     O X O O O X O X O   ";
          "      O X X X X X O X O  ";
          "       O O O O O O O X O ";
          "        X X X X X X X X O" ]
    winner board |> should equal (Some Black)

