using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public class DBEntityFrameworkUsers : IUserArea
    {
        private PlaninarenjeEntities1 PlaninarenjeEntities1;
      public DBEntityFrameworkUsers(PlaninarenjeEntities1 planinarenjeEntities)
        {
            this.PlaninarenjeEntities1 = planinarenjeEntities;
        }

        public string GetImageName(string Email)
        {
            var userinfo= PlaninarenjeEntities1.AspNetUsers.FirstOrDefault(x => x.Email.ToLower() == Email.ToLower());
            if(userinfo != null)
            {
                return userinfo.Image;
            }
            return null;
        }

        public UserInfo GetUserByEmail(string Email)
        {
            var localUser = PlaninarenjeEntities1.AspNetUsers.SingleOrDefault(x => x.Email == Email);
            if (localUser != null)
            {

                return new UserInfo()
                {
                    Id = localUser.Id,
                    Email = localUser.Email,
                    RealUserName = localUser.RealUserName,
                    Image = localUser.Image,
                    IsGuid = localUser.IsGuid,
                    IsVerified = localUser.EmailConfirmed
                };
            }
            return null;
        }

        public IEnumerable<UserInfo> GetUsers()
        {
            throw new NotImplementedException();
        }
        
        public UserInfo UpdateUserInfo(string Email, UserInfo userInfo)
        {
            
            AspNetUser aspNetUser = PlaninarenjeEntities1.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
            if(aspNetUser!= null)
            {
                 
                aspNetUser.RealUserName = userInfo.RealUserName;
                if (PlaninarenjeEntities1.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == userInfo.Email.ToLower()) == null)
                {
                    aspNetUser.Email = userInfo.Email;
                    aspNetUser.UserName = userInfo.Email;
                }
                aspNetUser.PhoneNumber = userInfo.PhoneNumber;

                if (userInfo.Image != null)
                {
                    aspNetUser.Image = userInfo.Image;
                }
                
                
                int isSaved= PlaninarenjeEntities1.SaveChanges();
                if (isSaved > 0)
                {

                    userInfo.Image = GetImageName(aspNetUser.Email);


                    return userInfo;
                }
                return new UserInfo() {
                    RealUserName = aspNetUser.RealUserName,
                    Email= aspNetUser.Email,
                    PhoneNumber= aspNetUser.PhoneNumber,
                    Image= aspNetUser.Image
                };
            }
            return null;
        }
    }
}
