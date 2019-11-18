using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class kullanicitur
    {
        public bool Kullanicituru_Insert(kullanicituru user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        kullanicituru ktr = new kullanicituru();

                        ktr.kulturid = user.kulturid;
                        ktr.kullanicitur = user.kullanicitur;
                        ktr.indirimorani = user.indirimorani;

                        se.kullanicituru.Add(ktr);
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

        public bool Kullanicituru_Update(kullanicituru user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        kullanicituru ktr = se.kullanicituru.FirstOrDefault(f => f.kulturid == user.kulturid);


                        ktr.kulturid = user.kulturid;
                        ktr.kullanicitur = user.kullanicitur;
                        ktr.indirimorani = user.indirimorani;

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
        public bool Kullanicituru_Delete(kullanicituru user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        kullanicituru ktr = se.kullanicituru.FirstOrDefault(f => f.kulturid == user.kulturid);

                        se.kullanicituru.Remove(ktr);
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

        public List<kullanicituru> Kullanicituru_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<kullanicituru> kulaniciturulist = (from k in se.kullanicituru
                                         select new kullanicituru
                                         {
                                             kulturid = k.kulturid,
                                             kullanicitur = k.kullanicitur,
                                             indirimorani=k.indirimorani
                                         }).OrderBy(f => f.kulturid).ToList();
                return kulaniciturulist;
            }
        }
        public List<kullanicituru> PKullanicituru_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<kullanicituru> kullaniciturulist = (from k in se.kullanicituru where k.kulturid == y select k).ToList();

                return kullaniciturulist;
            }
        }

    }

}
