using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class BlokTb
    {
        public bool Blok_Insert(Blok user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Blok blk = new Blok();

                        blk.BlokID = user.BlokID;
                        blk.BlokTuru = user.BlokTuru;

                        te.Blok.Add(blk);
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

        public bool Blok_Update(Blok user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Blok blok = te.Blok.FirstOrDefault(f => f.BlokID == user.BlokID);

                        blok.BlokID = user.BlokID;
                        blok.BlokTuru = user.BlokTuru;

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

        public bool Blok_Delete(Blok user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Blok blok = te.Blok.FirstOrDefault(f => f.BlokID == user.BlokID);

                        te.Blok.Remove(blok);
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

        public List<Blok> Blok_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Blok> bloklist = (from k in te.Blok
                                       select new Blok
                                       {
                                           BlokID = k.BlokID,
                                           BlokTuru = k.BlokTuru

                                       }).OrderBy(f => f.BlokID).ToList();
                return bloklist;
            }
        }

        public List<Blok> PBlok_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Blok> bloklist = (from k in te.Blok where k.BlokID == y select k).ToList();

                return bloklist;
            }
        }
    }
}