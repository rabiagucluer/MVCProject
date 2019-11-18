using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class KullaniciTb
    {
        public bool Kullanici_Insert(Kullanici user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Kullanici kullanici = new Kullanici();

                        kullanici.KullaniciID = user.KullaniciID;
                        kullanici.Sifre = user.Sifre;
                        kullanici.SifreTekrari = user.SifreTekrari;
                        kullanici.KullaniciAdi = user.KullaniciAdi;
                        kullanici.KullaniciSoyadi = user.KullaniciSoyadi;
                        kullanici.Telefon = user.Telefon;
                        kullanici.EPosta = user.EPosta;
                        kullanici.MesajID = user.MesajID;
                        kullanici.UyeKodu = user.UyeKodu;
                        kullanici.Onay = user.Onay;
                        kullanici.RolID = user.RolID;
                        kullanici.TC = user.TC;

                        te.Kullanici.Add(kullanici);
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

        public bool Kullanici_Update(Kullanici user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Kullanici klnc = te.Kullanici.FirstOrDefault(f => f.KullaniciID == user.KullaniciID);

                        klnc.KullaniciID = user.KullaniciID;
                        klnc.Sifre = user.Sifre;
                        klnc.SifreTekrari = user.SifreTekrari;
                        klnc.KullaniciAdi = user.KullaniciAdi;
                        klnc.KullaniciSoyadi = user.KullaniciSoyadi;
                        klnc.Telefon = user.Telefon;
                        klnc.EPosta = user.EPosta;
                        klnc.MesajID = user.MesajID;
                        klnc.UyeKodu = user.UyeKodu;
                        klnc.Onay = user.Onay;
                        klnc.RolID = user.RolID;
                        klnc.TC = user.TC;
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
        public bool Kullanici_Delete(Kullanici user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Kullanici klnc = te.Kullanici.FirstOrDefault(f => f.KullaniciID == user.KullaniciID);

                        te.Kullanici.Remove(klnc);
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

        public List<Kullanici> Kullanici_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Kullanici> kullanicilist = (from k in te.Kullanici
                                                 select new Kullanici
                                                 {
                                                     KullaniciID = k.KullaniciID,
                                                     Sifre = k.Sifre,
                                                     SifreTekrari = k.SifreTekrari,
                                                     KullaniciAdi = k.KullaniciAdi,
                                                     KullaniciSoyadi = k.KullaniciSoyadi,
                                                     Telefon = k.Telefon,
                                                     EPosta = k.EPosta,
                                                     MesajID = k.MesajID,
                                                     UyeKodu = k.UyeKodu,
                                                     Onay = k.Onay,
                                                     RolID = k.RolID,
                                                     TC = k.TC,
                                                 }).OrderBy(f => f.KullaniciID).ToList();
                return kullanicilist;
            }
        }

        public List<Kullanici> PKullanici_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Kullanici> kullanicilist = (from k in te.Kullanici where k.KullaniciID == y select k).ToList();

                return kullanicilist;
            }
        }
    }
}