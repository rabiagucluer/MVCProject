using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class OyunlarTb
    {
        public bool Oyunlar_Insert(Oyunlar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Oyunlar oyun = new Oyunlar();

                        oyun.OyunId = user.OyunId;
                        oyun.OyunAdi = user.OyunAdi;
                        oyun.Imdb = user.Imdb;
                        oyun.OyunSuresi = user.OyunSuresi;
                        oyun.OyunFiyati = user.OyunFiyati;
                        oyun.OyunTarih = user.OyunTarih;
                        oyun.OyunDurumu = user.OyunDurumu;
                        oyun.VideoID = user.VideoID;
                        oyun.SatisID = user.SatisID;
                        oyun.OyunTuruID = user.OyunTuruID;

                        te.Oyunlar.Add(oyun);
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

        public bool Oyunlar_Update(Oyunlar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Oyunlar oyunlar = te.Oyunlar.FirstOrDefault(f => f.OyunId == user.OyunId);

                        oyunlar.OyunId = user.OyunId;
                        oyunlar.OyunAdi = user.OyunAdi;
                        oyunlar.Imdb = user.Imdb;
                        oyunlar.OyunSuresi = user.OyunSuresi;
                        oyunlar.OyunFiyati = user.OyunFiyati;
                        oyunlar.OyunTarih = user.OyunTarih;
                        oyunlar.OyunDurumu = user.OyunDurumu;
                        oyunlar.VideoID = user.VideoID;
                        oyunlar.SatisID = user.SatisID;
                        oyunlar.OyunTuruID = user.OyunTuruID;

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

        public bool Oyunlar_Delete(Oyunlar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Oyunlar oyunlar = te.Oyunlar.FirstOrDefault(f => f.OyunId == user.OyunId);

                        te.Oyunlar.Remove(oyunlar);

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

        public List<Oyunlar> Oyunlar_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Oyunlar> oyunlist = (from k in te.Oyunlar
                                          select new Oyunlar
                                          {
                                              OyunId = k.OyunId,
                                              OyunAdi = k.OyunAdi,
                                              Imdb = k.Imdb,
                                              OyunSuresi = k.OyunSuresi,
                                              OyunFiyati = k.OyunFiyati,
                                              OyunTarih = k.OyunTarih,
                                              OyunDurumu = k.OyunDurumu,
                                              VideoID = k.VideoID,
                                              SatisID = k.SatisID,
                                              OyunTuruID = k.OyunTuruID

                                          }).OrderBy(f => f.OyunId).ToList();
                return oyunlist;
            }
        }

        public List<Oyunlar> POyunlar_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Oyunlar> oyunlist = (from k in te.Oyunlar where k.OyunId == y select k).ToList();

                return oyunlist;
            }
        }
    }
}