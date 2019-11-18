using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class OyuncularTb
    {
        public bool Oyuncular_Insert(Oyuncular user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Oyuncular oync = new Oyuncular();
                        oync.OyuncuId = user.OyuncuId;
                        oync.OyuncuAdi = user.OyuncuAdi;
                        oync.OyuncuResimLinki = user.OyuncuResimLinki;
                        oync.OyunID = user.OyunID;
                        oync.OyuncuSoyadi = user.OyuncuSoyadi;
                        oync.Yazar = user.Yazar;
                        oync.Yonetmen = user.Yonetmen;
                        oync.Ceviren = user.Ceviren;
                        oync.Muzik = user.Muzik;

                        te.Oyuncular.Add(oync);
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

        public bool Oyuncular_Update(Oyuncular user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Oyuncular oyuncu = te.Oyuncular.FirstOrDefault(f => f.OyuncuId == user.OyuncuId);

                        oyuncu.OyuncuId = user.OyuncuId;
                        oyuncu.OyuncuAdi = user.OyuncuAdi;
                        oyuncu.OyuncuResimLinki = user.OyuncuResimLinki;
                        oyuncu.OyunID = user.OyunID;
                        oyuncu.OyuncuSoyadi = user.OyuncuSoyadi;
                        oyuncu.Yazar = user.Yazar;
                        oyuncu.Yonetmen = user.Yonetmen;
                        oyuncu.Ceviren = user.Ceviren;
                        oyuncu.Muzik = user.Muzik;

                        te.Oyuncular.Add(oyuncu);
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
        public bool Oyuncular_Delete(Oyuncular user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Oyuncular oyuncu = te.Oyuncular.FirstOrDefault(f => f.OyuncuId == user.OyuncuId);

                        te.Oyuncular.Remove(oyuncu);
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

        public List<Oyuncular> Oyuncular_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Oyuncular> oyunculist = (from k in te.Oyuncular
                                              select new Oyuncular
                                              {
                                                  OyuncuId = k.OyuncuId,
                                                  OyuncuAdi = k.OyuncuAdi,
                                                  OyuncuResimLinki = k.OyuncuResimLinki,
                                                  OyunID = k.OyunID,
                                                  OyuncuSoyadi = k.OyuncuSoyadi,
                                                  Yazar = k.Yazar,
                                                  Yonetmen = k.Yonetmen,
                                                  Ceviren = k.Ceviren,
                                                  Muzik = k.Muzik

                                              }).OrderBy(f => f.OyuncuId).ToList();
                return oyunculist;
            }
        }

        public List<Oyuncular> POyuncular_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Oyuncular> oyunculist = (from k in te.Oyuncular where k.OyuncuId == y select k).ToList();

                return oyunculist;
            }
        }
    }
}