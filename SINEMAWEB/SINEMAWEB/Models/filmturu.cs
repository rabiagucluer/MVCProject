using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class filmtru
    {
        public bool FilmTuru_Insert(filmturutb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        filmturutb ft = new filmturutb();

                        ft.turid = user.turid;
                        ft.filmturu = user.filmturu;

                        se.filmturutb.Add(ft);
                        se.SaveChanges();
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

        public bool FilmTuru_Update(filmturutb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        filmturutb ft = se.filmturutb.FirstOrDefault(f => f.turid == user.turid);


                        ft.turid = user.turid;
                        ft.filmturu = user.filmturu;

                        se.SaveChanges();
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
        public bool FilmTuru_Delete(filmturutb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        filmturutb ft = se.filmturutb.FirstOrDefault(f => f.turid == user.turid);

                        se.filmturutb.Remove(ft);
                        se.SaveChanges();
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

        public List<filmturutb> FilmTuru_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<filmturutb> filmturulist = (from k in se.filmturutb
                                         select new filmturutb
                                         {
                                             turid = k.turid,
                                             filmturu = k.filmturu
                                         }).OrderBy(f => f.turid).ToList();
                return filmturulist;
            }
        }
        public List<filmturutb> PFilmTuru_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<filmturutb> filmturulist = (from k in se.filmturutb where k.turid == y select k).ToList();

                return filmturulist;
            }
        }

    }

}
