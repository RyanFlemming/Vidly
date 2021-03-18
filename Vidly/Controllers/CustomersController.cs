using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using Vidly.Models;
using Vidly.ViewModels;

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
            var customers = vidlyContext.Customers.Include((c) => c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            // Refactor later
            if (ModelState.IsValid)
            {
                var customer = vidlyContext.Customers.SingleOrDefault((c) => c.Id == id);
                return View(customer);
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public IActionResult New()
        {
            IEnumerable<SelectListItem> selMembershipTypes = from m in vidlyContext.MembershipTypes
                                                             select new SelectListItem
                                                             {
                                                                 Text = m.Name,
                                                                 Value = m.Id.ToString()
                                                             };
            var viewModel = new CustomerFormViewModel() { MemSelectListItems = selMembershipTypes };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                vidlyContext.Add(customer);
            }
            else
            {
                var customerInDb = vidlyContext.Customers.Single((c) => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            vidlyContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Edit(int id)
        {
            var customer = vidlyContext.Customers.SingleOrDefault((c) => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> selMembershipTypes = from m in vidlyContext.MembershipTypes
                                                             select new SelectListItem
                                                             {
                                                                 Text = m.Name,
                                                                 Value = m.Id.ToString(),
                                                                 Selected = m.Id == id
                                                             };


            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemSelectListItems = selMembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}
