using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project.Filters;

namespace Project.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeCulture(string language)
        {
            var returnUrl = Request.UrlReferrer.OriginalString;

            var cultures = new List<string>() { "ru", "en", "be" };
            if (!cultures.Contains(language))
            {
                language = "ru";
            }

            var cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = language;
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = language;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Error()
        {
            return View("Error");
        }
    }
}