using OnlineShopping.Models.DomainModel.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class ProductController : Controller
    {
        #region [- ctor -]
        public ProductController()
        {
            Ref_ProductCrud = new Models.DomainModel.POCO.ProductCrud();
        }
        #endregion

        #region [- props -]
        public Models.DomainModel.POCO.ProductCrud Ref_ProductCrud { get; set; }
        #endregion


        #region [- Actions -]

        #region [- Index() -]
        // GET: Product
        public ActionResult Index()
        {
            
            return View(Ref_ProductCrud.Select());
        }
        #endregion

        #region [- Create() -]
        #region [- GET -]
        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Category_Ref = new SelectList(Ref_ProductCrud.CategoryList(), "CategoryID", "Title");
            return View();
        }
        #endregion

        #region [- Post -]
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Category_Ref,ProductName,UnitPrice,Quantiy,Discount,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductCrud.Insert(product);
                return RedirectToAction("Index");
            }

            ViewBag.Category_Ref = new SelectList(Ref_ProductCrud.CategoryList(), "CategoryID", "Title", product.Category_Ref);
            return View(product);
        }
        #endregion
        #endregion

        #region [- Edit() -]
        #region [- Get -]
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = Ref_ProductCrud.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Ref = new SelectList(Ref_ProductCrud.CategoryList(), "CategoryID", "Title", product.Category_Ref);
            return View(product);
        }
        #endregion

        #region [- Post -]
        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Category_Ref,ProductName,UnitPrice,Quantiy,Discount,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductCrud.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.Category_Ref = new SelectList(Ref_ProductCrud.CategoryList(), "CategoryID", "Title", product.Category_Ref);
            return View(product);
        }
        #endregion
        #endregion

        #region [- Delete -]
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            var product = Ref_ProductCrud.Find(id);
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
            Ref_ProductCrud.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion

        #endregion
    }
}