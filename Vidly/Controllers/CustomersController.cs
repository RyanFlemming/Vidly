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
            var customers = CreateCustomers();
            //customers.Clear();

            return View(customers);
        }

        public IActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var customers = CreateCustomers();
                Customer customer = customers.Find(c => c.Id == id);
                return View(customer); 
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }
        }

        // To be replaced with seed method
        private static List<Customer> CreateCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };
        }
    }
}
