# Given a singly linked list of characters, determine if it is a palindrome.

#### Example 1:

- Input: 2->5->5->2
- Output: true

#### Example 2:

- Input: 2->5
- Output: false

#### Additional test cases:
- 1
- 1->1
- 1->2->1
- 1->1->1

#### Definition for singly-linked list.
```
type Node struct {
    Val int
    Next *ListNode
}
```