using System;
using System.Collections.Generic;

namespace List
{
  public class SinglyLinkedList
  {
    private SinglyLinkedListNode head;
    private SinglyLinkedListNode tail;

    public int Count { get; private set; }

    public void Add(int item)
    {
      var newNode = new SinglyLinkedListNode(item);

      if (this.head == null)
      {
        this.InserNodeToRoot(newNode);
      }
      else
      {
        this.InserNodeAfter(this.tail, newNode);
      }
    }

    public bool IsPalindrome()
    {
      var root = this.head;
      return this.IsPalindromeImpl(ref root, this.head, 0);
    }

    #region Private Method

    private void InserNodeToRoot(SinglyLinkedListNode newNode)
    {
      this.head = newNode;
      this.tail = newNode;

      this.Count++;
    }

    private void InserNodeAfter(SinglyLinkedListNode node, SinglyLinkedListNode newNode)
    {
      node.Next = newNode;
      this.tail = newNode;

      this.Count++;
    }

    private bool IsPalindromeImpl(ref SinglyLinkedListNode root, SinglyLinkedListNode current, int index)
    {
      // If a sequence of zero or just one item, then it's a palindrome. 
      if (this.Count <= 1)
      {
        return true;
      }

      // If reach out the end of the list, then stop the recursion, and assume it's a palindrome. 
      if (this.Count == index)
      {
        return true;
      }

      var result = this.IsPalindromeImpl(ref root, current.Next, index + 1);

      // Continue only if a previous nodes are equal and doesn't reach the center node.
      if (result && this.Count / 2 <= index)
      {
        if (root.Value != current.Value)
        {
          result = false;
        }

        // Move the pointer to the next node at right.
        root = root.Next;
      }

      return result;
    }

    #endregion
  }
}