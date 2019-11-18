using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class blok
    {
        public bool Blok_Insert(bloktb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bloktb blk = new bloktb();

                        blk.blokid = user.blokid;
                        blk.blokturu = user.blokturu;

                        se.bloktb.Add(blk);
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
        public bool Blok_Delete(bloktb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bloktb blk = se.bloktb.FirstOrDefault(f => f.blokid == user.blokid);

                        se.bloktb.Remove(blk);
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

        public List<bloktb> Blok_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<bloktb> bloklist = (from k in se.bloktb
                                                     select new bloktb
                                                     {
                                                         blokid = k.blokid,
                                                         blokturu = k.blokturu
                                                     }).OrderBy(f => f.blokid).ToList();
                return bloklist;
            }
        }
        public List<bloktb> PBlok_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<bloktb> bloklist = (from k in se.bloktb where k.blokid == y select k).ToList();

                return bloklist;
            }
        }

    }

}
