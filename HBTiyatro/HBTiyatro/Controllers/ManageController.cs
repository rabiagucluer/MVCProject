using HBTiyatro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HBTiyatro.Controllers
{
    public class ManageController : Controller
    {
        TIYATROEntities te = new TIYATROEntities();

        // GET: Manage
        public ActionResult Giris()
        {

            return View();
        }
        public ActionResult Cikis()
        {
            Session["EPosta"] = null;
            RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Kullanici model)
        {
            var kullanici = te.Kullanici.FirstOrDefault(x => x.EPosta == model.EPosta && x.Sifre == model.Sifre);
            if (kullanici !=null)
            {
                Session["EPosta"] = kullanici;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.HATA("KULLANICI ADI YA DA ŞİFRE YANLIŞTIR..");
            return View();
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
        public ActionResult Create(Kullanici USR)
        {
           if(ModelState.IsValid)
            {
                KullaniciTb TB = new KullaniciTb();
                TB.Kullanici_Insert(USR);

                return View(USR);
            }
            return View(USR);

        }
    }
}