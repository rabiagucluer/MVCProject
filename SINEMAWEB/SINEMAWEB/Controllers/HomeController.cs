using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SINEMAWEB.Controllers
{
    public class HomeController : Controller
    {



        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filmler()
        {
            return View();
        }

        public ActionResult Gosterimdekiler()
        {
            ViewBag.Message = "Your application description page.";
          
            return View();
        }


        public ActionResult Yakinda()
        {
            return View();
        }



        public ActionResult Iletisim()
        {
            return View();
        }


      



    }
}