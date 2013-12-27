using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace MovieRepo
{
    public class MovieRepository : IMovieRepository
    {


        public List<Movie> GetListOfPossibleMovies(string MovieSearchTitleText)
        {
            string movieResultsResponse = "";
            HttpWebRequest request = WebRequest.Create("http://www.omdbapi.com/?s=" + MovieSearchTitleText + "&r=XML") as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebHeaderCollection header = response.Headers;

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                movieResultsResponse = reader.ReadToEnd();
            }


            XmlDocument xml = new XmlDocument();
            xml.LoadXml(movieResultsResponse);
            XmlNodeList xnList = xml.SelectNodes("/root/Movie");
            List<Movie> movieResults = new List<Movie>();
            foreach (XmlNode xn in xnList)
            {
                movieResults.Add(new Movie
                {
                    Title = xn.Attributes["Title"].Value,
                    Year = xn.Attributes["Year"].Value,
                    MovieId = xn.Attributes["imdbID"].Value,
                    Type = xn.Attributes["Type"].Value
                });

            }
            return movieResults;
        }

        public List<Movie> GetMovieDetailsFromId(string MovieId)
        {
            string movieDetailsResponse = "";
            HttpWebRequest request = WebRequest.Create("http://www.omdbapi.com/?i=" + MovieId + "&r=XML") as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebHeaderCollection header = response.Headers;

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                movieDetailsResponse = reader.ReadToEnd();
            }


            XmlDocument xml = new XmlDocument();
            xml.LoadXml(movieDetailsResponse);
            XmlNodeList xnList = xml.SelectNodes("/root/movie");
            List<Movie> movieDetails = new List<Movie>();
            Movie movie = new Movie();
            foreach (XmlNode xn in xnList)
            {
                movieDetails.Add(new Movie
                {
                    Title = xn.Attributes["title"].Value,
                    Year = xn.Attributes["year"].Value,
                    MovieId = xn.Attributes["imdbID"].Value,
                    Type = xn.Attributes["type"].Value,
                    Poster = xn.Attributes["poster"].Value,
                    Plot = xn.Attributes["plot"].Value,
                    Genre = xn.Attributes["genre"].Value,
                    Actors = xn.Attributes["actors"].Value,
                    Rating = xn.Attributes["rated"].Value,
                    Released = xn.Attributes["released"].Value
                });

            }
            return movieDetails;
        }
    }
}