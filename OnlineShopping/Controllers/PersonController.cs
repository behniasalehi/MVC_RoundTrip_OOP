using OnlineShopping.Models.DomainModel.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    
    public class PersonController : Controller
    {
        #region [- ctor -]
        public PersonController()
        {
            Ref_PersonCrud = new Models.DomainModel.POCO.PersonCrud();
        }
        #endregion
        #region [- props -]
        public Models.DomainModel.POCO.PersonCrud Ref_PersonCrud { get; set; }
        #endregion

        #region [- Actions -]

        #region [- Index() -]
        // GET: Person
        //[Route("index")]
        public ActionResult Index()
        {
            return View(Ref_PersonCrud.Select());
        }
        #endregion

        #region [- create -]
        //[Route("Create")]
        #region [- Get -]
        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region [- Post -]
        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,LastName,Age")] Person person)
        {
            if (ModelState.IsValid)
            {
                Ref_PersonCrud.Insert(person);
                return RedirectToAction("index");
            }

            return View(person);
        }
        #endregion
        #endregion

        #region [- Edit -]
        #region [- Get -]
        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = Ref_PersonCrud.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        #endregion

        #region [- Post -]
        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,LastName,Age")] Person person)
        {
            if (ModelState.IsValid)
            {
                Ref_PersonCrud.Update(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
        #endregion
        #endregion

        #region [- Delete -] 
        #region [- Get -] 
        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var person  = Ref_PersonCrud.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        #endregion

        #region [- Post -]
        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ref_PersonCrud.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion 
        #endregion

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = Ref_PersonCrud.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        #endregion
    }
}