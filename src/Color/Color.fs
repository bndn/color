/// Copyright (C) 2016 The Authors.
module Color

type Color =
    | C of byte * byte * byte
    override c.ToString() =
        match c with
        | C(r, g, b) -> "[R:" + r.ToString() + ", G:" + g.ToString() + ", B:" + b.ToString() + "]"

/// <summary>
/// Raised in case of attempting to input an invalid float value.
/// </summary>
exception InvalidFloatInputException

/// <summary>
/// Creates a color from three float values.
/// </summary>
/// <param name=r>The red colorspace floating value.</param>
/// <param name=g>The green colorspace floating value.</param>
/// <param name=b>The blue colorspace floating value.</param>
/// <returns>The created Color.</returns>
let make r g b =
    let r = max 0. (min 1. r)
    let g = max 0. (min 1. g)
    let b = max 0. (min 1. b)

    C(byte (r * 255.), byte (g * 255.), byte (b * 255.))

/// <summary>
/// Gets the red colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The red colorspace floating value.</returns>
let getR (C(r,_,_)) = float r / 255.

/// <summary>
/// Gets the green colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The green colorspace floating value.</returns>
let getG (C(_,g,_)) = float g / 255.

/// <summary>
/// Gets the blue colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The blue colorspace floating value.</returns>
let getB (C(_,_,b)) = float b / 255.

/// <summary>
/// Scales a Color by a float value.
/// </summary>
/// <param name=c>The Color to scale.</param>
/// <param name=s>The float value to scale by.</param>
/// <returns>A new color scaled by s.</returns>
let scale (C(r, g, b)) s =
    if s < 0.0
        then raise InvalidFloatInputException

    let r = min (float r * s) 255.
    let g = min (float g * s) 255.
    let b = min (float b * s) 255.

    C(byte r, byte g, byte b)

/// <summary>
/// Merges two colors with respect to a reflective surface.
/// </summary>
/// <param name=refl>The float value denoting the reflective index.</param>
/// <param name=c1>First color to mix with.</param>
/// <param name=c2>Second color to mix with.</param>
/// <returns>The result color of the mixing.</returns>
let merge refl (C(r1, g1, b1)) (C(r2, g2, b2)) =
    if refl > 1.0 || refl < 0.0
    then raise InvalidFloatInputException

    let r = refl * float r1 + (1.0 - refl) * float r2
    let g = refl * float g1 + (1.0 - refl) * float g2
    let b = refl * float b1 + (1.0 - refl) * float b2

    C(byte r, byte g, byte b)
