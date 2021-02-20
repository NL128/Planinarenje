using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
  public class DBInheritAccessCountryEvents : IDBInheritAccessCountryEvents
    {
        public PlaninarenjeEntities1 PlaninarenjeEntities;

        public DBInheritAccessCountryEvents()
        {
            PlaninarenjeEntities = new PlaninarenjeEntities1();
        }
        public IEnumerable<Place> GetPlaces()
        {
            DBEntityFramework dBEntityFramework = new DBEntityFramework(PlaninarenjeEntities);
            return dBEntityFramework.GetPlaces();
        }

        public Place GetPlaceById(int ID)
        {
            DBEntityFramework dBEntityFramework = new DBEntityFramework(PlaninarenjeEntities);
            return dBEntityFramework.GetPlaceById(ID);
        }

       

       

       

       

        IEnumerable<Country> IDBCountryArea.GetCountries()
        {
            DBEntityFrameworkCountryArea dBEntityFrameworkCountryArea = new DBEntityFrameworkCountryArea(PlaninarenjeEntities);
            return dBEntityFrameworkCountryArea.GetCountries();
        }

        public Country GetCountryById(int ID)
        {
            DBEntityFrameworkCountryArea dBEntityFrameworkCountryArea = new DBEntityFrameworkCountryArea(PlaninarenjeEntities);
            return dBEntityFrameworkCountryArea.GetCountryById(ID);
        }

        IEnumerable<Event> IDBEvents.GetEvents()
        {
            DBEntityFrameworkEvents dBEntityFrameworkEvents = new DBEntityFrameworkEvents(PlaninarenjeEntities);
            return dBEntityFrameworkEvents.GetEvents();
        }

        Event IDBEvents.GetEventById(int ID)
        {
            DBEntityFrameworkEvents dBEntityFrameworkEvents = new DBEntityFrameworkEvents(PlaninarenjeEntities);
            return dBEntityFrameworkEvents.GetEventById(ID);
        }

        public IEnumerable<Event> GetEventsBySearch(int ID,string EventSearch)
        {
            DBEntityFrameworkEvents dBEntityFrameworkEvents = new DBEntityFrameworkEvents(PlaninarenjeEntities);
            return dBEntityFrameworkEvents.GetEventsBySearch(ID, EventSearch);
        }

        public IEnumerable<UserInfo> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserInfo GetUserByEmail(string Email)
        {
            DBEntityFrameworkUsers dBEntityFrameworkUsers = new DBEntityFrameworkUsers(PlaninarenjeEntities);
            return dBEntityFrameworkUsers.GetUserByEmail(Email);
        }

        public Profil GetProfilById(string Email)
        {
            DBEntityFrameworkProfile dBEntityFrameworkProfile = new DBEntityFrameworkProfile(PlaninarenjeEntities);
            return dBEntityFrameworkProfile.GetProfilById(Email);
        }

        public IEnumerable<Drustvo> GetCompanies()
        {
            DBEntityFrameworkCountryArea dBEntityFrameworkCountryArea = new DBEntityFrameworkCountryArea(PlaninarenjeEntities);
            return dBEntityFrameworkCountryArea.GetCompanies();
        }

        public IEnumerable<Drustvo> GetCompaniesByName(string Search)
        {
            DBEntityFrameworkCountryArea dBEntityFrameworkCountryArea = new DBEntityFrameworkCountryArea(PlaninarenjeEntities);
            return dBEntityFrameworkCountryArea.GetCompaniesByName(Search);
        }

        public UserInfo UpdateUserInfo(string Email, UserInfo userInfo)
        {
            DBEntityFrameworkUsers dBEntityFrameworkUsers = new DBEntityFrameworkUsers(PlaninarenjeEntities);
            return dBEntityFrameworkUsers.UpdateUserInfo(Email,userInfo);
        }

        public string GetImageName(string Email)
        {
            DBEntityFrameworkUsers dBEntityFrameworkUsers = new DBEntityFrameworkUsers(PlaninarenjeEntities);
            return dBEntityFrameworkUsers.GetImageName(Email);
        }

        public Profil SaveProfile(Profil profil)
        {
            DBEntityFrameworkProfile dBEntityFrameworkProfile = new DBEntityFrameworkProfile(PlaninarenjeEntities);
            return dBEntityFrameworkProfile.SaveProfile(profil);
        }
        public ICollection<Aktivnosti> GetAktivnostis()
        {
            DBEntityFrameworkProfile dBEntityFrameworkProfile = new DBEntityFrameworkProfile(PlaninarenjeEntities);
            return dBEntityFrameworkProfile.GetAktivnostis();
        }
        public ICollection<Aktivnosti> UpdateActivity(int ID,  string email)
        {
            DBEntityFrameworkProfile dBEntityFrameworkProfile = new DBEntityFrameworkProfile(PlaninarenjeEntities);
            return dBEntityFrameworkProfile.UpdateActivity(ID, email);
        }

        public ICollection<Aktivnosti> GetAktivnostisByUser(string email)
        {
            DBEntityFrameworkProfile dBEntityFrameworkProfile = new DBEntityFrameworkProfile(PlaninarenjeEntities);
            return dBEntityFrameworkProfile.GetAktivnostisByUser(email);
        }

        public IEnumerable<ComentPlaces_Tbl> GetComentPlacesByUser(string email, int placeID)
        {
            DBEntityFrameworkComments dBEntityFrameworkComments = new DBEntityFrameworkComments(PlaninarenjeEntities);
            return dBEntityFrameworkComments.GetComentPlacesByUser(email, placeID);
        }

        public IEnumerable<ComentPlaces_Tbl> GetPlaceComments(int placeID)
        {
            DBEntityFrameworkComments dBEntityFrameworkComments = new DBEntityFrameworkComments(PlaninarenjeEntities);
            return dBEntityFrameworkComments.GetPlaceComments( placeID);
        }

        public IEnumerable<ComentPlaces_Tbl> AddPlaceComment(string Email,int PlaceID, string Comment,long OcenaId,float Ocena)
        {
            DBEntityFrameworkComments dBEntityFrameworkComments = new DBEntityFrameworkComments(PlaninarenjeEntities);
            return dBEntityFrameworkComments.AddPlaceComment(Email, PlaceID, Comment,OcenaId,Ocena);
        }

        public PlacesOcena_Tbl AddOcena(string Email, int PlaceID, float Ocena)
        {
            DBEntityFrameworkComments dBEntityFrameworkComments = new DBEntityFrameworkComments(PlaninarenjeEntities);
            return dBEntityFrameworkComments.AddOcena(Email, PlaceID, Ocena);
        }

        public Ocena AddOcenaToEvent(string Email,int EventID, int Ocena)
        {
            DBEntityFrameworkEvents dBEntityFrameworkEvents = new DBEntityFrameworkEvents(PlaninarenjeEntities);
            return dBEntityFrameworkEvents.AddOcenaToEvent(Email,EventID, Ocena);
        }

        public EventComment AddEventComment(InputEventComment eventComment, string Email)
        {
            DBEntityFrameworkEvents dBEntityFrameworkEvents = new DBEntityFrameworkEvents(PlaninarenjeEntities);
            return dBEntityFrameworkEvents.AddEventComment(eventComment, Email);
        }

        public IEnumerable<EventComment> GetEventCommentsByEvent(int ID)
        {
            DBEntityFrameworkEvents dBEntityFrameworkEvents = new DBEntityFrameworkEvents(PlaninarenjeEntities);
            return dBEntityFrameworkEvents.GetEventCommentsByEvent(ID);
        }

        public EventOcena_Tbl CreateOcenaAssignToEvent(int ID)
        {
            DBEntityFrameworkEvents dBEntityFrameworkEvents = new DBEntityFrameworkEvents(PlaninarenjeEntities);
            return dBEntityFrameworkEvents.CreateOcenaAssignToEvent(ID);
        }

        public IEnumerable<Country> GetCountriesSearch(string Search)
        {
            DBEntityFrameworkCountryArea dBEntityFrameworkCountryArea = new DBEntityFrameworkCountryArea(PlaninarenjeEntities);
            return dBEntityFrameworkCountryArea.GetCountriesSearch(Search);
        }

        public Place AddPlace(Place place)
        {
            DBEntityFrameworkCountryArea dBEntityFrameworkCountryArea = new DBEntityFrameworkCountryArea(PlaninarenjeEntities);
            return dBEntityFrameworkCountryArea.AddPlace(place);
        }

        public Event CreateEvent(Event inputEvent)
        {
            DBEntityFrameworkEvents dBEntityFrameworkEvents = new DBEntityFrameworkEvents(PlaninarenjeEntities);
            return dBEntityFrameworkEvents.CreateEvent(inputEvent);
        }

        public Profil CreateProfile(string Email)
        {
            DBEntityFrameworkProfile dBEntityFrameworkProfile = new DBEntityFrameworkProfile(PlaninarenjeEntities);
            return dBEntityFrameworkProfile.CreateProfile(Email);
        }
    }
}
