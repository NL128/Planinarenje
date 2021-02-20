using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult HttpError404()
        {
            
            
            return View("~/Views/Error/HttpError404.cshtml");
        }
        public ActionResult HttpError500()
        {
            return View();
        }
        public ActionResult Error(Exception exception)
        {
            ViewBag.ErrorMessage = exception.Message;
            return View();
        }
    }
}