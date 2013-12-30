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

        public ActionResult GetMoviesFromKeyword(string movieKeyword)
        {
            IMovieRepository _movieRepository = new MovieRepository();
            var movieList = _movieRepository.GetListOfPossibleMovies(movieKeyword);
            List<MovieLibrary.Models.Movie> viewMovie = new List<MovieLibrary.Models.Movie>();

            if (movieList.Count() == 0)
            {
                viewMovie.Add(new MovieLibrary.Models.Movie
                {
                    MovieKeyword = movieKeyword
                });
            }
            else
            {
                foreach (var movie in movieList)
                {
                    if (movie.Type == "movie")
                    {
                        viewMovie.Add(new MovieLibrary.Models.Movie
                        {
                            Title = movie.Title,
                            MovieId = movie.MovieId,
                            Type = movie.Type,
                            Year = movie.Year,
                            MovieKeyword = movieKeyword
                        });
                    }
                }
            }

            Session["searchResults"] = viewMovie;
            return View("MovieHome", viewMovie);
        }

        public ActionResult GetMovieDetailsFromMovieId(string MovieId)
        {
            IMovieRepository _movieRepository = new MovieRepository();
            var movieDetails = _movieRepository.GetMovieDetailsFromId(MovieId);
            List<MovieLibrary.Models.Movie> viewMovieDetails = new List<MovieLibrary.Models.Movie>();

            foreach (var movie in movieDetails)
            {
                viewMovieDetails.Add(new MovieLibrary.Models.Movie
                {

                    Title = movie.Title,
                    Year = movie.Year,
                    MovieId = movie.MovieId,
                    Type = movie.Type,
                    Poster = movie.Poster,
                    Plot = movie.Plot,
                    Genre = movie.Genre,
                    Actors = movie.Actors,
                    Rating = movie.Rating,
                    Released = movie.Released


                });
            }

            return View("MovieDetails", viewMovieDetails);

        }

        public ActionResult Index()
        {
            ModelState.Clear();
            Session["searchResults"] = null;
            return View("MovieHome");
        }

        public ActionResult ShowSearchResultsPage()
        {
            List<MovieLibrary.Models.Movie> products = Session["searchResults"] as List<MovieLibrary.Models.Movie>;
            return View("MovieHome", products);
        }

    }
}
