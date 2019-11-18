using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class biletdurum
    {
        public bool BiletDurum_Insert(biletdurumtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        biletdurumtb bltdrm = new biletdurumtb();

                        bltdrm.durumid = user.durumid;
                        bltdrm.durum = user.durum;

                        se.biletdurumtb.Add(bltdrm);
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

        public bool BiletDurum_Update(biletdurumtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        biletdurumtb bltdrm = se.biletdurumtb.FirstOrDefault(f => f.durumid == user.durumid);

                        bltdrm.durumid = user.durumid;
                        bltdrm.durum = user.durum;

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
        public bool BiletDurum_Delete(biletdurumtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        biletdurumtb bltdrm = se.biletdurumtb.FirstOrDefault(f => f.durumid == user.durumid);

                        se.biletdurumtb.Remove(bltdrm);
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

        public List<biletdurumtb> BiletDurum_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<biletdurumtb> biletdurumlist = (from k in se.biletdurumtb
                                                     select new biletdurumtb
                                                     {
                                                         durumid = k.durumid,
                                                         durum = k.durum
                                                     }).OrderBy(f => f.durumid).ToList();
                return biletdurumlist;
            }
        }
        public List<biletdurumtb> PBiletDurum_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<biletdurumtb> biletdurumlist = (from k in se.biletdurumtb where k.durumid == y select k).ToList();

                return biletdurumlist;
            }
        }

    }

}
