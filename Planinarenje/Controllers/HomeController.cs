using DBLibrary.DBContexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Controllers
{
    public class HomeController : BaseController
    { private IDBInheritAccessCountryEvents _dBCountryArea;
        public HomeController(IDBInheritAccessCountryEvents dBCountryArea)
        {
            _dBCountryArea = dBCountryArea;
        }
        public ActionResult Index()
        {
           
            var Countries =    _dBCountryArea.GetCountries();
            
            return View(Countries);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Explore()
        {
            return View();
        }
      
        
       
        
    }
}