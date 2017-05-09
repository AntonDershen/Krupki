using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Methods
{
    public class ReceptionsMethods
    {
        public static void SaveReceptions(ReceptionsView reception)
        {
            
            var news = new Receptions()
            {
                Name = reception.Name,
                Adress = reception.Adress,
                EMail = reception.EMail,
                Index = reception.Index,
                Information = reception.Information,
                Date = DateTime.Now,
                Type = reception.Type,
                Body = reception.Body,
                Reception = null,
                DateReception = DateTime.Now,
                Answered = false,
                Viewed = false
            };
            using (var db = new Db())
            {
                db.Receptions.Add(news);
                db.SaveChanges();
            }
        }
        public static void RemoveReceptions(int receptionId) {
            using (var db = new Db())
            {
                var reception = db.Receptions.Find(receptionId);
                try
                {
                    db.Receptions.Remove(reception);
                }
                catch (Exception e)
                {
                    //Do nothing...
                }
                finally
                {
                    db.SaveChanges();
                }
            }
        }
    }
}