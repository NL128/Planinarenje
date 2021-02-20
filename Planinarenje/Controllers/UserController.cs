using DBLibrary.DBContexts;
using Newtonsoft.Json;
using Planinarenje.Models.ClientInputs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Controllers
{
    public class UserController : BaseController
    {
        private IDBInheritAccessCountryEvents _dBCountryArea;
        public UserController(IDBInheritAccessCountryEvents dBCountryArea)
        {
            _dBCountryArea = dBCountryArea;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Edit()
        {
            if(User.Identity.IsAuthenticated)
            {
                    //isGuide
               
                    Factory.FactoryUserData.Create();
                    var init = Factory.FactoryUserData.Initialization();
                    DBLibrary.Models.Profil profReturned = null;

                
                    profReturned = _dBCountryArea.GetProfilById(User.Identity.Name);
                    if (profReturned != null)
                    {
                        init.Profil = profReturned;
                    }
                    else
                    {
                        return RedirectToAction("LogOffFromMethod", "Account");
                    }
                
                    return View(init);
              
               
               
            }

            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public JsonResult GetCompanies(InputDrustvaSearch inputDrustvaSearch)
        {
            var companies = _dBCountryArea.GetCompaniesByName(inputDrustvaSearch.Search);
            string serializedValue= JsonConvert.SerializeObject(companies);
            return Json(serializedValue,JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public  ActionResult NotGuideUserData(NotGuideUser NotGuideUserInput)
        {
            
            Planinarenje.Models.Factory.GuideNotGuideFactory factoryUserData =  new Models.Factory.GuideNotGuideFactory("NotGuide");
            var result = (Planinarenje.Models.ClientInputs.NotGuideUserData)factoryUserData.Create();

            var userInfo = new DBLibrary.Models.UserInfo();
           
            userInfo.RealUserName = NotGuideUserInput.FirstName + " " + NotGuideUserInput.LastName;
            userInfo.PhoneNumber = NotGuideUserInput.Phone;
            userInfo.Email = NotGuideUserInput.Email;
            if (NotGuideUserInput.Image != null)
            {
                var localUser = _dBCountryArea.GetUserByEmail(User.Identity.Name);
                string folderPath = ConfigurationManager.AppSettings["DefaultUserImageFolder"];

                try
                {
                    (bool, string) isSaved = UploadUserImage.SaveFile(Server.MapPath(folderPath), NotGuideUserInput.Image, localUser.Id);
                    if (isSaved.Item1)
                    {
                        //update and image 
                        userInfo.Image = isSaved.Item2;
                        userInfo = _dBCountryArea.UpdateUserInfo(User.Identity.Name, userInfo);

                    }
                }catch(Exception ex)
                {
                    
                    userInfo.Image = NotGuideUserInput.Image.FileName;
                    result.UserError = new UserError() { Message = ex.Message,StatusCode=(int)HttpStatusCode.InternalServerError };
                    


                }
                
            }
            else
            {
                //update with no image 
                userInfo = _dBCountryArea.UpdateUserInfo(User.Identity.Name, userInfo);
            }
            if (userInfo != null)
            {
                result.FirstName = userInfo.RealUserName.Split(' ')[0];
                result.LastName = userInfo.RealUserName.Split(' ')[1];
                result.ImageName = userInfo.Image;
                result.Email = userInfo.Email;
                result.Phone = userInfo.PhoneNumber;
            }

            return PartialView("_NotGuideUserForm", result);
        }

       



    }
}