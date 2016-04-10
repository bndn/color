/// Copyright (C) 2016 The Authors.
module Color

type Color

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
val make : r:float -> g:float -> b:float -> Color

/// <summary>
/// Gets the red colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The red colorspace floating value.</returns>
val getR : c:Color -> float

/// <summary>
/// Gets the green colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The green colorspace floating value.</returns>
val getG : c:Color -> float

/// <summary>
/// Gets the blue colorspace floating value from a Color.
/// </summary>
/// <param name=c>The color to retrieve the colorspace from.</param>
/// <returns>The blue colorspace floating value.</returns>
val getB : c:Color -> float

/// <summary>
/// Scales a Color by a float value.
/// </summary>
/// <param name=c>The Color to scale.</param>
/// <param name=s>The float value to scale by.</param>
/// <returns>A new color scaled by s.</returns>
val scale : c:Color -> s:float -> Color

/// <summary>
/// Merges two colors with respect to a reflective surface.
/// </summary>
/// <param name=refl>The float value denoting the reflective index.</param>
/// <param name=c1>First color to mix with.</param>
/// <param name=c2>Second color to mix with.</param>
/// <returns>The result color of the mixing.</returns>
val merge : refl:float -> c1:Color -> c2:Color -> Color
