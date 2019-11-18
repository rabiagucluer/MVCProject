using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class uye
    {
        public bool Uye_Insert(uyetb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        uyetb uy = new uyetb();

                        uy.uyeid = user.uyeid;
                        uy.ad = user.ad;
                        uy.soyad = user.soyad;
                        uy.mail = user.mail;
                        uy.uyetelefon = user.uyetelefon;
                        uy.sifre = user.sifre;
                        uy.kullaniciturid = user.kullaniciturid;
                        uy.tcno = user.tcno;

                        se.uyetb.Add(uy);
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

        public bool Uye_Update(uyetb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        uyetb uy = se.uyetb.FirstOrDefault(f => f.uyeid == user.uyeid);


                        uy.uyeid = user.uyeid;
                        uy.ad = user.ad;
                        uy.soyad = user.soyad;
                        uy.mail = user.mail;
                        uy.uyetelefon = user.uyetelefon;
                        uy.sifre = user.sifre;
                        uy.kullaniciturid = user.kullaniciturid;
                        uy.tcno = user.tcno;

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
        public bool Uye_Delete(uyetb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        uyetb uy = se.uyetb.FirstOrDefault(f => f.uyeid == user.uyeid);

                        se.uyetb.Remove(uy);
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

        public List<uyetb> Uye_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<uyetb> uyelist = (from k in se.uyetb
                                       select new uyetb
                                       {
                                           uyeid = k.uyeid,
                                           ad = k.ad,
                                           soyad = k.soyad,
                                           mail = k.mail,
                                           uyetelefon = k.uyetelefon,
                                           sifre = k.sifre,
                                           kullaniciturid = k.kullaniciturid,
                                           tcno = k.tcno

                                       }).OrderBy(f => f.uyeid).ToList();
                return uyelist;
            }
        }
        public List<uyetb> PUye_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<uyetb> uyelist = (from k in se.uyetb where k.uyeid == y select k).ToList();

                return uyelist;
            }
        }

    }

}
