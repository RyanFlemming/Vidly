using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {

            var customers = new List<Customer>
            {
                new Customer {Id= 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer {Id= 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };

            Customer customer = customers.Find(c => c.Id == id);
            

            return View(customer);
        }
    }
}
