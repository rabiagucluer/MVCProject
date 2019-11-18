using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class AdresTb
    {
        public bool Adres_Insert(Adres user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Adres adres = new Adres();

                        adres.AdresID = user.AdresID;
                        adres.Adres1 = user.Adres1;
                        adres.Telefon = user.Telefon;
                        adres.IlceNo = user.IlceNo;

                        te.Adres.Add(adres);
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

        public bool Adres_Update(Adres user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Adres adresler = te.Adres.FirstOrDefault(f => f.AdresID == user.AdresID);

                        adresler.AdresID = user.AdresID;
                        adresler.Adres1 = user.Adres1;
                        adresler.Telefon = user.Telefon;
                        adresler.IlceNo = user.IlceNo;

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

        public bool Adres_Delete(Adres user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Adres adresler = te.Adres.FirstOrDefault(f => f.AdresID == user.AdresID);

                        te.Adres.Remove(adresler);
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

        public List<Adres> Adres_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Adres> adreslist = (from k in te.Adres
                                         select new Adres
                                         {
                                             AdresID = k.AdresID,
                                             Adres1 = k.Adres1,
                                             Telefon = k.Telefon,
                                             IlceNo = k.IlceNo,
                                         }).OrderBy(f => f.AdresID).ToList();
                return adreslist;
            }
        }
        public List<Adres> PAdres_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Adres> adreslist = (from k in te.Adres where k.AdresID == y select k).ToList();

                return adreslist;
            }
        }
    }
}