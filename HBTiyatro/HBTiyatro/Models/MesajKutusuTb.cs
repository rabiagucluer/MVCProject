using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class MesajKutusuTb
    {
        public bool Mesaj_Insert(MesajKutusu user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        MesajKutusu mesaj = new MesajKutusu();

                        mesaj.MesajID = user.MesajID;
                        mesaj.Baslik = user.Baslik;
                        mesaj.Konu = user.Konu;
                        mesaj.Mesaj = user.Mesaj;
                        mesaj.KayitTarihi = user.KayitTarihi;
                        mesaj.KullaniciID = user.KullaniciID;

                        te.MesajKutusu.Add(mesaj);
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

        public bool Mesaj_Update(MesajKutusu user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        MesajKutusu mkutu = te.MesajKutusu.FirstOrDefault(f => f.MesajID == user.MesajID);

                        mkutu.MesajID = user.MesajID;
                        mkutu.Baslik = user.Baslik;
                        mkutu.Konu = user.Konu;
                        mkutu.Mesaj = user.Mesaj;
                        mkutu.KayitTarihi = user.KayitTarihi;
                        mkutu.KullaniciID = user.KullaniciID;

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

        public bool Mesaj_Delete(MesajKutusu user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        MesajKutusu mkutu = te.MesajKutusu.FirstOrDefault(f => f.MesajID == user.MesajID);

                        te.MesajKutusu.Remove(mkutu);
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

        public List<MesajKutusu> Mesaj_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<MesajKutusu> mesajlist = (from k in te.MesajKutusu
                                               select new MesajKutusu
                                               {
                                                   MesajID = k.MesajID,
                                                   Baslik = k.Baslik,
                                                   Konu = k.Konu,
                                                   Mesaj = k.Mesaj,
                                                   KayitTarihi = k.KayitTarihi,
                                                   KullaniciID = k.KullaniciID

                                               }).OrderBy(f => f.MesajID).ToList();
                return mesajlist;
            }
        }

        public List<MesajKutusu> PMesaj_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<MesajKutusu> mesajlist = (from k in te.MesajKutusu where k.MesajID == y select k).ToList();

                return mesajlist;
            }
        }
    }
}