using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRepo
{
    public interface IMovieRepository 
    {
         List<Movie> GetMovieSearchResultsByTitle(string MovieSearchTitle);
         List<Movie> GetListOfMovies(string MovieSearchTitleText);
    }
}