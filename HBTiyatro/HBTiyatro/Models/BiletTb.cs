using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class BiletTb
    {
        public bool Bilet_Insert(Bilet user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Bilet blt = new Bilet();

                        blt.BiletID = user.BiletID;
                        blt.KayitTarih = user.KayitTarih;
                        blt.KullaniciID = user.KullaniciID;
                        blt.BiletNo = user.BiletNo;
                        blt.OyunID = user.OyunID;
                        blt.SahneID = user.SahneID;
                        blt.FiyatID = user.FiyatID;
                        blt.KoltukID = user.KoltukID;
                        blt.BankaID = user.BankaID;
                        blt.BiletDurumID = user.BiletDurumID;

                        te.Bilet.Add(blt);
                        te.SaveChanges();
                        scope.Complete();
                        return true;
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                        return false;
                    }
                }
            }
        }

        public bool Bilet_Update(Bilet user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Bilet bilet = te.Bilet.FirstOrDefault(f => f.BiletID == user.BiletID);

                        bilet.BiletID = user.BiletID;
                        bilet.KayitTarih = user.KayitTarih;
                        bilet.KullaniciID = user.KullaniciID;
                        bilet.BiletNo = user.BiletNo;
                        bilet.OyunID = user.OyunID;
                        bilet.SahneID = user.SahneID;
                        bilet.FiyatID = user.FiyatID;
                        bilet.KoltukID = user.KoltukID;
                        bilet.BankaID = user.BankaID;
                        bilet.BiletDurumID = user.BiletDurumID;

                        te.SaveChanges();
                        scope.Complete();
                        return true;
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                        return false;
                    }
                }
            }
        }

        public bool Bilet_Delete(Bilet user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Bilet bilet = te.Bilet.FirstOrDefault(f => f.BiletID == user.BiletID);

                        te.Bilet.Remove(bilet);
                        te.SaveChanges();
                        scope.Complete();
                        return true;
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                        return false;
                    }
                }
            }
        }

        public List<Bilet> Bilet_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Bilet> biletlist = (from k in te.Bilet
                                         select new Bilet
                                         {
                                             BiletID = k.BiletID,
                                             KayitTarih = k.KayitTarih,
                                             KullaniciID = k.KullaniciID,
                                             BiletNo = k.BiletNo,
                                             OyunID = k.OyunID,
                                             SahneID = k.SahneID,
                                             FiyatID = k.FiyatID,
                                             KoltukID = k.KoltukID,
                                             BankaID = k.BankaID,
                                             BiletDurumID = k.BiletDurumID

                                         }).OrderBy(f => f.BiletID).ToList();
                return biletlist;
            }
        }

        public List<Bilet> PBilet_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Bilet> biletlist = (from k in te.Bilet where k.BiletID == y select k).ToList();

                return biletlist;
            }
        }
    }
}