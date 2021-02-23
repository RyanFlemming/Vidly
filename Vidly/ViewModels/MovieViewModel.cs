using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
