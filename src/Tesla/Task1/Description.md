# Table of Dice

A six-sided die is a small cube with a different number of pips on each face (side), 
ranging from 1 to 6. On any two opposite sides of the cube, the number of pips adds up to 7. 
There are three pairs of opposite sides:

- 1 and 6
- 2 and 5
- 3 and 4

There are N dice lying on a table, each showing the pips on its top face. 
In one move, you can take one die and rotate it to an adjacent face. For example,
you can rotate a die that shows 1 so that it shows 2, 3, 4 or 5.
However, it cannot show 6 in a single move, because the faces with one pip and
six pips visible are on opposite sides rather than adjacent.

You want to show the same number of pips on the top faces of all N dice.
Given that each of the dice can be moved multiple times,
count the minimum number of moves needed to get equal faces.

Write a function:

``` c#
class Solution
{ 
  public int Solution(int[] A);
}
```

that, given an array A consisting of N integers describing the number of pips (from 1 to 6) shown on each die's top face,
returns the minimum number of moves necessary for each die to show the same number of pips.

For example, given:

- A = [1, 2, 3], the function should return 2, as you can pick the first two dice
and rotate each of them in one move so that they all show three pips on the top face.
Notice that you can also pick any other pair of dice in this case.

- A = [1, 1, 6], the function should return 2. The only optimal answer is to rotate the last die
so that it shows one pip. It is necessary to use two rotations to achive this.

- A = [1, 6, 2, 3], the function should return 3. For instance, you can make all dice show 2.
Just rotate each die which is not showing 2 (and notice that for each die you can do this in one move).

Assume that:

- N is an integer with the range [1...100]
- Each element of array A is an integer with the range [1..6]

In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.