using System.Collections.Generic;

namespace Graph
{
  public class Vertex
  {
    private readonly List<Edge> edges;

    public string Name { get; }

    public Vertex(string name)
    {
      this.Name = name;
      this.edges = new List<Edge>();
    }

    public IReadOnlyList<Edge> Edges => this.edges.AsReadOnly();

    public void AddEdge(Edge edge)
    {
      this.edges.Add(edge);
    }

    public void RemoveEdge(Edge edge)
    {
      this.edges.Remove(edge);
    }
  }
}