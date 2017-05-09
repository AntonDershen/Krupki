using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Methods
{
    public class LeadershipMethods
    {
        public static string ParsePosition(Positions position)
        {
            switch (position)
            {
                case Positions.Director:
                    return Resources.I18n.Director;
                case Positions.DeputyDirector:
                    return Resources.I18n.DeputyDirector;
                default:
                    return Resources.I18n.Other;
            }
        }
        public static List<Leader> GetAll()
        {
            List<Leader> leaders;
            using (var db = new Db())
            {
                leaders = db.Leaders.ToList();
            }
            leaders.Sort((a, b) =>
            {
                if (a.Position > b.Position) return 1;
                if (a.Position < b.Position) return -1;
                return 0;
            });
            return leaders;
        }
        public static string SaveImage(HttpPostedFileBase image)
        {
            if (image == null) return null;
            var path = AppDomain.CurrentDomain.BaseDirectory + "Leadership\\Photos\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() +
                            image.FileName.Split('\\').Last();
            image.SaveAs(path + fileName);
            return "Photos\\" + fileName;
        }

        public static void SaveLeader(LeaderView leaderView, string photoUrl)
        {
            var leader = new Leader()
            {
                Description = leaderView.Description,
                Position = (Positions)Enum.Parse(typeof(Positions), leaderView.Position),
                PhotoUrl = photoUrl,
                FirstName = leaderView.FirstName,
                LastName = leaderView.LastName,
                MiddleName = leaderView.MiddleName,
            };
            using (var db = new Db())
            {
                db.Leaders.Add(leader);
                db.SaveChanges();
            }
        }

        public static void RemoveLeader(int leaderId)
        {
            using (var db = new Db())
            {
                var leader = db.Leaders.Find(leaderId);
                if (leader == null) return;
                try
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Leadership\\" + leader.PhotoUrl);
                }
                catch (Exception e)
                {
                    //Do nothing...
                }
                finally
                {
                    db.Entry(leader).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }
    }
}