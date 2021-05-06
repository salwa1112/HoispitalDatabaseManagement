using A4NoahAmaral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A4NoahAmaral.Controllers
{

    /* Home Controller
     * Displays User Currently Logged In
     */

    public class HomeController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: Home
        public ActionResult Index()
        {
            // Sends list of login data to the view
            return View(db.tblLogins.ToList());
        }
    } // END OF class
} // END OF namespace