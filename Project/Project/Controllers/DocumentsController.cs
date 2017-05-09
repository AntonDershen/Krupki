using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Project.Filters;
using Project.Methods;
using Project.Models;
using Resources;

namespace Project.Controllers
{
    [Culture]
    public class DocumentsController : Controller
    {
        //
        // GET: /Document/
        public ActionResult Show(DocsTypes type)
        {
            ViewBag.DocsType = type;
            ViewBag.Title = type == DocsTypes.Blank ? I18n.Blanks : I18n.RegulatoryDocuments;
            var docs = DocumentMethods.GetDocumentsByType(type);
            return View(docs);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddDocument(DocsTypes type)
        {
            ViewBag.DocsType = type;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddDocument(DocumentsView docs, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid) return View(docs);
            if (file == null)
            {
                ModelState.AddModelError("Error", Resources.I18n.NoFile);
                return View(docs);
            }
            DocumentMethods.SaveDocument(docs, DocumentMethods.SaveFile(file));
            return RedirectToAction("Show", "Documents", new {type = docs.Type});
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RemoveDocument(int documentId)
        {
            var returnUrl = Request.UrlReferrer.OriginalString;
            DocumentMethods.RemoveDocument(documentId);
            return Redirect(returnUrl);
        }

        public ActionResult DownloadDocument(int documentId)
        {
            var document = new Document();
            using (var db = new Db())
            {
                document = db.Documents.Find(documentId);
                if (document == null) return RedirectToAction("Error","Home");
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = document.DocumentUrl,
                    // always prompt the user for downloading, set to true if you want 
                    // the browser to try to show the file inline
                    Inline = true,
                };
                Response.AppendHeader("Content-Disposition", cd.ToString());
            }
            return File(AppDomain.CurrentDomain.BaseDirectory + "\\Documents\\" + document.DocumentUrl,
                "application/force-download");
        }

	}
}