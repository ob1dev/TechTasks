using System;
using System.Collections.Generic;

namespace Graph
{
  public class Vertex
  {
    private readonly List<Edge> edges;

    public string Name { get; }

    public int Count => this.edges.Count;

    public IReadOnlyList<Edge> Edges => this.edges.AsReadOnly();

    public Vertex(string name)
    {
      this.Name = name;
      this.edges = new List<Edge>();
    }

    public void AddEdge(Edge edge)
    {
      Assert.ArgumentNotNull(edge, nameof(edge));

      if (this.edges.Contains(edge))
      {
        throw new InvalidOperationException($"The edge between vertices '{this.Name}' and '{edge.Vertex.Name}' already exists.");
      }

      this.edges.Add(edge);
    }

    public bool RemoveEdge(Edge edge)
    {
      Assert.ArgumentNotNull(edge, nameof(edge));

      return this.edges.Remove(edge);
    }
  }
}