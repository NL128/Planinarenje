using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public class DBEntityFrameworkComments: IComments
    {
        private PlaninarenjeEntities1 planinarenjeEntities;
        public DBEntityFrameworkComments(PlaninarenjeEntities1 planinarenjeEntities)
        {
            this.planinarenjeEntities = planinarenjeEntities;

        }

        public PlacesOcena_Tbl AddOcena(string Email, int PlaceID, float Ocena)
        {
           var locUser= planinarenjeEntities.AspNetUsers.SingleOrDefault(x=>x.Email.ToLower()==Email.ToLower());
            var dbOcena = planinarenjeEntities.PlacesOcena_Tbl.SingleOrDefault(x=>x.PlaceId==PlaceID);
            PlacesOcena_Tbl ocena= new PlacesOcena_Tbl();
            if (dbOcena == null)
            {
                ocena = OcenaEvaluation(Ocena, new PlacesOcena_Tbl());
                ocena.PlaceId = PlaceID;
                planinarenjeEntities.PlacesOcena_Tbl.Add(ocena);
            }
            else
            {
                ocena = OcenaEvaluation(Ocena, dbOcena);
            }
        
            


            planinarenjeEntities.SaveChanges();
            return ocena;
        }
        private PlacesOcena_Tbl OcenaEvaluation(float Ocena,PlacesOcena_Tbl placesOcena_Tbl)
        {
            if(Ocena>0f && Ocena < 1f )
            {
                if (placesOcena_Tbl.Level1 == null)
                {
                    placesOcena_Tbl.Level1 = 0;
                }
                placesOcena_Tbl.Level1++;

            }else if(Ocena>=1f && Ocena < 2f)
            {
                if (placesOcena_Tbl.Level2 == null)
                {
                    placesOcena_Tbl.Level2 = 0;
                }
                placesOcena_Tbl.Level2 ++;
            }else if(Ocena >=2f && Ocena < 3f)
            {
                if (placesOcena_Tbl.Level3 == null)
                {
                    placesOcena_Tbl.Level3 = 0;
                }
                placesOcena_Tbl.Level3++;

            }else if(Ocena >=3 && Ocena < 4)
            {
                if (placesOcena_Tbl.Level4 == null)
                {
                    placesOcena_Tbl.Level4 = 0;
                }
                placesOcena_Tbl.Level4++;
            }else if(Ocena >=4 && Ocena <= 5f)
            {
                if (placesOcena_Tbl.Level5 == null)
                {
                    placesOcena_Tbl.Level5 = 0;
                }
                placesOcena_Tbl.Level5++;
            }
            return placesOcena_Tbl;
        }

        public IEnumerable<ComentPlaces_Tbl> AddPlaceComment(string email, int PlaceID, string Comment,long OcenaID,float Ocena)
        {
           var localUser= planinarenjeEntities.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
            planinarenjeEntities.ComentPlaces_Tbl.Add(new ComentPlaces_Tbl()
            {
                Comment=Comment,
                DateTime=DateTime.UtcNow,
                PlaceId=PlaceID,
                UserFromId= localUser.Id,
                OcenaId=OcenaID,
                SingleEvaluation=Ocena
            });
             planinarenjeEntities.SaveChanges();
            return GetPlaceComments(PlaceID);
        }

      

        public IEnumerable<ComentPlaces_Tbl> GetComentPlacesByUser(string email, int placeID)
        {
            var localUser= planinarenjeEntities.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
            var comments=   planinarenjeEntities.ComentPlaces_Tbl.Where(x => x.UserFromId == localUser.Id && x.PlaceId == placeID).ToList();


            return comments;
        }

        public IEnumerable<ComentPlaces_Tbl> GetPlaceComments(int placeID)
        {
            var comments = planinarenjeEntities.ComentPlaces_Tbl.Where(x => x.PlaceId == placeID).ToList();
            return comments;
        }
    }
}

