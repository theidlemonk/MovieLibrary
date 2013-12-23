using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace MovieRepo
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> GetMovieSearchResultsByTitle(string MovieSearchTitle)
        {

            //HttpWebRequest request = WebRequest.Create("http://www.omdbapi.com/?s=" + MovieSearchTitle + "&r=XML") as HttpWebRequest;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //WebHeaderCollection header = response.Headers;

            //var encoding = ASCIIEncoding.ASCII;
            //using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding)) 
            //{
            //    string responseText = reader.ReadToEnd();
            //}

            List<Movie> movies = new List<Movie>();

            //if (MovieSearchTitle.ToUpper() == "THIS")
            //{ 
            Movie movie = new Movie();
            movie.Title = "Analyse This";
            movie.Year = 2012;

            movies.Add(movie);
            return movies;

            //}


        }

        public List<Movie> GetListOfMovies(string MovieSearchTitleText)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(GetBaseDirectoryPath() + "\\MovieLibrary\\MovieRepo\\MovieList.xml");

            List<Movie> movieList = new List<Movie>();
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                //string movie = node.Attributes["title"].Value;
                movieList.Add(new Movie { Title = node.Attributes["title"].Value });
            }
            return movieList;
        }

        private static string GetBaseDirectoryPath()
        {
            string wholeDir = AppDomain.CurrentDomain.BaseDirectory;
            return wholeDir.Substring(0, wholeDir.IndexOf("MovieLibrary") - 1);
        }
    }
}