using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
  public class UndirectedGraph
  {
    private List<Vertex> vertexList;

    public UndirectedGraph()
    {
      this.vertexList = new List<Vertex>();
    }

    public void AddVertex(Vertex item)
    {
      if (this.vertexList.Contains(item))
      {
        throw new ArgumentException("An element with the same key already exists in the graph.");
      }

      this.vertexList.Add(item);
    }

    public void RemoveVertex(Vertex item)
    {
      foreach (var edge in item.Edges)
      {
        this.RemoveEdge(item, edge.Vertex);
      }

      this.vertexList.Remove(item);
    }

    public void AddEdge(Vertex start, Vertex end, int weight)
    {
      if (start == end)
      {
        throw new ArgumentException("An edge cannot be added between a single vertex.");
      }

      if (this.vertexList.Contains(start) && this.vertexList.Contains(end))
      {
        start.AddEdge(new Edge(weight, end));
        end.AddEdge(new Edge(weight, start));
      }
    }

    public void RemoveEdge(Vertex start, Vertex end)
    {
      if (this.vertexList.Contains(start) && this.vertexList.Contains(end))
      {
        var forwardEdge = start.Edges.Single(s => s.Vertex.Name.Equals(end.Name));
        start.RemoveEdge(forwardEdge);

        var backwardEdge = end.Edges.Single(s => s.Vertex.Name.Equals(start.Name));
        end.RemoveEdge(backwardEdge);
      }
    }

    public int FindMaxWeightedPath(Vertex start, Vertex end)
    {
      var maxWeight = 0;

      if (start != null && end != null)
      {
        maxWeight = this.FindMaxWeightedPathImpl(null, start, end);
      }

      return maxWeight;
    }

    #region Private Method

    private int FindMaxWeightedPathImpl(Vertex prev, Vertex start, Vertex end)
    {
      if (start == end)
      {
        return 0;
      }

      var maxWeight = 0;

      foreach (var edge in start.Edges)
      {
        if (prev == edge.Vertex)
        {
          continue;
        }

        var currentWeight = edge.Weight + this.FindMaxWeightedPathImpl(start, edge.Vertex, end);

        if (maxWeight < currentWeight)
        {
          maxWeight = currentWeight;
        }
      }

      return maxWeight;
    }

    #endregion
  }
}
