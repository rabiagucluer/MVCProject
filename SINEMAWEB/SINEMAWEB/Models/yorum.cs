using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class yorum
    {
        public bool Yorum_Insert(yorumtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        yorumtb yrm = new yorumtb();

                        yrm.yorumid = user.yorumid;
                        yrm.yorum = user.yorum;
                        yrm.uyeid = user.uyeid;
                        yrm.yorumtarih = user.yorumtarih;

                        yrm.filmid = user.filmid;

                        se.yorumtb.Add(yrm);
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

        public bool Yorum_Update(yorumtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        yorumtb yrm = se.yorumtb.FirstOrDefault(f => f.yorumid == user.yorumid);

                        yrm.yorumid = user.yorumid;
                        yrm.yorum = user.yorum;
                        yrm.uyeid = user.uyeid;
                        yrm.yorumtarih = user.yorumtarih;

                        yrm.filmid = user.filmid;

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
        public bool Yorum_Delete(yorumtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        yorumtb yrm = se.yorumtb.FirstOrDefault(f => f.yorumid == user.yorumid);

                        se.yorumtb.Remove(yrm);
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

        public List<yorumtb> Yorum_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<yorumtb> yorumlist = (from k in se.yorumtb
                                         select new yorumtb
                                         {
                                             yorumid = k.yorumid,
                                             yorum = k.yorum,
                                             uyeid=k.uyeid,
                                             yorumtarih=k.yorumtarih,
                                             filmid=k.filmid
                                         }).OrderBy(f => f.yorumid).ToList();
                return yorumlist;
            }
        }
        public List<yorumtb> PYorum_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<yorumtb> yorumlist = (from k in se.yorumtb where k.yorumid == y select k).ToList();

                return yorumlist;
            }
        }

    }

}
