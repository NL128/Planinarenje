using DBLibrary.DBContexts;
using DBLibrary.Models;
using Planinarenje.Models.ClientInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Controllers
{
    public class EventsController : BaseController
    {
        private IDBInheritAccessCountryEvents _dB;
        public EventsController(IDBInheritAccessCountryEvents dB)
        {
            _dB = dB;
        }
        public ActionResult Index()
        {
            
           var events=   _dB.GetEvents();
           

            return View(events);
        }
        public ActionResult Details(EventInput eventInput)
        {
            if (ModelState.IsValid)
            {

              var eventObj=   _dB.GetEventById(eventInput.ID);
                return View(eventObj);
            }
            return RedirectToAction("Index");
        }
        public ActionResult SearchEvents(SearchInput country)
        {

            if (ModelState.IsValid)
            {
                var events = _dB.GetEventsBySearch(country.ID,country.EventInput);
                return View("Index", events);
            }
            return View("Index", null);
            
        }

        public ActionResult EventComments(int id)
        {
            var eventComments=  _dB.GetEventCommentsByEvent(id);
            ViewBag.EventID = id;
            return View(eventComments);
        }
        [HttpPost]
        public ActionResult CreateOcenaForEvent(int id)
        {
            var createdOcena =  _dB.CreateOcenaAssignToEvent(id);

            return View();
        }
        [HttpPost]

        public ActionResult AddEventComment(InputEventComment inputEventComment)
        {

            if (ModelState.IsValid)
            {
               var ocenaAssigned=   _dB.AddOcenaToEvent(User.Identity.Name, inputEventComment.ID, inputEventComment.SingleEvaluation);
                inputEventComment.EventOcenaId = ocenaAssigned.OcenaID;
                var commentAdded= _dB.AddEventComment(inputEventComment, User.Identity.Name);
                //need to return 
                if(commentAdded != null)
                {
                   return PartialView("_EventComment",_dB.GetEventCommentsByEvent(inputEventComment.ID));
                }
            }
            
            return PartialView("_EventComment",null);
        }
        [HttpGet]
        public ActionResult CreateEvent(int Id)
        {
            
            Place place=  _dB.GetPlaceById(Id);

            return View(place);
        }

        [HttpPost]
        public ActionResult CreateEvent(CreateEventInput createEventInput)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _dB.GetUserByEmail(User.Identity.Name);
                    if (user != null && user.IsGuid)
                    {
                        var profile = _dB.GetProfilById(User.Identity.Name);
                        if (profile != null)
                        {
                            string eventImagName = "IMG" + Guid.NewGuid()  + ".jpg";
                            createEventInput.Image.SaveAs(Server.MapPath("~/Images/Events/" + eventImagName));
                            var createdEvent = _dB.CreateEvent(new Event()
                            {
                                Profil_Id= profile.ProfilID,
                                Title = createEventInput.EventTitle,
                                EventDesription = createEventInput.EventDescription,
                                EventName = createEventInput.EventName,
                                TrenutnoStanje_id = (int)EventStates.Active,
                                Country_id = createEventInput.CountryID,
                                Image= eventImagName,
                                Place = new Place() { ID = createEventInput.PlaceID }
                            });
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Events");
                    }
                }catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return RedirectToAction("Index", "Events");
                }
            }

            return RedirectToAction("Index", "Events");
        }

        
    }
}