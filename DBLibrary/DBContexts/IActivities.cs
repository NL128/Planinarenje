using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public interface IActivities
    {
        ICollection<Aktivnosti> GetAktivnostis();
        ICollection<Aktivnosti> UpdateActivity(int ID,string email);
        ICollection<Aktivnosti> GetAktivnostisByUser(string email);
    }
}
