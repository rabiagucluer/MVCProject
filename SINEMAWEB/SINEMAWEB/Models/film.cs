using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class film
    {
        public bool Film_Insert(filmtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        filmtb flm = new filmtb();

                        flm.filmid = user.filmid;
                        flm.filmadi = user.filmadi;
                        flm.filmsüre = user.filmsüre;
                        flm.filmoyunculari = user.filmoyunculari;
                        flm.filmaciklama = user.filmaciklama;
                        flm.filmfoto = user.filmfoto;
                        flm.seansid = user.seansid;
                        flm.salon1 = user.salon1;
                        flm.salon2 = user.salon2;


                        se.filmtb.Add(flm);
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

        public bool Fılm_Update(filmtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        filmtb flm = se.filmtb.FirstOrDefault(f => f.filmid == user.filmid);


                        flm.filmid = user.filmid;
                        flm.filmadi = user.filmadi;
                        flm.filmsüre = user.filmsüre;
                        flm.filmoyunculari = user.filmoyunculari;
                        flm.filmaciklama = user.filmaciklama;
                        flm.filmfoto = user.filmfoto;
                        flm.seansid = user.seansid;
                        flm.salon1 = user.salon1;
                        flm.salon2 = user.salon2;
                        

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
        public bool Fılm_Delete(filmtb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        filmtb flm = se.filmtb.FirstOrDefault(f => f.filmid == user.filmid);

                        se.filmtb.Remove(flm);
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

        public List<filmtb> Fılm_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<filmtb> fılmlist = (from k in se.filmtb
                                         select new filmtb
                                         {

                                             filmid = k.filmid,
                filmadi = k.filmadi,
                filmsüre = k.filmsüre,
                filmoyunculari = k.filmoyunculari,
                filmaciklama = k.filmaciklama,
                filmfoto = k.filmfoto,
                seansid = k.seansid,
                salon1 = k.salon1,
                salon2 = k.salon2

            }).OrderBy(f => f.filmid).ToList();
                return fılmlist;
            }
        }
        public List<filmtb> PFilm_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<filmtb> filmlist = (from k in se.filmtb where k.filmid == y select k).ToList();

                return filmlist;
            }
        }

    }

}
