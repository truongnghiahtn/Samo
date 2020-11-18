using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaMo.Models;

namespace SaMo.Controllers
{
    public class ThuNhapsController : Controller
    {
        private QLMONNEYEntities db = new QLMONNEYEntities();

        // GET: ThuNhaps
        public ActionResult Index()
        {
            return View(db.ThuNhaps.ToList());
        }

        // GET: ThuNhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuNhap thuNhap = db.ThuNhaps.Find(id);
            if (thuNhap == null)
            {
                return HttpNotFound();
            }
            return View(thuNhap);
        }

        // GET: ThuNhaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThuNhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idThuNhap,tenThuNhap,moTa,trangThai,ngayTao,ngayUpdate,hinh")] ThuNhap thuNhap)
        {
            if (ModelState.IsValid)
            {
                db.ThuNhaps.Add(thuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thuNhap);
        }

        // GET: ThuNhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuNhap thuNhap = db.ThuNhaps.Find(id);
            if (thuNhap == null)
            {
                return HttpNotFound();
            }
            return View(thuNhap);
        }

        // POST: ThuNhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idThuNhap,tenThuNhap,moTa,trangThai,ngayTao,ngayUpdate,hinh")] ThuNhap thuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuNhap);
        }

        // GET: ThuNhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuNhap thuNhap = db.ThuNhaps.Find(id);
            if (thuNhap == null)
            {
                return HttpNotFound();
            }
            return View(thuNhap);
        }

        // POST: ThuNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThuNhap thuNhap = db.ThuNhaps.Find(id);
            db.ThuNhaps.Remove(thuNhap);
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
