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
    /* Visits Controller
     *  Add New Visits
     *  View Visit History
     *  Modify Visits
     *  Delete Visits
     *  Record Patient Admission/Discharge Date
     *  Search Visits by Patient/Doctor Name
     */

    public class tblVisitsController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: tblVisits
        public ActionResult Index(string SearchBy, string search) 
        {
            // Search implementation which allows the user to filter search by 2 criteria

            if (SearchBy == "Patient")
            {
                // Retrieves exact search results
                return View(db.tblVisits.Where(x => x.tblPatient.Name.Contains(search) || search == null).ToList());
            }
            else if (SearchBy == "Doctor")
            {
                return View(db.tblVisits.Where(x => x.tblDoctor.Name.Contains(search) || search == null).ToList());
            }
            else
            {
                var tblVisits = db.tblVisits.Include(t => t.tblDoctor).Include(t => t.tblPatient);
                return View(tblVisits.ToList());
            }
        } // END OF Index

        // GET: tblVisits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVisit tblVisit = db.tblVisits.Find(id);
            if (tblVisit == null)
            {
                return HttpNotFound();
            }
            return View(tblVisit);
        }

        // GET: tblVisits/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.tblDoctors, "Id", "Name");
            ViewBag.PatientId = new SelectList(db.tblPatients, "Id", "Name");
            return View();
        }

        // POST: tblVisits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Complaint,DoctorId,PatientId,DateOfAdmission,DateOfDischarge")] tblVisit tblVisit)
        {
            if (ModelState.IsValid)
            {
                db.tblVisits.Add(tblVisit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.tblDoctors, "Id", "Name", tblVisit.DoctorId);
            ViewBag.PatientId = new SelectList(db.tblPatients, "Id", "Name", tblVisit.PatientId);
            return View(tblVisit);
        }

        // GET: tblVisits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVisit tblVisit = db.tblVisits.Find(id);
            if (tblVisit == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.tblDoctors, "Id", "Name", tblVisit.DoctorId);
            ViewBag.PatientId = new SelectList(db.tblPatients, "Id", "Name", tblVisit.PatientId);
            return View(tblVisit);
        }

        // POST: tblVisits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Complaint,DoctorId,PatientId,DateOfAdmission,DateOfDischarge")] tblVisit tblVisit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVisit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.tblDoctors, "Id", "Name", tblVisit.DoctorId);
            ViewBag.PatientId = new SelectList(db.tblPatients, "Id", "Name", tblVisit.PatientId);
            return View(tblVisit);
        }

        // GET: tblVisits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVisit tblVisit = db.tblVisits.Find(id);
            if (tblVisit == null)
            {
                return HttpNotFound();
            }
            return View(tblVisit);
        }

        // POST: tblVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVisit tblVisit = db.tblVisits.Find(id);
            db.tblVisits.Remove(tblVisit);
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
