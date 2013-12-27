using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRepo
{
    public interface IMovieRepository
    {
        List<Movie> GetListOfPossibleMovies(string MovieSearchTitleText);
        List<Movie> GetMovieDetailsFromId(string MovieId);
    }
}