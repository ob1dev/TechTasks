﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
  public class UndirectedGraph
  {
    private readonly Dictionary<string, Vertex> vertexes;

    public int Count => this.vertexes.Count;

    public UndirectedGraph()
    {
      this.vertexes = new Dictionary<string, Vertex>();
    }

    public void AddVertex(Vertex item)
    {
      Assert.ArgumentNotNull(item, nameof(item));

      if (this.vertexes.ContainsKey(item.Name))
      {
        throw new ArgumentException($"The vertex '{item.Name}' already exists in the graph.");
      }

      this.vertexes.Add(item.Name, item);
    }

    public bool RemoveVertex(Vertex item)
    {
      Assert.ArgumentNotNull(item, nameof(item));

      if (this.Exist(item))
      {
        return false;
      }

      // Remove vertex's edges first, then remote vertex itself. 
      foreach (var edge in item.Edges)
      {
        this.RemoveEdge(item, edge.Vertex);
      }

      return this.vertexes.Remove(item.Name);
    }

    public void AddEdge(Vertex start, Vertex end, int weight)
    {
      Assert.ArgumentNotNull(start, nameof(start));
      Assert.ArgumentNotNull(end, nameof(end));

      this.ValidateIfVertexExist(start);
      this.ValidateIfVertexExist(end);

      // Two vertices must be unique.
      if (start == end)
      {
        throw new ArgumentException($"An edge cannot be added between the single vertex '{start.Name}'.");
      }

      start.AddEdge(new Edge(weight, end));
      end.AddEdge(new Edge(weight, start));
    }

    public bool RemoveEdge(Vertex start, Vertex end)
    {
      Assert.ArgumentNotNull(start, nameof(start));
      Assert.ArgumentNotNull(end, nameof(end));

      this.ValidateIfVertexExist(start);
      this.ValidateIfVertexExist(end);

      var forwardEdge = start.Edges.Single(s => s.Vertex.Name.Equals(end.Name));
      var forwardEdgeResult = start.RemoveEdge(forwardEdge);

      var backwardEdge = end.Edges.Single(s => s.Vertex.Name.Equals(start.Name));
      var backwardEdgeResult = end.RemoveEdge(backwardEdge);

      return (forwardEdgeResult && backwardEdgeResult);
    }

    public bool Exist(Vertex item)
    {
      Assert.ArgumentNotNull(item, nameof(item));

      return this.vertexes.ContainsKey(item.Name);
    }

    public int FindMaxWeightedPath(Vertex start, Vertex end)
    {
      Assert.ArgumentNotNull(start, nameof(start));
      Assert.ArgumentNotNull(end, nameof(end));

      return this.FindMaxWeightedPathImpl(start, end, new HashSet<string>());
    }

    #region Private Method

    private void ValidateIfVertexExist(Vertex item)
    {
      if (this.Exist(item) == false)
      {
        throw new ArgumentException($"The graph does not contain the vertex '{item.Name}'.");
      }
    }

    private int FindMaxWeightedPathImpl(Vertex current, Vertex end, HashSet<string> visitedVertexes)
    {
      if (current == end)
      {
        return 0;
      }

      var maxWeight = 0;
      visitedVertexes.Add(current.Name);

      foreach (var edge in current.Edges)
      {
        if (!visitedVertexes.Contains(edge.Vertex.Name))
        {
          var currentWeight = edge.Weight + this.FindMaxWeightedPathImpl(edge.Vertex, end, visitedVertexes);

          if (maxWeight < currentWeight)
          {
            maxWeight = currentWeight;
          }
        }
      }

      visitedVertexes.Remove(current.Name);

      return maxWeight;
    }

    #endregion
  }
}