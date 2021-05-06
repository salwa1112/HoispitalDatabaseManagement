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
    /* Patients Controller
     *  Add New Patients
     *  Assign Doctors to Patients
     *  View/Modify/Delete Patients Profiles
     *  Search Patients by Name/Phone/Health Card Number
     */

    public class tblPatientsController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: tblPatients
        public ActionResult Index(string SearchBy, string search)
        {

            // Search implementation which allows the user to filter search by 3 criteria
            if (SearchBy == "Name")
            {
                // Retrieves exact search results
                return View(db.tblPatients.Where(x => x.Name.Contains(search) || search == null).ToList());
            }

            else if(SearchBy == "Telephone")
            {
                return View(db.tblPatients.Where(x => x.Telephone.Contains(search) || search == null).ToList());
            }

            else if (SearchBy == "HealthCardNumber")
            {
                return View(db.tblPatients.Where(x => x.HealthCardNumber.Contains(search) || search == null).ToList());
            }

            else {
                var tblPatients = db.tblPatients.Include(t => t.tblDoctor);
                return View(tblPatients.ToList());
            }

        } // END OF Index

        // GET: tblPatients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            return View(tblPatient);
        }

        // GET: tblPatients/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.tblDoctors, "Id", "Name");
            return View();
        }

        // POST: tblPatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Address,Telephone,DateOfBirth,DoctorId,HealthCardNumber")] tblPatient tblPatient)
        {
            if (ModelState.IsValid)
            {
                db.tblPatients.Add(tblPatient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.tblDoctors, "Id", "Name", tblPatient.DoctorId);
            return View(tblPatient);
        }

        // GET: tblPatients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.tblDoctors, "Id", "Name", tblPatient.DoctorId);
            return View(tblPatient);
        }

        // POST: tblPatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Address,Telephone,DateOfBirth,DoctorId,HealthCardNumber")] tblPatient tblPatient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.tblDoctors, "Id", "Name", tblPatient.DoctorId);
            return View(tblPatient);
        }

        // GET: tblPatients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            return View(tblPatient);
        }

        // POST: tblPatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPatient tblPatient = db.tblPatients.Find(id);
            db.tblPatients.Remove(tblPatient);
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