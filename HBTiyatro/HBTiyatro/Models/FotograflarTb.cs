using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class FotograflarTb
    {
        public bool Foto_Insert(Fotograflar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Fotograflar foto = new Fotograflar();

                        foto.FotoId = user.FotoId;
                        foto.FotoAdi = user.FotoAdi;
                        foto.FotoLink = user.FotoLink;
                        foto.OyunNo = user.OyunNo;

                        te.Fotograflar.Add(foto);
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

        public bool Foto_Update(Fotograflar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Fotograflar fotolar = te.Fotograflar.FirstOrDefault(f => f.FotoId == user.FotoId);

                        fotolar.FotoId = user.FotoId;
                        fotolar.FotoAdi = user.FotoAdi;
                        fotolar.FotoLink = user.FotoLink;
                        fotolar.OyunNo = user.OyunNo;

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

        public bool Foto_Delete(Fotograflar user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Fotograflar fotolar = te.Fotograflar.FirstOrDefault(f => f.FotoId == user.FotoId);

                        te.Fotograflar.Remove(fotolar);
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

        public List<Fotograflar> Foto_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Fotograflar> fotolist = (from k in te.Fotograflar
                                              select new Fotograflar
                                              {
                                                  FotoId = k.FotoId,
                                                  FotoAdi = k.FotoAdi,
                                                  FotoLink = k.FotoLink,
                                                  OyunNo = k.OyunNo

                                              }).OrderBy(f => f.FotoId).ToList();
                return fotolist;
            }
        }

        public List<Fotograflar> PFoto_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Fotograflar> fotolist = (from k in te.Fotograflar where k.FotoId == y select k).ToList();

                return fotolist;
            }
        }
    }
}