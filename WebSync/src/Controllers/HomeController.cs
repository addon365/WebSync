using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Addon365.WebSync.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            ViewBag.HeaderClass = "rst-header-banner rst-banner-background rst-banner-3 rst-index-page-banner";
            ViewBag.HeadLogo = "~/images/header-logo-1.png";
            ViewBag.HideNavBar = true;
            return View();
        }

        public IActionResult About()
        {
            ViewBag.CurrentMenuItem = "About";
            ViewData["Message"] = "Your application description page.";
            
            ViewBag.HeaderClass = "rst-header-banner rst-banner-background rst-banner-3";
            ViewBag.HeadLogo = "~/images/header-logo-1.png";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.CurrentMenuItem = "Contact";
            ViewData["Message"] = "Your contact page.";
            ViewBag.HeaderClass = "rst-header-banner rst-banner-background";
            ViewBag.HeadLogo = "~/images/header-logo-2.png";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
