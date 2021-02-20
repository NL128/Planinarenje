using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public interface IUserArea :IDBAccess<UserInfo>
    {
        IEnumerable<UserInfo> GetUsers();
        UserInfo GetUserByEmail(string Email);
        UserInfo UpdateUserInfo(string Email,UserInfo userInfo);
        string GetImageName(string Email);
    }
}
