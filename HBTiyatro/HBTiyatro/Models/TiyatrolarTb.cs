using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class TiyatrolarTb
    {
        public bool Tiyatro_Insert(Tiyatrolar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Tiyatrolar tytr = new Tiyatrolar();

                        tytr.TiyatroID = user.TiyatroID;
                        tytr.TiyatroAdi = user.TiyatroAdi;
                        tytr.AdresID = user.AdresID;

                        te.Tiyatrolar.Add(tytr);
                        te.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Tiyatro_Update(Tiyatrolar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Tiyatrolar tiyatro = te.Tiyatrolar.FirstOrDefault(f => f.TiyatroID == user.TiyatroID);

                        tiyatro.TiyatroID = user.TiyatroID;
                        tiyatro.TiyatroAdi = user.TiyatroAdi;
                        tiyatro.AdresID = user.AdresID;

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

        public bool Tiyatro_Delete(Tiyatrolar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Tiyatrolar tiyatro = te.Tiyatrolar.FirstOrDefault(f => f.TiyatroID == user.TiyatroID);

                        te.Tiyatrolar.Remove(tiyatro);
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

        public List<Tiyatrolar> Tiyatro_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Tiyatrolar> tiyatrolist = (from k in te.Tiyatrolar
                                                select new Tiyatrolar
                                                {
                                                    TiyatroID = k.TiyatroID,
                                                    TiyatroAdi = k.TiyatroAdi,
                                                    AdresID = k.AdresID

                                                }).OrderBy(f => f.TiyatroID).ToList();
                return tiyatrolist;
            }
        }

        public List<Tiyatrolar> PTiyatro_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Tiyatrolar> tiyatrolist = (from k in te.Tiyatrolar where k.TiyatroID == y select k).ToList();

                return tiyatrolist;
            }
        }
        
    }
}