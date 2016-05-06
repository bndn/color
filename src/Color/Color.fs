/// Copyright (C) 2016 The Authors.
module Color

type Color =
    | C of float * float * float
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
let make r g b = C(max 0. (min 1. r), max 0. (min 1. g), max 0. (min 1. b))

/// <summary>
/// Gets the red colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The red colorspace floating value.</returns>
let getR (C(r,_,_)) = r

/// <summary>
/// Gets the green colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The green colorspace floating value.</returns>
let getG (C(_,g,_)) = g

/// <summary>
/// Gets the blue colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The blue colorspace floating value.</returns>
let getB (C(_,_,b)) = b

/// <summary>
/// Scales a Color by a float value.
/// </summary>
/// <param name=c>The Color to scale.</param>
/// <param name=s>The float value to scale by.</param>
/// <returns>A new color scaled by s.</returns>
let scale (C(r, g, b)) s =
    if s < 0.0
        then raise InvalidFloatInputException

    C(min (r * s) 1.0, min (g * s) 1.0, min (b *s) 1.0)

/// <summary>
/// Merges two colors with respect to a reflective surface.
/// </summary>
/// <param name=refl>The float value denoting the reflective index.</param>
/// <param name=c1>First color to mix with.</param>
/// <param name=c2>Second color to mix with.</param>
/// <returns>The result color of the mixing.</returns>
let merge refl c1 c2 =
    if refl > 1.0 || refl < 0.0
    then raise InvalidFloatInputException

    C(refl * getR(c1) + (1.0 - refl) * getR(c2),
        refl * getG(c1) + (1.0 - refl) * getG(c2),
        refl * getB(c1) + (1.0 - refl) * getB(c2))
