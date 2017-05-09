using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Filters;
using Project.Methods;
using Project.Models;

namespace Project.Controllers
{
    [Culture]
    public class JobsController : Controller
    {
         [Authorize(Roles = "Admin")]
        public ActionResult AddJobs()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddJobs(JobsView jobsView)
        {
          
            if (!ModelState.IsValid)
            {
                return View(jobsView);
            }
            JobsMethods.SaveJobs(jobsView);
            return RedirectToAction("ShowAllJobs", "Jobs");
        }
        public ActionResult ShowAllJobs()
        {
            var jobs = new List<Jobs>();
            using (var db = new Db())
            {
                jobs = db.Jobs.ToList();
            }
            return View(jobs);
        }
        public ActionResult ShowJobs(int jobsId)
        {
            var jobs = new Jobs();
            using (var db = new Db())
            {
                jobs = db.Jobs.Find(jobsId);
            }
            return View(jobs);
        }
        public ActionResult RemoveJobs(int jobsId)
        {
            JobsMethods.RemoveJobs(jobsId);
            return RedirectToAction("ShowAllJobs", "Jobs");
        }
    }
}