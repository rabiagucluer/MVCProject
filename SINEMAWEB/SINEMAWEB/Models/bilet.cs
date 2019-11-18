using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class bilet
    {
        public bool Bilet_Insert(bilettb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bilettb blt = new bilettb();

                        blt.biletid = user.biletid;
                        blt.kayittarih = user.kayittarih;
                        blt.uyeid = user.uyeid;
                        blt.biletkayittarih = user.biletkayittarih;
                        blt.filmid = user.filmid;
                        blt.sahneid = user.sahneid;
                        blt.koltukid = user.koltukid;
                        blt.biletdurumid = user.biletdurumid;
                        blt.gorevliid = user.gorevliid;
                        blt.bankaid = user.bankaid;


                        se.bilettb.Add(blt);
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
        public bool Bilet_Update(bilettb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bilettb blt = se.bilettb.FirstOrDefault(f => f.biletid == user.biletid);

                        blt.biletid = user.biletid;
                        blt.kayittarih = user.kayittarih;
                        blt.uyeid = user.uyeid;
                        blt.biletkayittarih = user.biletkayittarih;
                        blt.filmid = user.filmid;
                        blt.sahneid = user.sahneid;
                        blt.koltukid = user.koltukid;
                        blt.biletdurumid = user.biletdurumid;
                        blt.gorevliid = user.gorevliid;
                        blt.bankaid = user.bankaid;

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
        public bool Bilet_Delete(bilettb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bilettb blt = se.bilettb.FirstOrDefault(f => f.biletid == user.biletid);

                        se.bilettb.Remove(blt);
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

        public List<bilettb> Bilet_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<bilettb> biletlist = (from k in se.bilettb
                                           select new bilettb
                                           {

                                               biletid = k.biletid,
                                               kayittarih = k.kayittarih,
                                               uyeid = k.uyeid,
                                               biletkayittarih = k.biletkayittarih,
                                               filmid = k.filmid,
                                               sahneid = k.sahneid,
                                               koltukid = k.koltukid,
                                               biletdurumid = k.biletdurumid,
                                               gorevliid = k.gorevliid,
                                               bankaid = k.bankaid

                                           }).OrderBy(f => f.biletid).ToList();
                return biletlist;
            }
        }

        public List<bilettb> PBilet_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<bilettb> biletlist = (from k in se.bilettb where k.biletid == y select k).ToList();

                return biletlist;
            }
        }
    }

}
