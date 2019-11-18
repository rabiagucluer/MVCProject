using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class RolTb
    {
        public bool Rol_Insert(Rol user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Rol rol = new Rol();

                        rol.RolID = rol.RolID;
                        rol.RolTuru = rol.RolTuru;

                        te.Rol.Add(rol);
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

        public bool Rol_Update(Rol user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Rol rtur = te.Rol.FirstOrDefault(f => f.RolID == user.RolID);

                        rtur.RolID = user.RolID;
                        rtur.RolTuru = user.RolTuru;

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

        public bool Rol_Delete(Rol user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Rol rtur = te.Rol.FirstOrDefault(f => f.RolID == user.RolID);

                        te.Rol.Remove(rtur);
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

        public List<Rol> Rol_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Rol> rollist = (from k in te.Rol
                                     select new Rol
                                     {
                                         RolID = k.RolID,
                                         RolTuru = k.RolTuru

                                     }).OrderBy(f => f.RolID).ToList();
                return rollist;
            }
        }

        public List<Rol> PRol_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Rol> rollist = (from k in te.Rol where k.RolID == y select k).ToList();

                return rollist;
            }
        }
    }
}