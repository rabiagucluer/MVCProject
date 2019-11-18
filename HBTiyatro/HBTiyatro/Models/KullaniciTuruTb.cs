using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class KullaniciTuruTb
    {
        public bool KullaniciTuru_Insert(KullaniciTuru user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        KullaniciTuru ktur = new KullaniciTuru();

                        ktur.TurId = user.TurId;
                        ktur.IndirimOrani = user.IndirimOrani;
                        ktur.TurAdi = user.TurAdi;

                        te.KullaniciTuru.Add(ktur);
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

        public bool KullaniciTuru_Update(KullaniciTuru user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        KullaniciTuru kTuru = te.KullaniciTuru.FirstOrDefault(f => f.TurId == user.TurId);

                        kTuru.TurId = user.TurId;
                        kTuru.IndirimOrani = user.IndirimOrani;
                        kTuru.TurAdi = user.TurAdi;

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

        public bool KullaniciTuru_Delete(KullaniciTuru user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        KullaniciTuru kTuru = te.KullaniciTuru.FirstOrDefault(f => f.TurId == user.TurId);

                        te.KullaniciTuru.Remove(kTuru);
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

        public List<KullaniciTuru> KullaniciTuru_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<KullaniciTuru> kturlist = (from k in te.KullaniciTuru
                                                select new KullaniciTuru
                                                {
                                                    TurId = k.TurId,
                                                    IndirimOrani = k.IndirimOrani,
                                                    TurAdi = k.TurAdi

                                                }).OrderBy(f => f.TurId).ToList();
                return kturlist;
            }
        }

        public List<KullaniciTuru> PKullaniciTuru_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<KullaniciTuru> kturlist = (from k in te.KullaniciTuru where k.TurId == y select k).ToList();

                return kturlist;
            }
        }
    }
}