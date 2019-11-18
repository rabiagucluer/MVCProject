using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class FiyatTb
    {
        public bool Fiyat_Insert(Fiyat user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Fiyat fiyat = new Fiyat();

                        fiyat.FiyatId = user.FiyatId;
                        fiyat.TurID = user.TurID;
                        fiyat.Fiyat1 = user.Fiyat1;
                        fiyat.KDV = user.KDV;
                        fiyat.KarOrani = user.KarOrani;

                        te.Fiyat.Add(fiyat);
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

        public bool Fiyat_Update(Fiyat user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Fiyat fyt = te.Fiyat.FirstOrDefault(f => f.FiyatId == user.FiyatId);

                        fyt.FiyatId = user.FiyatId;
                        fyt.TurID = user.TurID;
                        fyt.Fiyat1 = user.Fiyat1;
                        fyt.KDV = user.KDV;
                        fyt.KarOrani = user.KarOrani;

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

        public bool Fiyat_Delete(Fiyat user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Fiyat fyt = te.Fiyat.FirstOrDefault(f => f.FiyatId == user.FiyatId);

                        te.Fiyat.Remove(fyt);
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

        public List<Fiyat> Fiyat_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Fiyat> fiyatlist = (from k in te.Fiyat
                                         select new Fiyat
                                         {
                                             FiyatId = k.FiyatId,
                                             TurID = k.TurID,
                                             Fiyat1 = k.Fiyat1,
                                             KDV = k.KDV,
                                             KarOrani = k.KarOrani

                                         }).OrderBy(f => f.FiyatId).ToList();
                return fiyatlist;
            }
        }

        public List<Fiyat> PFiyat_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Fiyat> fiyatlist = (from k in te.Fiyat where k.FiyatId == y select k).ToList();

                return fiyatlist;
            }
        }
    }
}