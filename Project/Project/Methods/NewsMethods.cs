using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Methods
{
    public class NewsMethods
    {
        public static List<News> GetAllNews()
        {
            List<News> news;
            using (var db = new Db())
            {
                news = db.News.ToList();
            }
            news.Reverse();
            return news;
        }

        public static News FindNews(int? newsId)
        {
            var model = new News();
            try
            {
                using (var db = new Db())
                {
                    model = db.News.Find(newsId);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return model;
        }

        public static List<News> GetLastNews()
        {
            var news = GetAllNews();
            return news.GetRange(0, news.Count < 6 ? news.Count : 6);
        }

        public static string SaveImage(HttpPostedFileBase image)
        {
            if (image == null) return "Images\\default.png";
            var path = AppDomain.CurrentDomain.BaseDirectory + "Images\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() +
                            image.FileName.Split('\\').Last();
            image.SaveAs(path + fileName);
            return "Images\\" + fileName;
        }

        public static void SaveNews(NewsView newsView, string imageUrl)
        {
            var news = new News()
            {
                Header = newsView.Header,
                Body = newsView.Body,
                ImageUrl = imageUrl,
                Date = DateTime.Now
            };
            using (var db = new Db())
            {
                db.News.Add(news);
                db.SaveChanges();
            }
        }

        public static void RemoveNews(int newsId)
        {
            using (var db = new Db())
            {
                var news = db.News.Find(newsId);
                try
                {
                    if (news.ImageUrl != ("Images\\default.png"))
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\" + news.ImageUrl);
                }
                catch (Exception e)
                {
                    //Do nothing...
                }
                finally
                {
                    db.Entry(news).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }
    }
}