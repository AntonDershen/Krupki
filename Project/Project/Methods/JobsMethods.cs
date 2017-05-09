using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;


namespace Project.Methods
{
    public class JobsMethods
    {
        public static void SaveJobs(JobsView jobsView)
        {
            var jobs = new Jobs()
            {
                Body = jobsView.Body,
                Header = jobsView.Header,
                Date = DateTime.Now
            };
            using (var db = new Db())
            {
                db.Jobs.Add(jobs);
                db.SaveChanges();
            }
        }
        public static void RemoveJobs(int jobsId)
        {
            var jobs = new Jobs();
            using (var db = new Db())
            {
                jobs = db.Jobs.Find(jobsId);
                db.Jobs.Remove(jobs);
                db.SaveChanges();
            }
        }
    }
}