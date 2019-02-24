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

    public void AddEdge(Edge item)
    {
      Assert.ArgumentNotNull(item, nameof(item));

      if (this.edges.Contains(item))
      {
        throw new InvalidOperationException($"The edge between vertices '{this.Name}' and '{item.Vertex.Name}' already exists.");
      }

      this.edges.Add(item);
    }

    public bool RemoveEdge(Edge item)
    {
      Assert.ArgumentNotNull(item, nameof(item));

      return this.edges.Remove(item);
    }
  }
}