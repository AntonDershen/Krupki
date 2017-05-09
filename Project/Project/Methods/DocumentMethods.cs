using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;
using System.Web;
using Project.Models;

namespace Project.Methods
{
    public class DocumentMethods
    {
        public static List<Document> GetDocumentsByType(DocsTypes type)
        {
            List<Document> docs;
            using (var db = new Db())
            {
                docs = db.Documents.Where(x => x.Type == type).ToList();
            }
            docs.Reverse();
            return docs;
        }

        public static string SaveFile(HttpPostedFileBase file)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "Documents\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." +
                                file.FileName.Split('/').Last().Split('.').Last();
            file.SaveAs(path + fileName);
            return fileName;
        }

        public static void SaveDocument(DocumentsView documentsView, string fileUrl)
        {
            var document = new Document()
            {
                Description = documentsView.Description,
                Type = (DocsTypes)Enum.Parse(typeof(DocsTypes), documentsView.Type),
                DocumentUrl = fileUrl,
                Date = DateTime.Now
            };
            using (var db = new Db())
            {
                db.Documents.Add(document);
                db.SaveChanges();
            }
        }

        public static void RemoveDocument(int documentId)
        {
            using (var db = new Db())
            {
                var doc = db.Documents.Find(documentId);
                if (doc == null) return;
                try
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Documents\\" + doc.DocumentUrl);
                }
                catch (Exception e)
                {
                    //Do nothing...
                }
                finally
                {
                    db.Entry(doc).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }
    }
}