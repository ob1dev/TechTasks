using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intervals
{
  public class IntervalService
  {
    private LinkedList<Interval> intervalsLinkedList;

    public IntervalService()
    {
      this.intervalsLinkedList = new LinkedList<Interval>();
    }

    public override string ToString()
    {
      var intervals = new StringBuilder();

      foreach (var curent in this.intervalsLinkedList)
      {
        intervals.Append(curent)
                 .Append(", ");
      }

      return intervals.ToString().TrimEnd(new char[] { ',', ' ' });
    }

    public void Initialize(LinkedList<Interval> intervals)
    {
      this.intervalsLinkedList = intervals;
    }

    public void Init(string intervals)
    {
      if (!string.IsNullOrWhiteSpace(intervals))
      { 
        var separators = new char[] { ',' };
        var intervalsArray = intervals.Split(separators);

        foreach (var s in intervalsArray)
        {
          var interval = Interval.Parse(s.Trim());
          this.intervalsLinkedList.AddLast(interval);
        }
      }
    }

    public IntervalService Add(string interval)
    {
      return this.Add(Interval.Parse(interval));
    }

    public IntervalService Add(Interval newInterval)
    {
      LinkedListNode<Interval> leftBoundry = null;
      LinkedListNode<Interval> rightBoundry = null;
      LinkedListNode<Interval> currentNode = null;

      this.Analyze(newInterval, ref leftBoundry, ref rightBoundry, ref currentNode);
      this.InsertOrMerge(newInterval, leftBoundry, rightBoundry, currentNode);

      return this;
    }

    protected void Analyze(Interval newInterval,
                           ref LinkedListNode<Interval> leftBoundry,
                           ref LinkedListNode<Interval> rightBoundry,
                           ref LinkedListNode<Interval> currentNode)
    {
      var point = Intersection.None;
      var stop = false;

      if (intervalsLinkedList.Any())
      {
        currentNode = this.intervalsLinkedList.First;

        do
        {
          var currentInterval = currentNode.Value;

          if (newInterval < currentInterval)
          {
            stop = true;
            break;
          }
          else if (newInterval.IntersectWith(currentInterval, out point))
          {
            switch (point)
            {
              case Intersection.Left:
                {
                  leftBoundry = rightBoundry = currentNode;
                  break;
                }
              case Intersection.Right:
                {
                  leftBoundry = leftBoundry ?? currentNode;
                  rightBoundry = currentNode;
                  break;
                }
              case Intersection.Both:
                {
                  leftBoundry = leftBoundry ?? currentNode;
                  rightBoundry = currentNode;
                  break;
                }
            }
          }

          currentNode = currentNode.Next;

        }
        while (currentNode != null && !stop);
      }
    }

    protected void InsertOrMerge(Interval newInterval,
                                 LinkedListNode<Interval> leftBoundry,
                                 LinkedListNode<Interval> rightBoundry,
                                 LinkedListNode<Interval> currentNode)
    {
      // Insert a new interval.
      if (leftBoundry == null && rightBoundry == null)
      {
        // Insert after or as the first.
        if (currentNode == null)
        {
          this.intervalsLinkedList.AddLast(newInterval);
        }
        // Insert before.
        else
        {
          this.intervalsLinkedList.AddBefore(currentNode, newInterval);
        }
      }
      // Insert and merge.
      else if (leftBoundry != null && rightBoundry != null)
      {
        var mergedInterval = new Interval(Math.Min(leftBoundry.Value.From, newInterval.From),
                                          Math.Max(rightBoundry.Value.To, newInterval.To));

        this.intervalsLinkedList.AddBefore(leftBoundry, mergedInterval);

        this.RemoveRange(leftBoundry, rightBoundry);
      }
    }

    protected void RemoveRange(LinkedListNode<Interval> from, LinkedListNode<Interval> to)
    {
      do
      {
        var next = from.Next;
        this.intervalsLinkedList.Remove(from);
        from = next;
      }
      while (to.List != null);
    }
  }
}