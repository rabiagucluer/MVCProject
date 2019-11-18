using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class iletisim
    {
        public bool Iletisim_Insert(iletisimtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        iletisimtb iltsm = new iletisimtb();

                        iltsm.iletisimid = user.iletisimid;
                        iltsm.adres = user.adres;
                        iltsm.telefon = user.telefon;
                        iltsm.mail = user.mail;

                        se.iletisimtb.Add(iltsm);
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

        public bool Iletisim_Update(iletisimtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        iletisimtb iltsm = se.iletisimtb.FirstOrDefault(f => f.iletisimid == user.iletisimid);


                        iltsm.iletisimid = user.iletisimid;
                        iltsm.adres = user.adres;
                        iltsm.telefon = user.telefon;
                        iltsm.mail = user.mail;

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
        public bool Iletisim_Delete(iletisimtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        iletisimtb iltsm = se.iletisimtb.FirstOrDefault(f => f.iletisimid == user.iletisimid);

                        se.iletisimtb.Remove(iltsm);
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

        public List<iletisimtb> Iletisim_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<iletisimtb> iletisimlist = (from k in se.iletisimtb
                                         select new iletisimtb
                                         {
                                             iletisimid = k.iletisimid,
                                             adres = k.adres,
                                             telefon=k.telefon,
                                             mail=k.mail
                                         }).OrderBy(f => f.iletisimid).ToList();
                return iletisimlist;
            }
        }
        public List<iletisimtb> PIletisim_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<iletisimtb> iletisimlist = (from k in se.iletisimtb where k.iletisimid == y select k).ToList();

                return iletisimlist;
            }
        }

    }

}
