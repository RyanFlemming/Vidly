using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Movie
    {
        // to do: add vm's
        // use data annotations to format date

        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public byte NumInStock { get; set; }
    }
}
