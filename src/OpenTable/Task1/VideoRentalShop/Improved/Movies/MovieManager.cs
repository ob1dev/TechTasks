using System.Collections.Generic;

namespace TechTasks.Improved.Movies
{
  class MovieManager
  {
    private List<IMovie> moviesList;

    public MovieManager()
    {
      this.moviesList = new List<IMovie>();
    }

    public void Add(IMovie movie)
    {
      this.moviesList.Add(movie);
    }

    public void Remove(IMovie movie)
    {
      this.moviesList.Remove(movie);
    }

    public IMovie Find(string title)
    {
      return this.moviesList.Find(movie => movie.Title.Equals(title));
    }
  }
}