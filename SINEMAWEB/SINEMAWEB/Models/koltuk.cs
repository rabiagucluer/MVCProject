using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class koltuk
    {
        public bool Koltuk_Insert(koltuktb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        koltuktb klk = new koltuktb();

                        klk.koltukid = user.koltukid;
                        klk.blokid = user.blokid;
                        klk.sahneid = user.sahneid;
                        klk.koltuknumarasi = user.koltuknumarasi;

                        se.koltuktb.Add(klk);
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

        public bool Koltuk_Update(koltuktb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        koltuktb klk = se.koltuktb.FirstOrDefault(f => f.koltukid == user.koltukid);


                        klk.koltukid = user.koltukid;
                        klk.blokid = user.blokid;
                        klk.sahneid = user.sahneid;
                        klk.koltuknumarasi = user.koltuknumarasi;

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
        public bool Koltuk_Delete(koltuktb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        koltuktb klk = se.koltuktb.FirstOrDefault(f => f.koltukid == user.koltukid);

                        se.koltuktb.Remove(klk);
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

        public List<koltuktb> Koltuk_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<koltuktb> koltuklist = (from k in se.koltuktb
                                             select new koltuktb
                                             {
                                                 koltukid = k.koltukid,
                                                 blokid = k.blokid,
                                                 sahneid = k.sahneid,
                                                 koltuknumarasi = k.koltuknumarasi
                                             }).OrderBy(f => f.koltukid).ToList();
                return koltuklist;
            }
        }
        public List<koltuktb> PKoltuk_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<koltuktb> koltuklist = (from k in se.koltuktb where k.koltukid == y select k).ToList();

                return koltuklist;
            }
        }

    }

}
