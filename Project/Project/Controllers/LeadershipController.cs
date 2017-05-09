using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Project.Filters;
using Project.Methods;
using Project.Models;

namespace Project.Controllers
{
    [Culture]
    public class LeadershipController : Controller
    {
        //
        // GET: /Leadership/
        public ActionResult Show()
        {
            var leades = LeadershipMethods.GetAll();
            return View(leades);
        }

        public ActionResult AddLeader()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AddLeader(LeaderView model, HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid) return View(model);
            if (photo == null)
            {
                ModelState.AddModelError("Error", Resources.I18n.NoFile);
                return View(model);
            }
            LeadershipMethods.SaveLeader(model, LeadershipMethods.SaveImage(photo));
            return RedirectToAction("Show");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RemoveLeader(int leaderId)
        {
            var returnUrl = Request.UrlReferrer.OriginalString;
            LeadershipMethods.RemoveLeader(leaderId);
            return Redirect(returnUrl);
        }
	}
}