using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class gorevliler
    {
        public bool Gorevliler_Insert(gorevlilertb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        gorevlilertb grv = new gorevlilertb();

                        grv.gorevliid = user.gorevliid;
                        grv.gorevliad = user.gorevliad;
                        grv.gorevlisoyad = user.gorevlisoyad;
                        grv.gorevlitel = user.gorevlitel;

                        se.gorevlilertb.Add(grv);
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

        public bool Gorevliler_Update(gorevlilertb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        gorevlilertb grv = se.gorevlilertb.FirstOrDefault(f => f.gorevliid == user.gorevliid);


                        grv.gorevliid = user.gorevliid;
                        grv.gorevliad = user.gorevliad;
                        grv.gorevlisoyad = user.gorevlisoyad;
                        grv.gorevlitel = user.gorevlitel;

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
        public bool Gorevliler_Delete(gorevlilertb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        gorevlilertb grv = se.gorevlilertb.FirstOrDefault(f => f.gorevliid == user.gorevliid);

                        se.gorevlilertb.Remove(grv);
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

        public List<gorevlilertb> Gorevliler_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<gorevlilertb> gorevlilerlist = (from k in se.gorevlilertb
                                         select new gorevlilertb
                                         {
                                             gorevliid = k.gorevliid,
                                             gorevliad = k.gorevliad,
                                             gorevlisoyad=k.gorevlisoyad,
                                             gorevlitel=k.gorevlitel
                                            
                                         }).OrderBy(f => f.gorevliid).ToList();
                return gorevlilerlist;
            }
        }
        public List<gorevlilertb> PGorevliler_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<gorevlilertb> gorevlilerlist = (from k in se.gorevlilertb where k.gorevliid == y select k).ToList();

                return gorevlilerlist;
            }
        }

    }

}
