using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class BiletDurumTb
    {
        public bool Ilce_Insert(Ilceler user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Ilceler ilce = new Ilceler();

                        ilce.IlcelerID = user.IlcelerID;
                        ilce.IlceAdi = user.IlceAdi;

                        te.Ilceler.Add(ilce);
                        te.SaveChanges();
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

        public bool Ilce_Update(Ilceler user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Ilceler ilceler = te.Ilceler.FirstOrDefault(f => f.IlcelerID == user.IlcelerID);

                        ilceler.IlcelerID = user.IlcelerID;
                        ilceler.IlceAdi = user.IlceAdi;

                        te.SaveChanges();
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

        public bool Ilce_Delete(Ilceler user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Ilceler ilceler = te.Ilceler.FirstOrDefault(f => f.IlcelerID == user.IlcelerID);

                        te.Ilceler.Remove(ilceler);
                        te.SaveChanges();
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

        public List<Ilceler> Ilce_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Ilceler> ilcelist = (from k in te.Ilceler
                                          select new Ilceler
                                          {
                                              IlcelerID = k.IlcelerID,
                                              IlceAdi = k.IlceAdi

                                          }).OrderBy(f => f.IlcelerID).ToList();
                return ilcelist;
            }
        }

        public List<Ilceler> PIlce_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Ilceler> ilcelist = (from k in te.Ilceler where k.IlcelerID == y select k).ToList();

                return ilcelist;
            }
        }
    }
}