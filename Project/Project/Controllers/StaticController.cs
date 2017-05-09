using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Filters;
using Project.Methods;
using Project.Models;
using Resources;

namespace Project.Controllers
{
     [Culture]
    public class StaticController : Controller
    {
        //
        // GET: /Static/
         public ActionResult Redactor(string header)
         {
             var model = StaticsMethod.FindStatics(header);
             ViewBag.Header = header;
             return View(model);
         }
         [HttpPost]
         public ActionResult Redactor(Statics statics)
         {
             StaticsMethod.SaveStatics(statics);
             return RedirectToAction("Index", "Home");
         }
         public ActionResult History()
         {
             var model = StaticsMethod.FindStatics("History");
             ViewBag.Header = I18n.HistoryPage;
             if (model.Body != null)
             {
                 var str = model.Body.Split('%');
                 ViewBag.Body = str;
                 ViewBag.Size = str.Count();
             }
             else { ViewBag.Body = null; ViewBag.Size = 0; }
             return View("ShowPage", model);
         }
         public ActionResult Mode()
         {
             var model = StaticsMethod.FindStatics("Mode");
             ViewBag.Header = I18n.Mode;
             if (model.Body != null)
             {
                 var str = model.Body.Split('%');
                 ViewBag.Body = str;
                 ViewBag.Size = str.Count();
             }
             else { ViewBag.Body = null; ViewBag.Size = 0; }
             return View("ShowPage", model);
         }
         public ActionResult Reception()
         {
             var model = StaticsMethod.FindStatics("Reception of Citizen");
             ViewBag.Header = I18n.Reception;
             if (model.Body != null)
             {
                 var str = model.Body.Split('%');
                 ViewBag.Body = str;
                 ViewBag.Size = str.Count();
             }
             else { ViewBag.Body = null; ViewBag.Size = 0; }
             return View("ShowPage", model);
         }
         public ActionResult Procedure()
         {
             var model = StaticsMethod.FindStatics("Administrative Procedure");
             ViewBag.Header = I18n.Procedure;
             if (model.Body != null)
             {
                 var str = model.Body.Split('%');
                 ViewBag.Body = str;
                 ViewBag.Size = str.Count();
             }
             else { ViewBag.Body = null; ViewBag.Size = 0; }
             return View("ShowPage", model);
         }
         public ActionResult OneWindow()
         {
             var model = StaticsMethod.FindStatics("One Window");
             ViewBag.Header = I18n.OneWindow;
             if (model.Body != null)
             {
                 var str = model.Body.Split('%');
                 ViewBag.Body = str;
                 ViewBag.Size = str.Count();
             }
             else { ViewBag.Body = null; ViewBag.Size = 0; }
             return View("ShowPage", model);
         }
         public ActionResult Privatization()
         {
             var model = StaticsMethod.FindStatics("Privatization");
             ViewBag.Header = I18n.Privatization;
             if (model.Body != null)
             {
                 var str = model.Body.Split('%');
                 ViewBag.Body = str;
                 ViewBag.Size = str.Count();
             }
             else { ViewBag.Body = null; ViewBag.Size = 0; }
             return View("ShowPage", model);
         }

        public ActionResult ListOfServices()
        {
            var model = StaticsMethod.FindStatics("ListOfServices");
            ViewBag.Header = I18n.ListOfServices;
            if (model.Body != null)
            {
                var str = model.Body.Split('%');
                ViewBag.Body = str;
                ViewBag.Size = str.Count();
            }
            else { ViewBag.Body = null; ViewBag.Size = 0; }
            return View("ShowPage", model);
        }

         public ActionResult Contacts()
         {
             var model = StaticsMethod.FindStatics("Contacts");
             ViewBag.Header = I18n.Contacts;
             if (model.Body != null)
             {
                 var str = model.Body.Split('%');
                 ViewBag.Body = str;
                 ViewBag.Size = str.Count();
             }
             else { ViewBag.Body = null; ViewBag.Size = 0; }
             return View("ShowPage", model);
         }
        public ActionResult Dispatcher()
         {
             var model = StaticsMethod.FindStatics("dispatcher");
             ViewBag.Header = I18n.Dispatcher;
             if (model.Body != null)
             {
                 var str = model.Body.Split('%');
                 ViewBag.Body = str;
                 ViewBag.Size = str.Count();
             }
             else
             {
                 ViewBag.Body = null;
                 ViewBag.Size = 0;
             }
             return View("ShowPage", model);
         }
        public ActionResult SocialStandart()
        {
            var model = StaticsMethod.FindStatics("SocialStandart");
            ViewBag.Header = I18n.SocialStandart;
            if (model.Body != null)
            {
                var str = model.Body.Split('%');
                ViewBag.Body = str;
                ViewBag.Size = str.Count();
            }
            else
            {
                ViewBag.Body = null;
                ViewBag.Size = 0;
            }
            return View("ShowPage", model);
        }
        public ActionResult Rights()
        {
            var model = StaticsMethod.FindStatics("Rights");
            ViewBag.Header = I18n.Rights;
            if (model.Body != null)
            {
                var str = model.Body.Split('%');
                ViewBag.Body = str;
                ViewBag.Size = str.Count();
            }
            else
            {
                ViewBag.Body = null;
                ViewBag.Size = 0;
            }
            return View("ShowPage", model);
        }
        public ActionResult Tarifs()
        {
            var model = StaticsMethod.FindStatics("Tarifs");
            ViewBag.Header = I18n.Tarifs;
            if (model.Body != null)
            {
                var str = model.Body.Split('%');
                ViewBag.Body = str;
                ViewBag.Size = str.Count();
            }
            else
            {
                ViewBag.Body = null;
                ViewBag.Size = 0;
            }
            return View("ShowPage", model);
        }
    }
}