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
            string movieDetails = "";
            HttpWebRequest request = WebRequest.Create("http://www.omdbapi.com/?s=" + MovieSearchTitleText + "&r=XML") as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebHeaderCollection header = response.Headers;

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                movieDetails = reader.ReadToEnd();
            }


            XmlDocument xml = new XmlDocument();
            xml.LoadXml(movieDetails);
            XmlNodeList xnList = xml.SelectNodes("/root/Movie");
            List<Movie> movieResults = new List<Movie>();
            foreach (XmlNode xn in xnList)
            {
                movieResults.Add(new Movie { Title = xn.Attributes["Title"].Value });
                movieResults.Add(new Movie { Year = xn.Attributes["Year"].Value });
                movieResults.Add(new Movie { MovieId = xn.Attributes["imdbID"].Value });
                movieResults.Add(new Movie { Type = xn.Attributes["Type"].Value });

            }
            return movieResults;
        }

        //private static string GetBaseDirectoryPath()
        //{
        //    string wholeDir = AppDomain.CurrentDomain.BaseDirectory;
        //    return wholeDir.Substring(0, wholeDir.IndexOf("MovieLibrary") - 1);
        //}
    }
}