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
    public void Return_10_Given_Graph_With_4_Vertexes_And_4_Edges()
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
      var actual1 = graph.FindMaxWeightedPath(a, c);
      var actual2 = graph.FindMaxWeightedPath(c, a);

      // Assert
      Assert.Equal(7, actual1);
      Assert.Equal(7, actual2);
    }

    [Fact]
    public void Return_100_Given_Graph_With_4_Vertexes_5_Edges()
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

      graph.AddEdge(a, b, 10);
      graph.AddEdge(b, c, 20);
      graph.AddEdge(a, d, 30);
      graph.AddEdge(d, c, 40);
      graph.AddEdge(b, d, 50);

      // Act
      var actual1 = graph.FindMaxWeightedPath(a, c);
      var actual2 = graph.FindMaxWeightedPath(c, a);

      // Assert
      Assert.Equal(100, actual1);
      Assert.Equal(100, actual2);
    }

    [Fact]
    public void Return_70_Given_Graph_With_6_Vertexes_7_Edges()
    {
      // Arrange 
      var graph = new UndirectedGraph();

      var a = new Vertex("A");
      var b = new Vertex("B");
      var c = new Vertex("C");
      var d = new Vertex("D");
      var e = new Vertex("E");
      var f = new Vertex("F");

      graph.AddVertex(a);
      graph.AddVertex(b);
      graph.AddVertex(c);
      graph.AddVertex(d);
      graph.AddVertex(e);
      graph.AddVertex(f);

      graph.AddEdge(a, b, 10);
      graph.AddEdge(b, c, 20);
      graph.AddEdge(c, e, 40);
      graph.AddEdge(e, f, 10);

      graph.AddEdge(b, d, 30);
      graph.AddEdge(d, e, 50);
      graph.AddEdge(c, d, 60);

      // Act
      var actual1 = graph.FindMaxWeightedPath(a, f);
      var actual2 = graph.FindMaxWeightedPath(f, a);

      // Assert
      Assert.Equal(150, actual1);
      Assert.Equal(150, actual2);
    }
  }
}