using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class ProductsController : Controller
    {
        private Model1Container db = new Model1Container();

        //// GET: Products
        //public ActionResult Index()
        //{
        //    ViewBag.PrevDisable = "disabled";
        //    ViewBag.PageNumber = 1;

        //    var productSet = db.ProductSet.Include(p => p.Category);
        //    return View(productSet.ToList());           
        //}

        // GET: Products
        public ActionResult Index(int? pageNumber, _PagingPartialView.ClickedLinkType? clickedLinkType, int? activeLinkNumber)
        {
            const int pageSize = 2;

            var data = db.ProductSet.Include(p => p.Category);
            int recordCount = data.Count();

            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);
            ViewBag.Settings = settings;

            var pagedData = data.OrderBy(p => p.Id).Skip((pageNumber.Value - 1) * pageSize).Take(pageSize);

            return View(pagedData.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductSet.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CatId = new SelectList(db.CategorySet, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CatId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.ProductSet.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatId = new SelectList(db.CategorySet, "Id", "Name", product.CatId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductSet.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatId = new SelectList(db.CategorySet, "Id", "Name", product.CatId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CatId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatId = new SelectList(db.CategorySet, "Id", "Name", product.CatId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductSet.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.ProductSet.Find(id);
            db.ProductSet.Remove(product);
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
