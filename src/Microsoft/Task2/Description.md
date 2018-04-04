## Classify a triangle

A customer wants a code library that handles classification of triangles.

The code in the library has a method/function which:

 + Takes three numeric inputs which are to be interpreted as the lengths of the sides of a triangle
 + Returns a classification for the type of triangle they form.

The customer:

 - knows the types of triangles they care about classifying now, but wants to extend the classifications in the future
 - wants the flexibility to change the prioritization of the classifications

The initial classifications (in priority order) are:

1. Equilateral - All three sides are equal in length
2. Isosceles - Two of the sides are equal in length
3. Right - One of the angles is 90 degrees
4. Scalene - No two sides are equal in length