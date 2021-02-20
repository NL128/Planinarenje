using DBLibrary.DBContexts;
using DBLibrary.Models;
using Newtonsoft.Json;
using Planinarenje.Models.ClientInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private IDBInheritAccessCountryEvents _dB;
        public AdminController(IDBInheritAccessCountryEvents dB)
        {
            _dB = dB;
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GetPlaces()
        {
             var places= _dB.GetPlaces();
             return View(places);
        }
        public ActionResult AddPlaceView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateProfileAdmin()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateProfile(string Email)
        {
          var profileCreated=   _dB.CreateProfile(Email);
             
          return PartialView("_ProfileCreated",new { isCreated=profileCreated.ProfilID});
        }
       

        [HttpPost]
        public JsonResult GetCountries(InputCountry inputCountry)
        {
            var countries = _dB.GetCountriesSearch(inputCountry.Search);
            string serializedValue = JsonConvert.SerializeObject(countries);
            return Json(serializedValue, JsonRequestBehavior.AllowGet);
        }

    }
}