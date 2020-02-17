using OnlineShopping.Models.DomainModel.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class CategoryController : Controller
    {

        #region [- ctor -]
        public CategoryController()
        {
            Ref_CategoryCrud = new Models.DomainModel.POCO.CategoryCrud();
        }
        #endregion

        #region [- props -]
        public Models.DomainModel.POCO.CategoryCrud Ref_CategoryCrud{ get; set; }
        #endregion
        #region [- Actions -]

        #region [- Index() -]
        // GET: Category
        public ActionResult Index()
        {
            return View(Ref_CategoryCrud.Select());
        }
        #endregion


        #region [- Create() -] 
        #region [- Get -]
        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region [- Post -]
        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Title,Information")] Category category)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryCrud.Insert(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }
        #endregion
        #endregion


        #region [- Edit() -]

        #region [- Get -] 
        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = Ref_CategoryCrud.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        #endregion

        #region [- Post -]
        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Title,Information")] Category category)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryCrud.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        #endregion
        #endregion

        // GET: Categories/Delete/5
        #region [- Get -]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = Ref_CategoryCrud.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        } 
        #endregion

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_CategoryCrud.Delete(id);
            return RedirectToAction("Index");
        }

        #endregion
    }
}