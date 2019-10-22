using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectFinally.Models;
using PagedList;

namespace ProjectFinally.Areas.AdminPage.Controllers
{
    public class CustomerInfoController : Controller
    {
        private WebsiteBanHangEntities db = new WebsiteBanHangEntities();

        // GET: AdminPage/CustomerInfo
        public PartialViewResult Index(int? page)
        {
            if (page == null) page = 1;
            var info = (from l in db.TKUsers
                         select l).OrderBy(x => x.Id);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return PartialView(info.ToPagedList(pageNumber, pageSize));
        }

        // GET: AdminPage/CustomerInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKUser tAIKHOAN = db.TKUsers.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // GET: AdminPage/CustomerInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPage/CustomerInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maTK,FirstName,LastName,EmailAddress,Password")] TKUser tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.TKUsers.Add(tAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAIKHOAN);
        }

        // GET: AdminPage/CustomerInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKUser tAIKHOAN = db.TKUsers.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return PartialView(tAIKHOAN);
        }

        // POST: AdminPage/CustomerInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maTK,FirstName,LastName,EmailAddress,Password")] TKUser tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAIKHOAN);
        }

        // GET: AdminPage/CustomerInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKUser tAIKHOAN = db.TKUsers.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: AdminPage/CustomerInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TKUser tAIKHOAN = db.TKUsers.Find(id);
            db.TKUsers.Remove(tAIKHOAN);
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
