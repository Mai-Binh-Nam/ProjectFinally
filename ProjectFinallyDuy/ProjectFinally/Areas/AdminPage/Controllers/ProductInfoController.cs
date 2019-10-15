using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectFinally.Areas.AdminPage.Models;
using PagedList;

namespace ProjectFinally.Areas.AdminPage.Controllers
{
    public class ProductInfoController : Controller
    {
        private WebsiteBanHang1Entities1 db = new WebsiteBanHang1Entities1();

        // GET: AdminPage/ProductInfo
        public PartialViewResult Index(int? page)
        {
            if (page == null) page = 1;
            var info = (from l in db.SANPHAMs
                        select l).OrderBy(x => x.maSP);
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
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: AdminPage/ProductInfo/Create
        public ActionResult Create()
        {
            ViewBag.maGH = new SelectList(db.GIANHANGs, "maGH", "EmailAddress");
            return View();
        }

        // POST: AdminPage/ProductInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSP,tenSP,motaSP,imageSP,baohanhSP,soluongSP,dongiaSP,hangsxSP,pheduyet,maGH,color1,color2,color3")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maGH = new SelectList(db.GIANHANGs, "maGH", "EmailAddress", sANPHAM.maGH);
            return View(sANPHAM);
        }

        // GET: AdminPage/ProductInfo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.maGH = new SelectList(db.GIANHANGs, "maGH", "EmailAddress", sANPHAM.maGH);
            return View(sANPHAM);
        }

        // POST: AdminPage/ProductInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSP,tenSP,motaSP,imageSP,baohanhSP,soluongSP,dongiaSP,hangsxSP,pheduyet,maGH,color1,color2,color3")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maGH = new SelectList(db.GIANHANGs, "maGH", "EmailAddress", sANPHAM.maGH);
            return View(sANPHAM);
        }

        // GET: AdminPage/ProductInfo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
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
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
