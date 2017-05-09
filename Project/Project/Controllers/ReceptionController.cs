using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Filters;
using Project.Methods;
using Project.Models;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace Project.Controllers
{
    [Culture]
    public class ReceptionController : Controller
    {
        //
        // GET: /Reception/

        public ActionResult AddReception(string type)
        {
            ViewBag.Type = type;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReception(ReceptionsView receptions)
        {
            ViewBag.Type = receptions.Type;
            if (!ModelState.IsValid)
            {
                return View(receptions);
            }
            ReceptionsMethods.SaveReceptions(receptions);
          return RedirectToAction("Index", "Home");
            
        }
        public ActionResult RemoveReceptions(int receptionId)
        {
            ReceptionsMethods.RemoveReceptions(receptionId);
            return RedirectToAction("Reception", "ViewAllReceptions");
        }
        public ActionResult ViewAllReceptions() {
            var receptions = new List<Receptions>();
            using (var db = new Db()) {
                receptions = db.Receptions.ToList();
            }
            return View(receptions);
        }
        public ActionResult RequestReception(int receptionId)
        {
            var reception = new Receptions();
            using (var db = new Db())
            {
                reception = db.Receptions.Find(receptionId);
                reception.Viewed = true;
                db.SaveChanges();
            }
            ViewBag.reception = reception;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestReception(RequestView request)
        {

            if (ModelState.IsValid)
            {
                Receptions reception;
                using (var db = new Db())
                {
                    reception = db.Receptions.Find(request.ReceptionId);
                    db.SaveChanges();
                }
                var email = request.RequestEMail.Split('@');
                var smtp = new SmtpClient("smtp.gmail.com")
                {
                    Credentials = new System.Net.NetworkCredential(email[0], request.Password),
                    Port = 587,
                    EnableSsl = true
                };
                var m = new MailMessage();
                m.From = new MailAddress(request.RequestEMail);
                m.To.Add(new MailAddress(reception.EMail));
                m.Subject = "Ответ на электронное обращение";
                m.Body = request.Body;
                smtp.EnableSsl = true;
                try { smtp.Send(m); }
                catch (SmtpException e)
                {
                    ModelState.AddModelError("RequestEMail", "Неверно Введен Логин или Пароль");
                    ViewBag.reception = reception;
                    return View(request);
                }
                using (var db = new Db())
                {
                    reception = db.Receptions.Find(request.ReceptionId);
                    reception.Answered = true;
                    reception.DateReception = DateTime.Now;
                    reception.Reception = request.Body;
                    db.SaveChanges();
                }
                smtp.Dispose();
                return RedirectToAction("Index", "Home");
            }
            else
                return View(request);

        }
        public ActionResult DeleteReception(int receptionId)
        {
            using (var db=new Db())
            {
                var reception = db.Receptions.Find(receptionId);
                db.Receptions.Remove(reception);
                db.SaveChanges();
            }


            return RedirectToAction("ViewAllReceptions", "Reception");

        }

        public ActionResult AboutReception()
        {
           return View();
        }
    }
}