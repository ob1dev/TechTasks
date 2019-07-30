# Task 3

In an old drawer of your desk, you have found some long-forgotten necklaces. Each necklace comprises a number of beautiful, once shiny, beads. Unfortunately, now they are not only dusty, but also tangled together. You remember that the necklace with the most beads used to be your favorite. Now, you are interested in finding the necklace with the largest number of beads, without having to untangle them all.

You have carefully photographed the necklaces and numbered all the beads with numbers in the range [0..N-1], so that each number corresponds to exactly one bead. Then, for each bead, you have found the number of the next bead following it.

This information is given as an array of integers, indexed by bead numbers, and the elements are the numbers of the following beads. Each bead number appears in the array exactly once.

Write a function:

``` c#
class Task { public int Solution (int[ ] A); }
```

that, given an array A consisting of N integers, as described above, returns the maximum number of beads in a single necklace. The function should return 0 if the array is empty.

For example, given array A such that:

```
A[0] = 5
A[1] = 4
A[2] = 0
A[3] = 3
A[4] = 1
```

the function should return 4, because the longest necklace is the one containing four beads: numbers `{0, 5, 6, 2)`. Presented below are the untangled necklaces.

Write an efficient algorithm for the following assumptions:

* N is an integer within the range [0..1,000,000];
* the elements of A are all distinct;
* each element of array A is an integer within the range [0..N-1].