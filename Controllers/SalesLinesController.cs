using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBaseContext;
using DataBaseContext.Model;

namespace NET_Framework.Controllers
{
    public class SalesLinesController : Controller
    {
        private NetContext db = new NetContext();

        // GET: SalesLines
        public ActionResult Index()
        {
            return View(db.SalesLines.ToList());
        }

        // GET: SalesLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesLine salesLine = db.SalesLines.Find(id);
            if (salesLine == null)
            {
                return HttpNotFound();
            }
            return View(salesLine);
        }

        // GET: SalesLines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesLines/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesLineId,Quantity,Total,ProductId")] SalesLine salesLine)
        {
            if (ModelState.IsValid)
            {
                db.SalesLines.Add(salesLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesLine);
        }

        // GET: SalesLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesLine salesLine = db.SalesLines.Find(id);
            if (salesLine == null)
            {
                return HttpNotFound();
            }
            return View(salesLine);
        }

        // POST: SalesLines/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesLineId,Quantity,Total,ProductId")] SalesLine salesLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesLine);
        }

        // GET: SalesLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesLine salesLine = db.SalesLines.Find(id);
            if (salesLine == null)
            {
                return HttpNotFound();
            }
            return View(salesLine);
        }

        // POST: SalesLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesLine salesLine = db.SalesLines.Find(id);
            db.SalesLines.Remove(salesLine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
