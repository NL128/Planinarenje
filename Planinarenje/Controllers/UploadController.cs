using DBLibrary.DBContexts;
using DBLibrary.Models;
using Planinarenje.Models;
using Planinarenje.Models.ClientInputs;
using Planinarenje.Models.ValidationArea;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Controllers
{

    [Authorize]
    public class UploadController : BaseController
    {
        private IDBInheritAccessCountryEvents _dbUploadArea;
        public UploadController(IDBInheritAccessCountryEvents dbUploadArea)
        {
            _dbUploadArea = dbUploadArea;
        }
        [HttpPost]
        
        public async Task<ActionResult> UploadFile(UploadUserData formData)
        {
            if (ModelState.IsValid)
            {
                string folderPath = ConfigurationManager.AppSettings["UploadedFiles"] + User.Identity.GetUserID() + "/";
                bool isSaved = formData.SaveFile(Server.MapPath(folderPath));
                if (isSaved) {
                    //save to db 
                    formData.Success = true;

                }
            }
            formData.Profil = _dbUploadArea.GetProfilById(User.Identity.Name);
            

            return await Task.Run(()=> View("~/Views/User/Edit.cshtml", formData));
        }
        [HttpPost]
        public ActionResult GuideUserData(GuideUserData GuideUserInput)
        {
            Planinarenje.Models.Factory.GuideNotGuideFactory factoryUserData = new Models.Factory.GuideNotGuideFactory("Guide");
            var result = (Planinarenje.Models.ClientInputs.GuideUserDataPartial)factoryUserData.Create();

            var userInfo = new DBLibrary.Models.UserInfo();


            userInfo.RealUserName = GuideUserInput.FirstName + " " + GuideUserInput.LastName;
            userInfo.PhoneNumber = GuideUserInput.Phone;
            userInfo.Email = GuideUserInput.Email;

            if (GuideUserInput.Image != null)
            {
                var localUser = _dbUploadArea.GetUserByEmail(User.Identity.Name);
                string folderPath = ConfigurationManager.AppSettings["DefaultUserImageFolder"];
                try
                {
                    (bool, string) isSaved = UploadUserImage.SaveFile(Server.MapPath(folderPath), GuideUserInput.Image, localUser.Id);

                    if (isSaved.Item1)
                    {
                        //update and image 
                        userInfo.Image = isSaved.Item2;
                        userInfo = _dbUploadArea.UpdateUserInfo(User.Identity.Name, userInfo);

                    }
                }catch(Exception ex)
                {
                    userInfo.Image = GuideUserInput.Image.FileName;
                    result.UserError = new UserError() { Message = ex.Message, StatusCode = (int)HttpStatusCode.InternalServerError };
                    
                }

            }
            else
            {
                //update with no image 
                userInfo = _dbUploadArea.UpdateUserInfo(User.Identity.Name, userInfo);
            }
            if (userInfo != null)
            {
                result.FirstName = userInfo.RealUserName.Split(' ')[0];
                result.LastName = userInfo.RealUserName.Split(' ')[1];
                result.ImageName = userInfo.Image;
                result.Email = userInfo.Email;
                result.Phone = userInfo.PhoneNumber;
                
                 
            }
            var profileArea=   _dbUploadArea.GetProfilById(User.Identity.Name);
            if (profileArea != null)
            {
                profileArea.ShortDescription = GuideUserInput.ShortDescription;

                result.ShortDescription = _dbUploadArea.SaveProfile(profileArea).ShortDescription; ;
            }
            //else email is changed , here logout user
            

            //update user data 
            return PartialView("_GuideUserForm", result);
        }
        [HttpPost]

        public ActionResult  ChangeActivity(ActivityInput activityInput)
        {
            int id = Convert.ToInt32(activityInput.ID);
             
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("activity","Activity not changed , pleaes try again!");
                return PartialView("_UserActivities", _dbUploadArea.GetAktivnostisByUser(User.Identity.Name));
            }
            else
            {
                ViewBag.Message = "Change Successful";
            }
            var aktivnostis = Planinarenje.Factory.ChangeActivity.UpdateActivity(id, User.Identity.Name, _dbUploadArea);
            return PartialView("_UserActivities",aktivnostis);
        }
        
        
    }
}