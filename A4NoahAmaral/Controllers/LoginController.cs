using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A4NoahAmaral.Models;

namespace A4NoahAmaral.Controllers
{
    /* Login Controller
     * Responsible for Verifying User Login Information
    */

    public class LoginController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: Login
        // [HttpGet]: Responsible for Displaying the View
        public ActionResult Index(int? id)
        {
            // Retrieves data from the DB using Entity Framework
            var login = db.tblLogins.Find(id);

            return View(login);
        } // END OF Index [HttpGet]


        [HttpPost] // Used for handling the Interaction in the View
        public ActionResult Index(tblLogin login)
        {
            if (ModelState.IsValid)
            { // Check the model state
                // if login credentials match with database values
                if (db.tblLogins.ToList().Any(x => x.Username.Equals(login.Username) && x.Password.Equals(login.Password)))
                {
                    // Update login to the Database 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Model State error message
                    ModelState.AddModelError("", "Username or Password was Incorrect.");
                }
            }
            return View(login);
        } // END OF Index [HttpPost]
    } // END OF class
} // END OF namespace