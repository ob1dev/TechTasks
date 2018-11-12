using System;
using System.Collections.Generic;

namespace List
{
  public class SinglyLinkedList<T>
  {
    private SinglyLinkedListNode<T> head;
    private SinglyLinkedListNode<T> tail;

    public int Count { get; private set; }

    public void Add(T item)
    {
      var newNode = new SinglyLinkedListNode<T>(item);

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
      // If a sequence of zero or one item, then it's a palindrome. 
      if (this.Count <= 1)
      {
        return true;
      }
      
      // If there is a simple sequence of just two or tree items.
      if (this.Count == 2 || this.Count == 3)
      {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        return (comparer.Equals(this.head.Value, this.tail.Value));
      }

      var root = this.head;
      return this.IsPalindromeImpl(ref root, this.head, 0);
    }

    #region Private Method

    private void InserNodeToRoot(SinglyLinkedListNode<T> newNode)
    {
      this.head = newNode;
      this.tail = newNode;

      this.Count++;
    }

    private void InserNodeAfter(SinglyLinkedListNode<T> node, SinglyLinkedListNode<T> newNode)
    {
      node.Next = newNode;
      this.tail = newNode;

      this.Count++;
    }

    private bool IsPalindromeImpl(ref SinglyLinkedListNode<T> root, SinglyLinkedListNode<T> current, int index)
    {
      // If reach out the end of the list, then stop the recursion, and assume it's a palindrome. 
      if (this.Count == index)
      {
        return true;
      }

      var result = this.IsPalindromeImpl(ref root, current.Next, index + 1);

      // Continue only if a previous nodes are equal and doesn't reach the center node.
      if (result && this.Count / 2 <= index)
      {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        if (!comparer.Equals(root.Value, current.Value))
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