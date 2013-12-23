using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MovieRepo;

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
            var movie = _movieRepository.GetListOfMovies("This");
            List<Movie> viewMovie = new List<Movie>(movie);
           
            //Mapper.Map<Movie>(movie);
            return View("MovieListings");
        }

        public ActionResult Index()
        {
            return View("MovieHome");
        }

    }
}
