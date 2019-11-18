using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class SahnelerTb
    {
        public bool Sahne_Insert(Sahneler user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Sahneler sahne = new Sahneler();

                        sahne.SahneId = user.SahneId;
                        sahne.SahneAdi = user.SahneAdi;
                        sahne.OyunlarNo = user.OyunlarNo;
                        sahne.SahneAdresi = user.SahneAdresi;
                        sahne.SahneTelefon = user.SahneTelefon;
                        sahne.TiyatroNo = user.TiyatroNo;

                        te.Sahneler.Add(sahne);
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

        public bool Sahne_Update(Sahneler user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Sahneler sahneler = te.Sahneler.FirstOrDefault(f => f.SahneId == user.SahneId);

                        sahneler.SahneId = user.SahneId;
                        sahneler.SahneAdi = user.SahneAdi;
                        sahneler.OyunlarNo = user.OyunlarNo;
                        sahneler.SahneAdresi = user.SahneAdresi;
                        sahneler.SahneTelefon = user.SahneTelefon;
                        sahneler.TiyatroNo = user.TiyatroNo;

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

        public bool Sahne_Delete(Sahneler user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Sahneler sahneler = te.Sahneler.FirstOrDefault(f => f.SahneId == user.SahneId);

                        te.Sahneler.Remove(sahneler);
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

        public List<Sahneler> Sahne_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Sahneler> sahnelist = (from k in te.Sahneler
                                            select new Sahneler
                                            {
                                                SahneId = k.SahneId,
                                                SahneAdi = k.SahneAdi,
                                                OyunlarNo = k.OyunlarNo,
                                                SahneAdresi = k.SahneAdresi,
                                                SahneTelefon = k.SahneTelefon,
                                                TiyatroNo = k.TiyatroNo

                                            }).OrderBy(f => f.SahneId).ToList();
                return sahnelist;
            }
        }

        public List<Sahneler> PSahne_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Sahneler> sahnelist = (from k in te.Sahneler where k.SahneId == y select k).ToList();

                return sahnelist;
            }
        }
    }
}