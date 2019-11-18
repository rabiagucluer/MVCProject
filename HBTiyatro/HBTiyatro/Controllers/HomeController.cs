using HBTiyatro.Models;
using HBTiyatro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HBTiyatro.Controllers
{
    public class HomeController : Controller
    {
        TIYATROEntities te = new TIYATROEntities();
        // GET: Home
        public ActionResult Index()
        {

            SehirViewModel model = new SehirViewModel();
            List<Ilceler> ilcelist = te.Ilceler.OrderBy(m => m.IlceAdi).ToList();
            model.ilcelist = (from s in ilcelist
                              select new SelectListItem
                              {
                                  Selected = false,
                                  Text = s.IlceAdi,
                                  Value = s.IlcelerID.ToString()
                              }).ToList();
            model.ilcelist.Insert(0, new SelectListItem { Text = "--Seciniz--", Value = " ", Selected = true });
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(SehirViewModel model)
        {
            return View();
        }
        public void inneryapma()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                var dene = (from i in te.Ilceler
                            join a in te.Adres
                            on i.IlcelerID equals a.IlceNo

                            join t in te.Tiyatrolar
                            on a.AdresID equals t.AdresID
                            orderby (i.IlceAdi)
                            select new
                            {
                                IlcelerID = i.IlcelerID,
                                IlceAdi = i.IlceAdi,
                                Adres = a.Adres1,
                                TiyatroAdi = t.TiyatroAdi

                            });
            }
            te.SaveChanges();
        }
        [HttpPost]
        public JsonResult Tiyatrolist(int id)
        {
            SehirViewModel model = new SehirViewModel();
            
            List<Tiyatrolar> tiyatroList = te.Tiyatrolar.Where(f => f.AdresID == id).OrderBy(f => f.TiyatroAdi).ToList();
            List<SelectListItem> itemlist = (from a in tiyatroList
                                             select new SelectListItem
                                             {
                                                 Selected=false,
                                                 Value = a.TiyatroID.ToString(),
                                                 Text = a.TiyatroAdi

                                             }).ToList();
            
            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Sahnelist(int id)
        {
            SehirViewModel model = new SehirViewModel();
            //List<Sahneler> Sahnelist = te.Sahneler.OrderBy(m => m.SahneAdi).ToList();
            //model.Sahnelist = (from k in Sahnelist
            //                   select new SelectListItem
            //                  {
            //                      Selected = false,
            //                      Text = k.SahneAdi,
            //                      Value = k.SahneId.ToString()
            //                  }).ToList();
            //model.Sahnelist.Insert(0, new SelectListItem { Text = "Seciniz", Value = " ", Selected = true });

            List<Sahneler> sahneList = te.Sahneler.Where(f => f.SahneId == id).OrderBy(f => f.SahneAdi).ToList();
            List<SelectListItem> listitem = (from b in sahneList
                                             select new SelectListItem
                                             {
                                                 Selected = false,
                                                 Text = b.SahneAdi,
                                                 Value = b.SahneId.ToString()
                                             }).ToList();
            return Json(listitem, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Oyunlar()
        {
            return View();
        }
        public ActionResult Oyuncular()
        {
            return View();
        }
        public ActionResult Hakkimizda()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Iletisim()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Antakya()
        {
            return View();
        }
        public ActionResult Iskenderun()
        {
            return View();
        }
        public ActionResult Defne()
        {
            return View();
        }
    }
}