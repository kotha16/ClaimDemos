using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClaimDemo1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var prin = ClaimsPrincipal.Current;
            if (prin != null)
            {
                foreach (Claim item in prin.Claims)
                {
                     ViewData[item.Type] = item.Value.ToString();
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}