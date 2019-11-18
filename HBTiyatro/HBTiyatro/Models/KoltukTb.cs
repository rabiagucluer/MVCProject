using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class KoltukTb
    {
        public bool Koltuk_Insert(Koltuk user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Koltuk kltk = new Koltuk();

                        kltk.KoltukID = user.KoltukID;
                        kltk.BlokID = user.BlokID;
                        kltk.SahneID = user.SahneID;
                        kltk.KoltukNumarasi = user.KoltukNumarasi;

                        te.Koltuk.Add(kltk);
                        te.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
            return true;
        }

        public bool Koltuk_Update(Koltuk user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Koltuk koltuk = te.Koltuk.FirstOrDefault(f => f.KoltukID == user.KoltukID);

                        koltuk.KoltukID = user.KoltukID;
                        koltuk.BlokID = user.BlokID;
                        koltuk.SahneID = user.SahneID;
                        koltuk.KoltukNumarasi = user.KoltukNumarasi;

                        te.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
            return true;
        }

        public bool Koltuk_Delete(Koltuk user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Koltuk koltuk = te.Koltuk.FirstOrDefault(f => f.KoltukID == user.KoltukID);

                        te.Koltuk.Remove(koltuk);
                        te.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
            return true;
        }

        public List<Koltuk> Koltuk_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Koltuk> koltuklist = (from k in te.Koltuk
                                           select new Koltuk
                                           {
                                               KoltukID = k.KoltukID,
                                               BlokID = k.BlokID,
                                               SahneID = k.SahneID,
                                               KoltukNumarasi = k.KoltukNumarasi

                                           }).OrderBy(f => f.KoltukID).ToList();
                return koltuklist;
            }
        }

        public List<Koltuk> PKoltuk_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Koltuk> koltuklist = (from k in te.Koltuk where k.KoltukID == y select k).ToList();

                return koltuklist;
            }
        }
    }
}