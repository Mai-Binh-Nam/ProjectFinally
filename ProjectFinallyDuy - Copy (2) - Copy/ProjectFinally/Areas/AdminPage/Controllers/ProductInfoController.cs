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
    public class ProductInfoController : Controller
    {
        private WebsiteBanHangEntities db = new WebsiteBanHangEntities();

        // GET: AdminPage/ProductInfo
        public PartialViewResult Index(int? page)
        {
            if (page == null) page = 1;
            var info = (from l in db.sanphams
                        select l).OrderBy(x => x.id);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return PartialView(info.ToPagedList(pageNumber, pageSize));
        }

        // GET: AdminPage/ProductInfo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sANPHAM = db.sanphams.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: AdminPage/ProductInfo/Create
        public ActionResult Create()
        {
            ViewBag.maGH = new SelectList(db.Admins, "Id", "EmailAddress");
            return View();
        }

        // POST: AdminPage/ProductInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ten,motasp,image,thoigianbaohanh,soluongsp,dongiasp,mansx,mausac,size,nosize,daban,maloai,dongiakhuyenmai,ngaydang")] sanpham sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.sanphams.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maGH = new SelectList(db.Admins, "id", "EmailAddress", sANPHAM.id);
            return View(sANPHAM);
        }

        // GET: AdminPage/ProductInfo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sANPHAM = db.sanphams.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.maGH = new SelectList(db.Admins, "Id", "EmailAddress", sANPHAM.id);
            return View(sANPHAM);
        }

        // POST: AdminPage/ProductInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ten,motasp,image,thoigianbaohanh,soluongsp,dongiasp,mansx,mausac,size,nosize,daban,maloai,dongiakhuyenmai,ngaydang")] sanpham sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maGH = new SelectList(db.Admins, "maGH", "EmailAddress", sANPHAM.id);
            return View(sANPHAM);
        }

        // GET: AdminPage/ProductInfo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sANPHAM = db.sanphams.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: AdminPage/ProductInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sanpham sANPHAM = db.sanphams.Find(id);
            db.sanphams.Remove(sANPHAM);
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
