namespace Graph
{
  public class Edge
  {
    public int Weight { get; }

    public Vertex Vertex { get; }

    public Edge(int weight, Vertex vertex)
    {
      this.Weight = weight;
      this.Vertex = vertex;
    }
  }
}