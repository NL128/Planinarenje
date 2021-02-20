using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
   public class DBEntityFrameworkCountryArea : IDBCountryArea
    {
        private PlaninarenjeEntities1 planinarenjeEntities;
        public DBEntityFrameworkCountryArea(PlaninarenjeEntities1 planinarenjeEntities)
        {
            this.planinarenjeEntities = planinarenjeEntities;

        }

        public Place AddPlace(Place place)
        {
           var countrySelect=  planinarenjeEntities.Country_Tbl.SingleOrDefault(x => x.CountryName.ToLower() == place.Country.CountryName.ToLower());
            if(countrySelect == null)
            {
              var countryToAdd=  planinarenjeEntities.Country_Tbl.Add(new Country_Tbl()
                {
                    CountryName=place.Country.CountryName,
                    Coordinates=place.Coordinates

                });
                planinarenjeEntities.SaveChanges();
            
               
                place.Country.CountryID = countryToAdd.CountryID;

            } 
            else
            {
                place.Country.CountryID = countrySelect.CountryID;
            }
         var placeToAdd=   planinarenjeEntities.Places_Tbl.Add(new Places_Tbl()
                {
                     PlaceImage= place.PlaceImage,
                      Coordinates=place.Coordinates,
                      Description=place.Description,
                      PlaceName=place.PlaceName,
                      Subtitle=place.Subtitle,
                      CountryId=place.Country.CountryID

                });
            int isAdded=    planinarenjeEntities.SaveChanges();
            if (isAdded > 0)
            {
               
               
                planinarenjeEntities.PlacesOcena_Tbl.Add(new PlacesOcena_Tbl()
                {
                    Level1=0,
                    Level2=0,
                    Level3=0,
                    Level4=0,
                    Level5=0,
                    PlaceId = placeToAdd.ID
                });
               int isPlaceOcenaAdded= planinarenjeEntities.SaveChanges();
                if (isPlaceOcenaAdded > 0)
                {
                    place.ID = placeToAdd.ID;
                }
            }
                return place;
        }

        public IEnumerable<IModels> GetAll()
        {
            List<Country> events = new List<Country>();
            foreach (var p in planinarenjeEntities.Country_Tbl.ToList())
            {
                events.Add(new Country()
                {
                    CountryID=p.CountryID,
                    CountryName=p.CountryName,
                    Coordinates=p.Coordinates,
                    ImageFlag=p.ImageFlag
                  

                });

            }
            return events;
        }

        public IEnumerable<Drustvo> GetCompanies()
        {
            List<Drustvo> drustvos = new List<Drustvo>();
            foreach (var p in planinarenjeEntities.Drustva_Tbl.ToList())
            {
                drustvos.Add(new Drustvo()
                {
                    PD_ID = p.PD_ID,
                    ImeDrustva = p.ImeDrustva,
                    Koordinate = p.Koordinate,
                    AdresaDrustva = p.AdresaDrustva,
                    AddressNumber=p.AddressNumber


                });

            }
            return drustvos;
        }

        public IEnumerable<Drustvo> GetCompaniesByName(string Search)
        {
            List<Drustvo> drustvos = new List<Drustvo>();
            foreach (var p in planinarenjeEntities.Drustva_Tbl.Where(x=>x.ImeDrustva.Contains(Search)).ToList())
            {
                drustvos.Add(new Drustvo()
                {
                    PD_ID = p.PD_ID,
                    ImeDrustva = p.ImeDrustva,
                    Koordinate = p.Koordinate,
                    AdresaDrustva = p.AdresaDrustva,
                    AddressNumber = p.AddressNumber


                });

            }
            return drustvos;
        }

        public IEnumerable<Country> GetCountries()
        {
            List<Country> events = new List<Country>();
            foreach (var p in planinarenjeEntities.Country_Tbl.ToList())
            {
                events.Add(new Country()
                {
                    CountryID = p.CountryID,
                    CountryName = p.CountryName,
                    Coordinates = p.Coordinates,
                    ImageFlag = p.ImageFlag


                });

            }
            return events;
        }

        public IEnumerable<Country> GetCountriesSearch(string Search)
        {
            List<Country> countries = new List<Country>();
            foreach (var p in planinarenjeEntities.Country_Tbl.Where(x => x.CountryName.Contains(Search)).ToList())
            {
                countries.Add(new Country()
                {
                    CountryID = p.CountryID,
                    CountryName = p.CountryName,
                    Coordinates = p.Coordinates,
                    ImageFlag = p.ImageFlag


                });

            }
            return countries;
        }

        public Country GetCountryById(int ID)
        {
            var p = planinarenjeEntities.Country_Tbl.Find(ID);
            if (p != null)
            {
                return new Country()
                {
                    CountryID = p.CountryID,
                    CountryName = p.CountryName,
                    Coordinates = p.Coordinates,
                    ImageFlag = p.ImageFlag

                };
            }
            return null;
        }

        public IModels GetPlace(int ID)
        {
            var p = planinarenjeEntities.Country_Tbl.Find(ID);
            if (p != null)
            {
                return new Country()
                {
                    CountryID = p.CountryID,
                    CountryName = p.CountryName,
                    Coordinates = p.Coordinates,
                    ImageFlag = p.ImageFlag

                };
            }
            return null;
        }

       
    }
}
