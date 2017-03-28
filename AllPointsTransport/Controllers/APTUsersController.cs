using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllPointsTransport.Models;
using APT.BusinessObjects.Models;

namespace AllPointsTransport.Controllers
{
    public class APTUsersController : BaseController
    {
        private AllPointsTransportEntities db = new AllPointsTransportEntities();

        // GET: APTUsers
        public ActionResult Index()
        {
            return View(db.APTUsers.ToList());
        }

        // GET: APTUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APTUser aPTUser = db.APTUsers.Find(id);
            if (aPTUser == null)
            {
                return HttpNotFound();
            }
            return View(aPTUser);
        }

        // GET: APTUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: APTUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FullName,UserName,Password,Email,PhoneNumber,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] APTUser aPTUser)
        {
            if (ModelState.IsValid)
            {
                db.APTUsers.Add(aPTUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aPTUser);
        }

        // GET: APTUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APTUser aPTUser = db.APTUsers.Find(id);
            if (aPTUser == null)
            {
                return HttpNotFound();
            }
            return View(aPTUser);
        }

        // POST: APTUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FullName,UserName,Password,Email,PhoneNumber,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] APTUser aPTUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPTUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aPTUser);
        }

        // GET: APTUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APTUser aPTUser = db.APTUsers.Find(id);
            if (aPTUser == null)
            {
                return HttpNotFound();
            }
            return View(aPTUser);
        }

        // POST: APTUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APTUser aPTUser = db.APTUsers.Find(id);
            db.APTUsers.Remove(aPTUser);
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
