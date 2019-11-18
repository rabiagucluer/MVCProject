using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SINEMAWEB.Models;

namespace SINEMAWEB.Controllers
//{
//    public class ManageController : Controller
//    {
//        // GET: Manage





//        public ActionResult Cikis()
//        {
//            return View();
//        }

//        public ActionResult Giris()
//        {
//            return View();
//        }

{
    public class ManageController : Controller
    {
        SINEMADBEntities se = new SINEMADBEntities();

        // GET: Manage
        public ActionResult Giris()
        {

            return View();
        }
        public ActionResult Cikis()
        {
            Session["mail"] = null;
            RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public ActionResult Giris(uyetb model)
        {
            var uye = se.uyetb.FirstOrDefault(x => x.mail == model.mail && x.sifre == model.sifre);
            if (uye != null)
            {
                Session["mail"] = uye;
                return RedirectToAction("Index", "Home");
            }
            else { 
            ViewBag.HATA("KULLANICI ADI YA DA ŞİFRE YANLIŞTIR..");
            return View();
            }
        }
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(uyetb User)
        {
            if (ModelState.IsValid)
            {
                uye TB = new uye();
                TB.Uye_Insert(User);

                return View(User);
            }
            return View(User);

        }
    }







}