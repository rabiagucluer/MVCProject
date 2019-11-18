using HBTiyatro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HBTiyatro.ViewModel
{
    public class SehirViewModel
    {
        public SehirViewModel()
        {
            this.Tiyatrolist = new List<SelectListItem>();
            Tiyatrolist.Add(new SelectListItem { Selected = true, Text = "--Seciniz--", Value = " " });
            this.Sahnelist = new List<SelectListItem>();
            Sahnelist.Add(new SelectListItem { Selected = true, Text = "--Seciniz--", Value = " " });
        }
        public int IlcelerID { get; set; }
        public int TiyatroID { get; set; }
        public int AdresID { get; set; }
        public int SahneId { get; set; }

        public List<SelectListItem> ilcelist { get; set; }
        public List<SelectListItem> Tiyatrolist { get; set; }
        public List<SelectListItem> Sahnelist { get; set; }
    }
}