using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class YorumlarTb
    {
        public bool Yorum_Insert(Yorumlar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Yorumlar yorum = new Yorumlar();

                        yorum.YorumId = user.YorumId;
                        yorum.Konu = user.Konu;
                        yorum.Aciklama = user.Aciklama;
                        yorum.KullaniciID = user.KullaniciID;
                        yorum.OyunID = user.OyunID;
                        yorum.ResimID = user.ResimID;

                        te.Yorumlar.Add(yorum);
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

        public bool Yorum_Update(Yorumlar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Yorumlar yorumlar = te.Yorumlar.FirstOrDefault(f => f.YorumId == user.YorumId);

                        yorumlar.YorumId = user.YorumId;
                        yorumlar.Konu = user.Konu;
                        yorumlar.Aciklama = user.Aciklama;
                        yorumlar.KullaniciID = user.KullaniciID;
                        yorumlar.OyunID = user.OyunID;
                        yorumlar.ResimID = user.ResimID;

                        te.SaveChanges();
                        scope.Complete();
                        return true;

                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
            return true;
        }

        public bool Yorum_Delete(Yorumlar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Yorumlar yorumlar = te.Yorumlar.FirstOrDefault(f => f.YorumId == user.YorumId);

                        te.Yorumlar.Remove(yorumlar);
                        te.SaveChanges();
                        scope.Complete();
                        return true;
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                }
            }
            return true;
        }

        public List<Yorumlar> Yorum_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Yorumlar> yorumlist = (from k in te.Yorumlar
                                            select new Yorumlar
                                            {
                                                YorumId = k.YorumId,
                                                Konu = k.Konu,
                                                Aciklama = k.Aciklama,
                                                KullaniciID = k.KullaniciID,
                                                OyunID = k.OyunID,
                                                ResimID = k.ResimID
                                            }).OrderBy(f => f.YorumId).ToList();
                return yorumlist;
            }
        }
        public List<Yorumlar> PYorum_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Yorumlar> yorumlist = (from k in te.Yorumlar where k.YorumId == y select k).ToList();

                return yorumlist;
            }
        }
    }
}