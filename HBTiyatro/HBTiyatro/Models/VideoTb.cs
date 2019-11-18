using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Transactions;

namespace HBTiyatro.Models
{
    public class VideoTb
    {
        public bool Video_Insert(Video user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Video kayıt = new Video();

                        kayıt.VideoId = user.VideoId;
                        kayıt.VideoAdi = user.VideoAdi;
                        kayıt.VideoLink = user.VideoLink;

                        te.Video.Add(kayıt);
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

        public bool Video_Update(Video user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Video video = te.Video.FirstOrDefault(f => f.VideoId == user.VideoId);

                        video.VideoId = user.VideoId;
                        video.VideoAdi = user.VideoAdi;
                        video.VideoLink = user.VideoLink;

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

        public bool Video_Delete(Video user)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Video video = te.Video.FirstOrDefault(f => f.VideoId == user.VideoId);

                        te.Video.Remove(video);
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

        public List<Video> Video_List()
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Video> videolist = (from k in te.Video
                                         select new Video
                                         {
                                             VideoId = k.VideoId,
                                             VideoAdi = k.VideoAdi,
                                             VideoLink = k.VideoLink

                                         }).OrderBy(f => f.VideoId).ToList();
                return videolist;
            }
        }

        public List<Video> PVideo_Getir(int y)
        {
            using (TIYATROEntities te = new TIYATROEntities())
            {
                List<Video> videolist = (from k in te.Video where k.VideoId == y select k).ToList();

                return videolist;
            }
        }
    }
}