using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // Getting our DbContext object
        private VidlyContext vidlyContext;

        protected override void Dispose(bool disposing)
        {
            vidlyContext.Dispose();
        }

        public CustomersController(VidlyContext vc)
        {
            vidlyContext = vc;
        }
        public IActionResult Index()
        {
            var customers = vidlyContext.Customers.Include((c)=> c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            // Refactor later
            if (ModelState.IsValid)
            {
                var customer = vidlyContext.Customers.SingleOrDefault((c)=>c.Id == id);
                return View(customer); 
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }
        }
    }
}
