using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MovieRepo;
using MovieLibrary.Models;

namespace MovieLibrary.Controllers
{
    public class MovieController : Controller
    {

        private IMovieRepository _movieRepository;

        public MovieController(IMovieRepository _movieRepository)
        {
            this._movieRepository = _movieRepository;
        }

        public MovieController()
        {
        }

        public ActionResult MovieListing()
        {
            IMovieRepository _movieRepository = new MovieRepository();
            var movieList = _movieRepository.GetListOfMovies("This");
            List<MovieLibrary.Models.Movie> viewMovie = new List<MovieLibrary.Models.Movie>();

            foreach (var movie in movieList)
            {
                viewMovie.Add(new MovieLibrary.Models.Movie { Title = movie.Title });
            }
           
            //Mapper.Map<Movie>(movie);
            return View("MovieListings",viewMovie);
        }

        public ActionResult Index()
        {
            return View("MovieHome");
        }

    }
}
