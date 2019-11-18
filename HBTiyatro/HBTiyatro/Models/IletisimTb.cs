using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class IletisimTb
    {
        public bool Iletisim_Insert(Iletisim user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Iletisim iletisim = new Iletisim();

                        iletisim.IletisimID = user.IletisimID;
                        iletisim.Adres = user.Adres;
                        iletisim.Telefon = user.Telefon;
                        iletisim.Mail = user.Mail;

                        te.Iletisim.Add(iletisim);
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

        public bool Iletisim_Update(Iletisim user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Iletisim ileti = te.Iletisim.FirstOrDefault(f => f.IletisimID == user.IletisimID);

                        ileti.IletisimID = user.IletisimID;
                        ileti.Adres = user.Adres;
                        ileti.Telefon = user.Telefon;
                        ileti.Mail = user.Mail;

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

        public bool Iletisim_Delete(Iletisim user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Iletisim ileti = te.Iletisim.FirstOrDefault(f => f.IletisimID == user.IletisimID);

                        te.Iletisim.Remove(ileti);
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

        public List<Iletisim> Iletisim_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Iletisim> iletisimlist = (from k in te.Iletisim
                                               select new Iletisim
                                               {
                                                   IletisimID = k.IletisimID,
                                                   Adres = k.Adres,
                                                   Telefon = k.Telefon,
                                                   Mail = k.Mail

                                               }).OrderBy(f => f.IletisimID).ToList();
                return iletisimlist;
            }
        }

        public List<Iletisim> PIletisim_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Iletisim> iletisimlist = (from k in te.Iletisim where k.IletisimID == y select k).ToList();

                return iletisimlist;
            }
        }
    }
}