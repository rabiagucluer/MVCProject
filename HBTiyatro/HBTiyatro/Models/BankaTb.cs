using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class BankaTb
    {
        public bool Banka_Insert(Banka user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Banka bnk = new Banka();
                        bnk.BankaID = user.BankaID;
                        bnk.HesapNo = user.HesapNo;
                        bnk.SonKullanmaTarihi = user.SonKullanmaTarihi;
                        bnk.guvanlikkodu = user.guvanlikkodu;
                        bnk.IBANNo = user.IBANNo;
                        bnk.BankaAdi = user.BankaAdi;

                        te.Banka.Add(bnk);
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

        public bool Banka_Update(Banka user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Banka banka = te.Banka.FirstOrDefault(f => f.BankaID == user.BankaID);

                        banka.BankaID = user.BankaID;
                        banka.HesapNo = user.HesapNo;
                        banka.SonKullanmaTarihi = user.SonKullanmaTarihi;
                        banka.guvanlikkodu = user.guvanlikkodu;
                        banka.IBANNo = user.IBANNo;
                        banka.BankaAdi = user.BankaAdi;

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

        public bool Banka_Delete(Banka user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Banka banka = te.Banka.FirstOrDefault(f => f.BankaID == user.BankaID);

                        te.Banka.Remove(banka);

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

        public List<Banka> Banka_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Banka> bankalist = (from k in te.Banka
                                         select new Banka
                                         {
                                             BankaID = k.BankaID,
                                             HesapNo = k.HesapNo,
                                             SonKullanmaTarihi = k.SonKullanmaTarihi,
                                             guvanlikkodu = k.guvanlikkodu,
                                             IBANNo = k.IBANNo,
                                             BankaAdi = k.BankaAdi,

                                         }).OrderBy(f => f.BankaID).ToList();
                return bankalist;
            }
        }

        public List<Banka> PBanka_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Banka> bankalist = (from k in te.Banka where k.BankaID == y select k).ToList();

                return bankalist;
            }
        }
    }
}