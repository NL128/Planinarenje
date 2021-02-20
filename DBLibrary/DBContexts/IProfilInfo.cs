using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public interface IProfilInfo:IDBAccess<Profil>
    {
        Profil GetProfilById(string Email);
        Profil SaveProfile(Profil profil);
        Profil CreateProfile(string Email);
    }
}
