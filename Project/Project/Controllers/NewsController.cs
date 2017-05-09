using System.Web;
using System.Web.Mvc;
using Project.Filters;
using Project.Methods;
using Project.Models;

namespace Project.Controllers
{
    [Culture]
    public class NewsController : Controller
    {
        //
        // GET: /News/
        public ActionResult ShowLastNews()
        {
            var list = NewsMethods.GetLastNews();
            return PartialView(list);
        }

        public ActionResult ShowAllNews()
        {
            var list = NewsMethods.GetAllNews();
            return PartialView(list);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddNews(NewsView news, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid) return View(news);
            NewsMethods.SaveNews(news, NewsMethods.SaveImage(image));
            return RedirectToAction("Index","Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RemoveNews(int newsId)
        {
            NewsMethods.RemoveNews(newsId);
            return RedirectToAction("Index","Home");
        }

        public ActionResult NewsView(int? newsId)
        {
            var model = NewsMethods.FindNews(newsId);      
            return View(model);
        }
	}
}