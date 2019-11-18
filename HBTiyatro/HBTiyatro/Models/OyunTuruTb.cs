using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;


namespace HBTiyatro.Models
{
    public class OyunTuruTb
    {
        public bool Oyunturu_Insert(OyunTuru user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        OyunTuru tur = new OyunTuru();

                        tur.OyunTuruID = user.OyunTuruID;
                        tur.OyunTuru1 = user.OyunTuru1;

                        te.OyunTuru.Add(tur);
                        te.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
            return true;
        }

        public bool Oyunturu_Update(OyunTuru user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        OyunTuru oyuntur = te.OyunTuru.FirstOrDefault(f => f.OyunTuruID == user.OyunTuruID);

                        oyuntur.OyunTuruID = user.OyunTuruID;
                        oyuntur.OyunTuru1 = user.OyunTuru1;

                        te.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
            return true;
        }

        public bool Oyunturu_Delete(OyunTuru user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        OyunTuru oyuntur = te.OyunTuru.FirstOrDefault(f => f.OyunTuruID == user.OyunTuruID);

                        te.OyunTuru.Remove(oyuntur);
                        te.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
            return true;
        }

        public List<OyunTuru> Oyunturu_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<OyunTuru> turlist = (from k in te.OyunTuru
                                          select new OyunTuru
                                          {
                                              OyunTuruID = k.OyunTuruID,
                                              OyunTuru1 = k.OyunTuru1

                                          }).OrderBy(f => f.OyunTuruID).ToList();
                return turlist;
            }
        }

        public List<OyunTuru> POyunturu_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<OyunTuru> turlist = (from k in te.OyunTuru where k.OyunTuruID == y select k).ToList();

                return turlist;
            }
        }
    }
}