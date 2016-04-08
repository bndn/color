/// Copyright (C) 2016 The Authors.
module Color.Test

open Xunit;
open FsUnit.Xunit;

[<Fact>]
let ``make constructs a color from three float values between 0.0 and 1.0``() =
    let c = Color.make 0.56 0.44 0.1

    // Check that color was constructed
    c |> should be instanceOfType<Color>

[<Fact>]
let ``getR gets the red colorspace of a color``() =
    let c = Color.make 0.56 0.44 0.1

    // Check red colorspace can be retrieved
    Color.getR c |> should equal 0.56

[<Fact>]
let ``getG gets the green colorspace of a color``() =
    let c = Color.make 0.56 0.44 0.1

    // Check green colorspace can be retrieved
    Color.getG c |> should equal 0.44

[<Fact>]
let ``getB gets the blue colorspace of a color``() =
    let c = Color.make 0.56 0.44 0.1

    // Check blue colorspace can be retrieved
    Color.getB c |> should equal 0.1

[<Fact>]
let ``scale scales a color by a float value``() =
    let c1 = Color.make 0.56 0.44 0.1
    let c2 = Color.scale c1 0.33

    // Check that the computed scaling is correct within +-0.01
    abs (Color.getR c2 - 0.1848) |> should be (lessThan 0.01)
    abs (Color.getG c2 - 0.1452) |> should be (lessThan 0.01)
    abs (Color.getB c2 - 0.033) |> should be (lessThan 0.01)

[<Fact>]
let ``scale fails if float val is less than 0.0``() =
    let c = Color.make 0.56 0.44 0.1

    // Checks that scaling fails if float val is less than 0.0
    (fun() -> Color.scale c -0.33 |> ignore) |> shouldFail

[<Fact>]
let ``scale does not allow scaling colors beyond 1.0``() =
    let c1 = Color.make 0.56 0.44 0.1
    let c2 = Color.scale c1 11.0

    // Check that colorspaces does not scale beyond 1.0
    Color.getR c2 |> should be (lessThanOrEqualTo 1.0)
    Color.getG c2 |> should be (lessThanOrEqualTo 1.0)
    Color.getB c2 |> should be (lessThanOrEqualTo 1.0)


[<Fact>]
let ``merge merges two colors with respect to a reflective surface index represented by a float``() =
    let c1 = Color.make 0.56 0.44 0.1
    let c2 = Color.make 0.20 0.54 0.2

    let c3 = merge 0.5 c1 c2

    // Check that the computed merging is correct within +-0.01
    abs (Color.getR c3 - 0.38) |> should be (lessThan 0.01)
    abs (Color.getG c3 - 0.49) |> should be (lessThan 0.01)
    abs (Color.getB c3 - 0.15) |> should be (lessThan 0.01)

[<Fact>]
let ``merge fails if the reflective index is less than 0.0``() =
    let c1 = Color.make 0.56 0.44 0.1
    let c2 = Color.make 0.20 0.54 0.2

    // Checks that merging fails if float val is less than 0.0
    (fun() -> Color.merge -0.2 c1 c2 |> ignore) |> shouldFail

[<Fact>]
let ``merge fails if the reflective index is more than 1.0``() =
    let c1 = Color.make 0.56 0.44 0.1
    let c2 = Color.make 0.20 0.54 0.2

    // Checks that merging fails if float val is more than 1.0
    (fun() -> Color.merge 1.4 c1 c2 |> ignore) |> shouldFail
