using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Methods
{
    public class StaticsMethod
    {
        public static Statics FindStatics(string header)
        {
            var statics = new List<Statics>();
            using (var db = new Db())
            {
                statics = db.Statics.Where(x => x.Header == header).ToList();
            }
            if (statics.Count == 1)
                return statics[0];
            return null;
        }
        public static void SaveStatics(Statics statics)
        {
            var model = new Statics();
            using (var db = new Db())
            {
                model = db.Statics.Find(statics.Id);
                model.Body = statics.Body;
                db.SaveChanges();
            }

        }

    }
}