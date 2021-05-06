using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A4NoahAmaral.Models;

namespace A4NoahAmaral.Controllers
{
    /* Doctors Controller
     *  Add New Doctors
     *  View/Modify/Delete Doctor Profiles
     *  Search Doctor by Name/Office/Address
     */

    public class tblDoctorsController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: tblDoctors
        public ActionResult Index(string SearchBy, string search)
        {
            // Search implementation which allows the user to filter search by 2 criteria

            if(SearchBy == "Name")
            {
                // Retrieves exact search results
                return View (db.tblDoctors.Where(x => x.Name.Contains(search) || search == null).ToList());
            }
            else if(SearchBy == "Office")
            {
                return View(db.tblDoctors.Where(x => x.Office.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.tblDoctors.Where(x => x.Address.Contains(search) || search == null).ToList());
            }
        } // END OF Index

        // GET: tblDoctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoctor tblDoctor = db.tblDoctors.Find(id);
            if (tblDoctor == null)
            {
                return HttpNotFound();
            }
            return View(tblDoctor);
        }

        // GET: tblDoctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblDoctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Office,Email,Telephone,Address")] tblDoctor tblDoctor)
        {
            if (ModelState.IsValid)
            {
                db.tblDoctors.Add(tblDoctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDoctor);
        }

        // GET: tblDoctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoctor tblDoctor = db.tblDoctors.Find(id);
            if (tblDoctor == null)
            {
                return HttpNotFound();
            }
            return View(tblDoctor);
        }

        // POST: tblDoctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Office,Email,Telephone,Address")] tblDoctor tblDoctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDoctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDoctor);
        }

        // GET: tblDoctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoctor tblDoctor = db.tblDoctors.Find(id);
            if (tblDoctor == null)
            {
                return HttpNotFound();
            }
            return View(tblDoctor);
        }

        // POST: tblDoctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDoctor tblDoctor = db.tblDoctors.Find(id);
            db.tblDoctors.Remove(tblDoctor);
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
    } // END OF class
} // END OF namespace