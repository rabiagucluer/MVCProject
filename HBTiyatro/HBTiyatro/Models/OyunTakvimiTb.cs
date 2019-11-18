using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class OyunTakvimiTb
    {
        public bool Takvim_Insert(OyunTakvimi user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        OyunTakvimi tkvm = new OyunTakvimi();

                        tkvm.TakvimId = user.TakvimId;
                        tkvm.Yil = user.Yil;
                        tkvm.Aylar = user.Aylar;
                        tkvm.OyunNo = user.OyunNo;
                        tkvm.Gunler = user.Gunler;
                        tkvm.Saat = user.Saat;
                        tkvm.SahneNo = user.SahneNo;

                        te.OyunTakvimi.Add(tkvm);
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

        public bool Takvim_Update(OyunTakvimi user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        OyunTakvimi takvim = te.OyunTakvimi.FirstOrDefault(f => f.TakvimId == user.TakvimId);

                        takvim.TakvimId = user.TakvimId;
                        takvim.Yil = user.Yil;
                        takvim.Aylar = user.Aylar;
                        takvim.OyunNo = user.OyunNo;
                        takvim.Gunler = user.Gunler;
                        takvim.Saat = user.Saat;
                        takvim.SahneNo = user.SahneNo;

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

        public bool Takvim_Delete(OyunTakvimi user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        OyunTakvimi takvim = te.OyunTakvimi.FirstOrDefault(f => f.TakvimId == user.TakvimId);

                        te.OyunTakvimi.Remove(takvim);
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

        public List<OyunTakvimi> Takvim_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<OyunTakvimi> takvimlist = (from k in te.OyunTakvimi
                                                select new OyunTakvimi
                                                {
                                                    TakvimId = k.TakvimId,
                                                    Yil = k.Yil,
                                                    Aylar = k.Aylar,
                                                    OyunNo = k.OyunNo,
                                                    Gunler = k.Gunler,
                                                    Saat = k.Saat,
                                                    SahneNo = k.SahneNo

                                                }).OrderBy(f => f.TakvimId).ToList();
                return takvimlist;
            }
        }

        public List<OyunTakvimi> PTakvim_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<OyunTakvimi> takvimlist = (from k in te.OyunTakvimi where k.TakvimId == y select k).ToList();

                return takvimlist;
            }
        }
    }
}