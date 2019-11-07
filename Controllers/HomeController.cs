using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mygarden.Models;

namespace mygarden.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GoProfile() {
            return RedirectToAction("Indique", "Profile");
        }

        public IActionResult GoSearch()
        {
            return RedirectToAction("buscada", "Search");
        }

    }
}
