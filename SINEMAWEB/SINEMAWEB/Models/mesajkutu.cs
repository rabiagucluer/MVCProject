using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class mesajkutu
    {
        public bool Mesajkutu_Insert(mesajkututb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        mesajkututb msjkt = new mesajkututb();

                        msjkt.mesajid = user.mesajid;
                        msjkt.konu = user.konu;
                        msjkt.mesaj = user.mesaj;
                        msjkt.uyeid = user.uyeid;

                        msjkt.mesajtarihi = user.mesajtarihi;

                        se.mesajkututb.Add(msjkt);
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

        public bool Blok_Update(bloktb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bloktb blk = se.bloktb.FirstOrDefault(f => f.blokid == user.blokid);


                        blk.blokid = user.blokid;
                        blk.blokturu = user.blokturu;

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
        public bool Mesajkutu_Delete(mesajkututb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        mesajkututb msjkt = se.mesajkututb.FirstOrDefault(f => f.mesajid == user.mesajid);

                        se.mesajkututb.Remove(msjkt);
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

        public List<mesajkututb> Mesajkutu_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<mesajkututb> mesajkutulist = (from k in se.mesajkututb
                                         select new mesajkututb
                                         {
                                             mesajid = k.mesajid,
                                             konu = k.konu,
                                             mesaj=k.mesaj,
                                             uyeid=k.uyeid,
                                             mesajtarihi=k.mesajtarihi
                                         }).OrderBy(f => f.mesajid).ToList();
                return mesajkutulist;
            }
        }
        public List<mesajkututb> PBlok_Mesajkutu(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<mesajkututb> mesajkutulist = (from k in se.mesajkututb where k.mesajid == y select k).ToList();

                return mesajkutulist;
            }
        }

    }

}
