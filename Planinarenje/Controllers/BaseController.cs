using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Controllers
{
    public class BaseController : Controller
    {
        private ILog _log;
        public BaseController()
        {

            _log = LogToFile.GetInstance;
        }
        protected override  void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            
             _log.Log(filterContext.Exception);

            filterContext.Result = SendToErrorPage(filterContext.Exception);





        }
        private ActionResult SendToErrorPage(Exception exception)
        {
            return RedirectToAction("Error", "Error", exception);
        }
       
    }
}