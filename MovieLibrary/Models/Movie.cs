using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rating { get; set; }
        public DateTime Released { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string MovieId { get; set; }
    }

    //class Reviews
    //{
    //    public string MovieId { get; set; }
    //    public string Review { get; set; }
    //    public string User { get; set; }
    //}
}