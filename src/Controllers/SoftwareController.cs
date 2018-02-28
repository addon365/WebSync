using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Addon365.WebSync.Controllers
{
    public class SoftwareController : Controller
    {
        public IActionResult Index()
        {
            var page = HttpContext.Items["cmspage"] as UrlMap;

            ViewBag.CurrentMenuItem = "Software";
            ViewBag.HeaderClass = "rst-header-banner rst-banner-background rst-banner-2";
                if (page.Author == "")
                ViewData["Author"] = page.Author;
            else
                ViewData["Author"] = "Priya";

            return View(page.PageName);
        }

        //[Route("software/vellore/{id?}")]
        //[Route("software/madurai")]
        //[Route("software/kanchipuram")]
      
        public IActionResult Cities(string id)
        {
                ViewBag.HeaderClass = "rst-header-banner rst-banner-background rst-banner-2";
            return View(FindView(id));
        }
        public IActionResult Software(string id)
        {
            ViewBag.HeaderClass = "rst-header-banner rst-banner-background rst-banner-2";
            return View(FindView(id));
        }
    
        private string FindView(string softwareName)
        {
            if (softwareName == null)
                return "Billing-Software";


            switch (softwareName.ToLower())
            {
                case "pawn-broker":
                    return "PawnBroker";

                case "pawnbroker":
                    return "PawnBroker";

                case "pawn-shop":
                    return "PawnBroker";

                case "pawn-brokers-shop-billing":
                    return "PawnBroker";

                case "jewellery":
                    return "vellore";

                default:
                    return "Billing-Software";
            }
        }
        //[Route("Software/pawn-broker")]
        //[Route("Software/pawnbroker")]
        //[Route("Software/pawn-shop")]
        //[Route("Software/pawn-broker-shop-billing")]
     /*   public IActionResult Pawnbroker()
        {
            ViewBag.HeaderClass = "rst-header-banner rst-banner-background rst-banner-2";
            return View("Pawnbroker");
        }
        */

    }
}