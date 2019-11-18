using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class seans
    {
        public bool Seans_Insert(seanstb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        seanstb sns = new seanstb();

                        sns.seansid = user.seansid;
                        sns.filmyayintarihi = user.filmyayintarihi;
                        sns.filmsonyayintarihi = user.filmsonyayintarihi;
                        sns.saat1 = user.saat1;
                        sns.saat2 = user.saat2;
                        sns.saat3 = user.saat3;

                        se.seanstb.Add(sns);
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

        public bool Seans_Update(seanstb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        seanstb sns = se.seanstb.FirstOrDefault(f => f.seansid == user.seansid);



                        sns.seansid = user.seansid;
                        sns.filmyayintarihi = user.filmyayintarihi;
                        sns.filmsonyayintarihi = user.filmsonyayintarihi;
                        sns.saat1 = user.saat1;
                        sns.saat2 = user.saat2;
                        sns.saat3 = user.saat3;

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
        public bool Seans_Delete(seanstb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        seanstb sns = se.seanstb.FirstOrDefault(f => f.seansid == user.seansid);

                        se.seanstb.Remove(sns);
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

        public List<seanstb> Seans_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<seanstb> seanslist = (from k in se.seanstb
                                         select new seanstb
                                         {
                                             seansid = k.seansid,
                                             filmyayintarihi = k.filmyayintarihi,
                                             filmsonyayintarihi=k.filmsonyayintarihi,
                                             saat1=k.saat1,
                                             saat2=k.saat2,
                                             saat3=k.saat3
                                         }).OrderBy(f => f.seansid).ToList();
                return seanslist;
            }
        }
        public List<seanstb> PSeans_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<seanstb> seanslist = (from k in se.seanstb where k.seansid == y select k).ToList();

                return seanslist;
            }
        }

    }

}
