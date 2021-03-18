﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<SelectListItem> Genres { get; set; }
        public Movie Movie { get; set; }

        //public string Title
        //{
        //    get
        //    {
        //        if (Movie != null && Movie.Id != 0)
        //        {
        //            return "Edit Movie";
        //        }

        //        return "New Movie";
        //    }
        //}
    }
}
