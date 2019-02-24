using Xunit;

namespace Graph.Tests
{
  public class UndirectedGraph_FindMaximumWeightedPathShould
  {
    [Fact]
    public void Return_0_Given_Empty_Graph()
    {
      // Arrange 
      var graph = new UndirectedGraph();

      // Act
      var actual = graph.FindMaxWeightedPath(null, null);

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void Return_0_Given_Graph_With_1_Vertex_And_No_Edges()
    {
      // Arrange 
      var graph = new UndirectedGraph();

      var a = new Vertex("A");

      // Act
      var actual = graph.FindMaxWeightedPath(a, a);

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void Return_0_Given_Graph_With_2_Vertexex_And_No_Edge()
    {
      // Arrange 
      var graph = new UndirectedGraph();

      var a = new Vertex("A");
      var b = new Vertex("B");

      // Act
      var actual = graph.FindMaxWeightedPath(a, b);

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void Return_10_Given_Graph_With_2_Vertexex_And_1_Edge()
    {
      // Arrange 
      var graph = new UndirectedGraph();

      var a = new Vertex("A");
      var b = new Vertex("B");

      graph.AddVertex(a);
      graph.AddVertex(b);

      graph.AddEdge(a, b, 10);

      // Act
      var actual1 = graph.FindMaxWeightedPath(a, b);
      var actual2 = graph.FindMaxWeightedPath(b, a);

      // Assert
      Assert.Equal(10, actual1);
      Assert.Equal(10, actual2);
    }

    [Fact]
    public void Return_30_Given_Graph_With_3_Vertexex_And_2_Edges()
    {
      // Arrange 
      var graph = new UndirectedGraph();

      var a = new Vertex("A");
      var b = new Vertex("B");
      var c = new Vertex("C");

      graph.AddVertex(a);
      graph.AddVertex(b);
      graph.AddVertex(c);

      graph.AddEdge(a, b, 10);
      graph.AddEdge(b, c, 20);

      // Act
      var actual1 = graph.FindMaxWeightedPath(a, c);
      var actual2 = graph.FindMaxWeightedPath(c, a);

      // Assert
      Assert.Equal(30, actual1);
      Assert.Equal(30, actual2);
    }

    [Fact]
    public void Return_30_Given_Graph_With_3_Vertexex_And_3_Edges()
    {
      // Arrange 
      var graph = new UndirectedGraph();

      var a = new Vertex("A");
      var b = new Vertex("B");
      var c = new Vertex("C");

      graph.AddVertex(a);
      graph.AddVertex(b);
      graph.AddVertex(c);

      graph.AddEdge(a, b, 10);
      graph.AddEdge(b, c, 20);
      graph.AddEdge(c, a, 30);

      // Act
      var actual1 = graph.FindMaxWeightedPath(a, c);
      var actual2 = graph.FindMaxWeightedPath(c, a);

      // Assert
      Assert.Equal(30, actual1);
      Assert.Equal(30, actual2);
    }

    [Fact]
    public void Return_10_Given_Graph_With_4_Vertexes()
    {
      // Arrange 
      var graph = new UndirectedGraph();

      var a = new Vertex("A");
      var b = new Vertex("B");
      var c = new Vertex("C");
      var d = new Vertex("D");

      graph.AddVertex(a);
      graph.AddVertex(b);
      graph.AddVertex(c);
      graph.AddVertex(d);

      graph.AddEdge(a, b, 1);
      graph.AddEdge(b, c, 2);
      graph.AddEdge(a, d, 3);
      graph.AddEdge(d, c, 4);

      // Act
      var actual = graph.FindMaxWeightedPath(a, c);

      // Assert
      Assert.Equal(7, actual);
    }
  }
}