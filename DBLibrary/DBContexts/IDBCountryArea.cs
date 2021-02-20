using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public interface IDBCountryArea 
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<Country> GetCountriesSearch(string Search);
        Country GetCountryById(int ID);
        IEnumerable<Drustvo> GetCompanies();
        IEnumerable<Drustvo> GetCompaniesByName(string Search);
        Place AddPlace(Place place);

    }
}
