using System.Collections.Generic;

namespace Graph
{
  public class Vertex
  {
    private List<Edge> edgeList;

    public string Name { get; }

    public Vertex(string name)
    {
      this.Name = name;
      this.edgeList = new List<Edge>();
    }

    public IReadOnlyList<Edge> Edges
    {
      get
      {
        return this.edgeList.AsReadOnly();
      }
    }

    public void AddEdge(Edge edge)
    {
      this.edgeList.Add(edge);
    }

    public void RemoveEdge(Edge edge)
    {
      this.edgeList.Remove(edge);
    }
  }
}