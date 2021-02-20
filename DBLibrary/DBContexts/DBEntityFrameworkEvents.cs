using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public class DBEntityFrameworkEvents : IDBEvents
    {
        private PlaninarenjeEntities1 planinarenjeEntities;
        public DBEntityFrameworkEvents(PlaninarenjeEntities1 planinarenjeEntities)
        {
            this.planinarenjeEntities = planinarenjeEntities;

        }
        public EventOcena_Tbl CreateOcenaAssignToEvent(int ID)
        {
            var eventOcena = new EventOcena_Tbl();
            
            planinarenjeEntities.EventOcena_Tbl.Add(eventOcena);
            return eventOcena;
        }
        public Ocena AddOcenaToEvent(string Email,int EventID, int Ocena)
        {
            var localUser = planinarenjeEntities.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
            Ocena ev = new Ocena();


            if (localUser != null)
            {
              var currentEvent=  planinarenjeEntities.EventOcena_Tbl.SingleOrDefault(x => x.ID == EventID);
                if(currentEvent != null)
                {
                    var locEvent= AssignOrAddNewOcena(Ocena, currentEvent,planinarenjeEntities);
                    ev.Nivo1 = locEvent.Level1;
                    ev.Nivo2 = locEvent.Level2;
                    ev.Nivo3 = locEvent.Level3;
                    ev.Nivo4 = locEvent.Level4;
                    ev.Nivo5 = locEvent.Level5;
                }
              

            }

            return ev;
        }
        private EventOcena_Tbl AssignOrAddNewOcena(int Ocena, EventOcena_Tbl currentEvent,PlaninarenjeEntities1 planinarenjeEntities1)
        {
            var locEvent = AverageEventOcena(Ocena, currentEvent);
            currentEvent = locEvent;
            planinarenjeEntities.SaveChanges();

           
            return currentEvent;
        }
        private LongOcena GetOcenaFromDB(EventOcena_Tbl currentEvent)
        {
            LongOcena ev = new LongOcena();
            if (currentEvent != null)
            {
                ev.Nivo1 = currentEvent.Level1;
                ev.Nivo2 = currentEvent.Level2;
                ev.Nivo3 = currentEvent.Level3;
                ev.Nivo4 = currentEvent.Level4;
                ev.Nivo5 = currentEvent.Level5;
                ev.OcenaIDLong = currentEvent.ID;
            }
            return ev;
        }
        private EventOcena_Tbl AverageEventOcena(int ocena,EventOcena_Tbl eventOcena_Tbl)
        {
            if(eventOcena_Tbl != null)
            {
                if(ocena <= 1f)
                {
                    eventOcena_Tbl.Level1++;

                }else if(ocena <= 2f)
                {
                    eventOcena_Tbl.Level2++;

                }
                else if (ocena <= 3f)
                {
                    eventOcena_Tbl.Level3++;

                }
                else if (ocena <= 4f)
                {
                    eventOcena_Tbl.Level4++;

                }
                else
                {
                    eventOcena_Tbl.Level5++;
                }

            }
            return eventOcena_Tbl;
        }

        public IEnumerable<IModels> GetAll()
        {
            List<Event> events = new List<Event>();
            foreach (var p in planinarenjeEntities.Events_Tbl.ToList())
            {
                events.Add(new Event()
                {
                    Country = new Country() { Coordinates = p.Country_Tbl.Coordinates, CountryID = p.Country_Tbl.CountryID, CountryName = p.Country_Tbl.CountryName, ImageFlag = p.Country_Tbl.ImageFlag },
                    EventID = p.EventID,
                    EventName = p.EventName,
                    EventDesription = p.EventDesription,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate,
                    Image=p.Image,
                    Title=p.Title,
                    Stanje=new Stanje { StanjeID=p.Stanje_Tbl.StanjeID,TrenutnoStanje=p.Stanje_Tbl.TrenutnoStanje}
                    
                });

            }
            return events;
        }

        public Event GetEventById(int ID)
        {
            var p = planinarenjeEntities.Events_Tbl.Find(ID);
            List<Aktivnosti> aktivnostis = new List<Aktivnosti>();

            if (p != null)
            {
                Event e = new Event()
                {
                    Country = new Country() { Coordinates = p.Country_Tbl.Coordinates, CountryID = p.Country_Tbl.CountryID, CountryName = p.Country_Tbl.CountryName, ImageFlag = p.Country_Tbl.ImageFlag },
                    EventID = p.EventID,
                    EventName = p.EventName,
                    EventDesription = p.EventDesription,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate,
                    Verified = p.Verified,
                    Image = p.Image,
                    Stanje = new Stanje { StanjeID = p.Stanje_Tbl.StanjeID, TrenutnoStanje = p.Stanje_Tbl.TrenutnoStanje },
                    Place = new Place
                    {
                        ID = p.Places_Tbl.ID,
                        PlaceName = p.Places_Tbl.PlaceName,
                        PlaceImage = p.Places_Tbl.PlaceImage,
                        Subtitle = p.Places_Tbl.Subtitle,
                        Coordinates = p.Places_Tbl.Coordinates
                    }

                };
                foreach (var aktivnost in p.AktivnostiEvents_Tbl.Where(x => x.EventID == ID && x.IsActive == true))
                {
                    aktivnostis.Add(new Aktivnosti()
                    {
                        AktivnostiID = aktivnost.AktivnostID,
                        ImeAktivnosti = aktivnost.Aktivnosti_Tbl.ImeAktivnosti,
                        IsActive = aktivnost.IsActive
                    });
                }
                e.Aktivnostis = aktivnostis;
                return e;
            }

            return null;
        }

        public IEnumerable<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            foreach (var p in planinarenjeEntities.Events_Tbl.ToList())
            {
                events.Add(new Event()
                {
                    Country = new Country() { Coordinates = p.Country_Tbl.Coordinates, CountryID = p.Country_Tbl.CountryID, CountryName = p.Country_Tbl.CountryName, ImageFlag = p.Country_Tbl.ImageFlag },
                    EventID = p.EventID,
                    EventName = p.EventName,
                    EventDesription = p.EventDesription,
                    StartDate=p.StartDate,
                    EndDate=p.EndDate,
                    Image = p.Image,
                    Title = p.Title,
                    Stanje = new Stanje { StanjeID = p.Stanje_Tbl.StanjeID, TrenutnoStanje = p.Stanje_Tbl.TrenutnoStanje }

                });

            }
            return events;
        }

        public IEnumerable<Event> GetEventsBySearch(int ID, string EventSearch)
        {
            List<Event> events = new List<Event>();
            if (string.IsNullOrEmpty(EventSearch))
            {
                foreach (var p in planinarenjeEntities.Events_Tbl.Where(x => x.Country_id == ID))
                {
                    events.Add(new Event()
                    {
                        Country = new Country() { Coordinates = p.Country_Tbl.Coordinates, CountryID = p.Country_Tbl.CountryID, CountryName = p.Country_Tbl.CountryName, ImageFlag = p.Country_Tbl.ImageFlag },
                        EventID = p.EventID,
                        EventName = p.EventName,
                        EventDesription = p.EventDesription,
                        EndDate = p.EndDate,
                        StartDate = p.StartDate,
                        Image = p.Image,
                        Title = p.Title,
                        Verified = p.Verified,
                        Stanje = new Stanje { StanjeID = p.Stanje_Tbl.StanjeID, TrenutnoStanje = p.Stanje_Tbl.TrenutnoStanje }

                    });

                }
                return events;
            }

            IQueryable<Events_Tbl> ev = planinarenjeEntities.Events_Tbl.Where(x => x.Country_id == ID && (x.EventDesription.Contains(EventSearch) || x.EventName.Contains(EventSearch)));


            foreach (var p in ev)
            {
                events.Add(new Event()
                {
                    Country = new Country() { Coordinates = p.Country_Tbl.Coordinates, CountryID = p.Country_Tbl.CountryID, CountryName = p.Country_Tbl.CountryName, ImageFlag = p.Country_Tbl.ImageFlag },
                    EventID = p.EventID,
                    EventName = p.EventName,
                    EventDesription = p.EventDesription,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate,
                    Image = p.Image,
                    Title = p.Title,
                    Verified = p.Verified,
                    Stanje = new Stanje { StanjeID = p.Stanje_Tbl.StanjeID, TrenutnoStanje = p.Stanje_Tbl.TrenutnoStanje }

                });

            }
            return events;
        }

        public IModels GetPlace(int ID)
        {
            var p = planinarenjeEntities.Events_Tbl.Find(ID);
            if (p != null)
            {
                return new Event()
                {
                    Country = new Country() { Coordinates = p.Country_Tbl.Coordinates, CountryID = p.Country_Tbl.CountryID, CountryName = p.Country_Tbl.CountryName, ImageFlag = p.Country_Tbl.ImageFlag },
                    EventID = p.EventID,
                    EventName = p.EventName,
                    EventDesription = p.EventDesription,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate,
                    Stanje = new Stanje { StanjeID = p.Stanje_Tbl.StanjeID, TrenutnoStanje = p.Stanje_Tbl.TrenutnoStanje }

                };
            }
            return null;
        }

        public EventComment AddEventComment(InputEventComment eventComment, string Email)
        {
            var localuser = planinarenjeEntities.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
            EventComment eventComment1 = new EventComment();
            if(localuser != null)
            {
                var evComment=new EventComment_tbl()
                {
                    EventDescription=eventComment.EventCommentDescription,
                    EventTitle=eventComment.EventComentTitle,
                    EventID=eventComment.ID,
                    UserID=localuser.Id,
                    SingleEvaluation=eventComment.SingleEvaluation,
                   
                   
                };
                planinarenjeEntities.EventComment_tbl.Add(evComment);
                planinarenjeEntities.SaveChanges();

                eventComment1.EventComentTitle = evComment.EventTitle;
                eventComment1.EventCommentDescription = evComment.EventDescription;
                eventComment1.ID = (int)evComment.EventID;
                eventComment1.SingleEvaluation = (int)evComment.SingleEvaluation;
                var evOcena = AverageEventOcena(eventComment.SingleEvaluation, planinarenjeEntities.EventOcena_Tbl.SingleOrDefault(x => x.ID == eventComment.EventOcenaId));
                eventComment1.Ocena = GetOcenaFromDB(evOcena);



            }
            return eventComment1;
        }

        public IEnumerable<EventComment> GetEventCommentsByEvent(int ID)
        {
            var eventComments=  planinarenjeEntities.EventComment_tbl.Where(x => x.EventID == ID).ToList();

            var returnEventComments = GetEventComments(eventComments);
           
            return returnEventComments;
        }
        
        private IEnumerable<EventComment> GetEventComments(ICollection<EventComment_tbl> eventComment_Tbls)
        {
            List<EventComment> eventComments = new List<EventComment>();
            EventOcena_Tbl eventOcena_Tbl = new EventOcena_Tbl();
            UserInfo userInfo = null;
            foreach(var comment in eventComment_Tbls)
            {
                eventComments.Add(new EventComment()
                {
                    CommentID=(int)comment.ID,
                    ID=(int)comment.EventID,
                    EventComentTitle=comment.EventTitle,
                    EventCommentDescription=comment.EventDescription,
                    SingleEvaluation=(int)comment.SingleEvaluation
                   
                });


                userInfo = new UserInfo()
                {
                    Image = comment.AspNetUser.Image,
                    RealUserName = comment.AspNetUser.RealUserName
                };
                 

            }
            if (eventComments.Count() > 0)
            {
               var eventOcena= planinarenjeEntities.EventOcena_Tbl.SingleOrDefault(x => x.EventId == eventComments[0].ID);
                eventComments[0].Ocena = GetOcenaFromDB(eventOcena);
                eventComments[0].UserInfo = userInfo;
            }
            
            return eventComments;
        }

        public Event CreateEvent(Event inputEvent)
        {

            var eventAdded=    planinarenjeEntities.Events_Tbl.Add(new Events_Tbl()
            {
                Country_id=inputEvent.Country_id,
                Places_id=inputEvent.Place.ID,
                EventDesription=inputEvent.EventDesription,
                EventName=inputEvent.EventName,
                TrenutnoStanje_id=inputEvent.TrenutnoStanje_id,
                Title=inputEvent.Title,
                Verified=true,
                Profil_Id=inputEvent.Profil_Id,
                Image=inputEvent.Image
                
            });
           int isChanged= planinarenjeEntities.SaveChanges();
            if (isChanged > 0)
            {
              var eventOcena=  planinarenjeEntities.EventOcena_Tbl.Add(new EventOcena_Tbl()
                {
                    EventId=eventAdded.EventID,
                    Level1=0,
                    Level2=0,
                    Level3=0,
                    Level4=0,
                    Level5=0
                });
              int isEventOcenaChanged=  planinarenjeEntities.SaveChanges();
                if (isEventOcenaChanged > 0)
                {
                    inputEvent.EventID = eventOcena.ID;
                }
            }
            return inputEvent;
        }
    }
}
public enum EventStates
{
    Active=1,
    Cancel=2,
    Close=3
}