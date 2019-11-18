using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class salo
    {
        public bool Salon_Insert(salon user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        salon sln = new salon();

                        sln.salonid = user.salonid;

                        se.salon.Add(sln);
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

        public bool Salon_Update(salon user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        salon sln = se.salon.FirstOrDefault(f => f.salonid == user.salonid);


                        sln.salonid = user.salonid;

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
        public bool Salon_Delete(salon user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        salon sln = se.salon.FirstOrDefault(f => f.salonid == user.salonid);

                        se.salon.Remove(sln);
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

        public List<salon> Salon_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<salon> salonlist = (from k in se.salon
                                         select new salon
                                         {
                                             salonid = k.salonid
                                         }).OrderBy(f => f.salonid).ToList();
                return salonlist;
            }
        }
        public List<salon> PSalon_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<salon> salonlist = (from k in se.salon where k.salonid == y select k).ToList();

                return salonlist;
            }
        }

    }

}
