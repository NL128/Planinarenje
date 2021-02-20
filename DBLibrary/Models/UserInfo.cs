using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class BaseUserInfo : IModels
    {
        public string Id { get; set; }
        public string RealUserName { get; set; }
        
    }
    public class UserInfoWithPhone : BaseUserInfo
    {
        public string PhoneNumber { get; set; }
    }
    public class UserInfoWithImage : UserInfoWithPhone
    {
        public string Image { get; set; }
        
    }
    
    public class UserInfo : UserInfoWithImage
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsGuid { get; set; }
       
        public bool IsVerified { get; set; }

        
      
    }
   
}
