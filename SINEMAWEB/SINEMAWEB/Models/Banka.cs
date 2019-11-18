using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace SINEMAWEB.Models
{
    public class Banka
    {
        public bool Banka_Insert(bankatb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bankatb bnk = new bankatb();

                        bnk.bankaid = user.bankaid;
                        bnk.hesapno = user.hesapno;
                        bnk.guvenlikkodu = user.guvenlikkodu;
                        bnk.ibanno = user.ibanno;
                        bnk.bankaadi = user.bankaadi;

                        se.bankatb.Add(bnk);
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
        public bool Banka_Update(bankatb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bankatb bnk = se.bankatb.FirstOrDefault(f => f.bankaid == user.bankaid);

                        bnk.bankaid = user.bankaid;
                        bnk.hesapno = user.hesapno;
                        bnk.guvenlikkodu = user.guvenlikkodu;
                        bnk.ibanno = user.ibanno;
                        bnk.bankaadi = user.bankaadi;

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
        public bool Banka_Delete(bankatb user)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        bankatb bnk = se.bankatb.FirstOrDefault(f => f.bankaid == user.bankaid);

                        se.bankatb.Remove(bnk);
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

        public List<bankatb> Banka_List()
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<bankatb> bankalist = (from k in se.bankatb
                                           select new bankatb
                                           {
                                               bankaid = k.bankaid,
                                               hesapno = k.hesapno,
                                               sonkullanmatarih = k.sonkullanmatarih,
                                               guvenlikkodu = k.guvenlikkodu,
                                               ibanno = k.ibanno,
                                               bankaadi = k.bankaadi

                                           }).OrderBy(f => f.bankaid).ToList();
                return bankalist;
            }
        }

        public List<bankatb> PBanka_Getir(int y)
        {
            using (SINEMADBEntities se = new SINEMADBEntities())
            {
                List<bankatb> bankalist = (from k in se.bankatb where k.bankaid == y select k).ToList();

                return bankalist;
            }
        }
    }

}
