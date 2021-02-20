using DBLibrary;
using DBLibrary.DBContexts;
using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Factory
{
    public static class ChangeActivity
    {
        
        public static ICollection<Aktivnosti> UpdateActivity(int activityId,  string email, IDBInheritAccessCountryEvents planinarenjeEntities1)
        {
           return planinarenjeEntities1.UpdateActivity(activityId,  email);
 
        }

    }
}