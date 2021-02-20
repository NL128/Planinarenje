using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
   
    public class DBEntityFramework : IPlaceArea
    {
        private PlaninarenjeEntities1 planinarenjeEntities;
        public DBEntityFramework(PlaninarenjeEntities1 planinarenjeEntities)
        {
            this.planinarenjeEntities = planinarenjeEntities;

        }
        public IEnumerable<IModels> GetAll()
        {
            List<Place> places = new List<Place>();
            foreach (var p in planinarenjeEntities.Places_Tbl.ToList())
            {
                places.Add(new Place()
                {
                    ID = p.ID,
                    PlaceName = p.PlaceName,
                    Description = p.Description,
                    PlaceImage = p.PlaceImage,
                    Subtitle = p.Subtitle
                });

            }
            return places;
        }

        public IModels GetPlace(int ID)
        {
            var DbPlace=   planinarenjeEntities.Places_Tbl.Find(ID);
            if (DbPlace != null)
            {
                return new Place()
                {
                    ID = DbPlace.ID,
                    Description = DbPlace.Description,
                    PlaceName = DbPlace.PlaceName,
                    Subtitle = DbPlace.Subtitle

                };
            }
            return null;
        }

        public Place GetPlaceById(int ID)
        {
            var DbPlace = planinarenjeEntities.Places_Tbl.Find(ID);
            if (DbPlace != null)
            {
                List<Restoran> restorans1 = new List<Restoran>();
                foreach (var restoran in DbPlace.Restoran_Tbl)
                {
                    restorans1.Add(new Restoran()
                    {
                        ID = restoran.ID,
                        RestoranName = restoran.RestoranName,
                        Subtitle = restoran.Subtitle,
                        Description = restoran.Description
                    });
                }
                List<Hotel> hotels = new List<Hotel>();
                foreach (var hotel in DbPlace.Hotel_Tbl)
                {
                    hotels.Add(new Hotel()
                    {
                        ID = hotel.ID,
                        HotelName = hotel.HotelName


                    });
                }
                List<Aktivnosti> aktivnostis = new List<Aktivnosti>();


                Place placeLokal = new Place()
                {
                    ID = DbPlace.ID,
                    Description = DbPlace.Description,
                    PlaceName = DbPlace.PlaceName,
                    Subtitle = DbPlace.Subtitle,
                    PlaceImage = DbPlace.PlaceImage,
                    Coordinates = DbPlace.Coordinates,
                    Restorans = restorans1,
                    Hotels = hotels,
                    Country=new Country()
                    {
                        CountryID=(int)DbPlace.CountryId
                    }


                };
                List<AktivnostiPlaces_Tbl> aktivnostiPlaces_Tbls = DbPlace.AktivnostiPlaces_Tbl.Where(x => x.IsActive == true && x.PlaceID == placeLokal.ID).ToList();
                foreach (var aktivnost in aktivnostiPlaces_Tbls)
                {
                    aktivnostis.Add(new Aktivnosti()
                    {
                        AktivnostiID = aktivnost.Aktivnosti_Tbl.AktivnostiID,
                        ImeAktivnosti = aktivnost.Aktivnosti_Tbl.ImeAktivnosti,
                        IsActive = aktivnost.IsActive
                    });
                }
                placeLokal.Aktivnostis = aktivnostis;
                placeLokal.ComentPlaces_Tbl = DbPlace.ComentPlaces_Tbl;
                placeLokal.Ocena = AverageIs(new Ocena(), DbPlace.ComentPlaces_Tbl.SingleOrDefault());
                
                return placeLokal;
            }
            return null;
        }
        private Ocena AverageIs(Ocena ocena ,ComentPlaces_Tbl comentPlaces_Tbl)
        {
            if (comentPlaces_Tbl != null)
            {
                var ocenaTbl = comentPlaces_Tbl.PlacesOcena_Tbl;
                if (ocenaTbl.Level1 == null)
                {
                    ocenaTbl.Level1 = 0;
                }
                if (ocenaTbl.Level2 == null)
                {
                    ocenaTbl.Level2 = 0;
                }
                if (ocenaTbl.Level3 == null)
                {
                    ocenaTbl.Level3 = 0;
                }
                if (ocenaTbl.Level4 == null)
                {
                    ocenaTbl.Level4 = 0;
                }
                if (ocenaTbl.Level5 == null)
                {
                    ocenaTbl.Level5 = 0;
                }
                ocena.Nivo1 = (int)ocenaTbl.Level1;
                ocena.Nivo2 = (int)ocenaTbl.Level2;
                ocena.Nivo3 = (int)ocenaTbl.Level3;
                ocena.Nivo4 = (int)ocenaTbl.Level4;
                ocena.Nivo5 = (int)ocenaTbl.Level5;
            }else
            {
                ocena.Nivo1 = 0;
                ocena.Nivo2 = 0;
                ocena.Nivo3 = 0;
                ocena.Nivo4 = 0;
                ocena.Nivo5 = 0;
            }
            return ocena;

        }
        public IEnumerable<Place> GetPlaces()
        {
            List<Place> places = new List<Place>();
            foreach (var p in planinarenjeEntities.Places_Tbl.ToList())
            {

                places.Add(new Place()
                {
                    ID = p.ID,
                    PlaceName = p.PlaceName,
                    Description = p.Description,
                    PlaceImage = p.PlaceImage,
                    Subtitle = p.Subtitle,
                    Coordinates = p.Coordinates,
                    Country= new Country()
                    {
                        CountryID=(int)p.CountryId
                    }

                });

            }
            return places;
        }
    }



}
