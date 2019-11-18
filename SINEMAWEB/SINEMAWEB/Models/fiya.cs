using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class fiya
    {
        public bool Fiyat_Insert(fiyat user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        fiyat fyt = new fiyat();

                        fyt.fiyatid = user.fiyatid;
                        fyt.turid = user.turid;
                        fyt.fiyat1 = user.fiyat1;

                        se.fiyat.Add(fyt);
                        se.SaveChanges();
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

        public bool Fiyat_Update(fiyat user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        fiyat fyt = se.fiyat.FirstOrDefault(f => f.fiyatid == user.fiyatid);



                        fyt.fiyatid = user.fiyatid;
                        fyt.turid = user.turid;
                        fyt.fiyat1 = user.fiyat1;

                        se.SaveChanges();
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
        public bool Fiyat_Delete(fiyat user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        fiyat fyt = se.fiyat.FirstOrDefault(f => f.fiyatid == user.fiyatid);

                        se.fiyat.Remove(fyt);
                        se.SaveChanges();
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

        public List<fiyat> Fiyat_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<fiyat> fiyatlist = (from k in se.fiyat
                                                 select new fiyat
                                                 {
                                                     fiyatid = k.fiyatid,
                                                     turid = k.turid,
                                                     fiyat1=k.fiyat1
                                                 }).OrderBy(f => f.fiyatid).ToList();
                return fiyatlist;
            }
        }
        public List<fiyat> PFiyat_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<fiyat> fiyatlist = (from k in se.fiyat where k.fiyatid == y select k).ToList();

                return fiyatlist;
            }
        }

    }

}
