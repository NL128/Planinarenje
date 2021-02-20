using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public interface IPlaceArea : IDBAccess<Place>
    {
        IEnumerable<Place> GetPlaces();
        Place GetPlaceById(int ID);
    }
}
