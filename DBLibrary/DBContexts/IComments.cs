using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
     public interface IComments
     {
        IEnumerable<ComentPlaces_Tbl> GetComentPlacesByUser(string email, int placeID);
        IEnumerable<ComentPlaces_Tbl> GetPlaceComments( int placeID);
        IEnumerable<ComentPlaces_Tbl> AddPlaceComment(string Email,int PlaceID, string Comment,long OcenaID,float Ocena);
        PlacesOcena_Tbl AddOcena(string Email, int PlaceID, float Ocena);
    }
}
