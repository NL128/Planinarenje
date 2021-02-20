using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBLibrary;
using DBLibrary.DBContexts;
using DBLibrary.Models;
using Planinarenje.Models.ClientInputs;

namespace Planinarenje.Controllers
{
    public class PlacesController : BaseController
    {
       private IDBInheritAccessCountryEvents _dB;
        public PlacesController(IDBInheritAccessCountryEvents dB)
        {
            _dB = dB;
            
        }
        public ActionResult Index()
        {

          IEnumerable<Place> places= _dB.GetPlaces();
          

          return View(places);
        }
        [HttpGet]
        public ActionResult Description(PlaceInput placeInput)
        {
            if (ModelState.IsValid)
            {

                Place place = _dB.GetPlaceById(placeInput.ID);


                return View(place);
            }
            
             return   RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult CreatePlace(PlaceCreateInput placeCreateInput)
        {
            if (ModelState.IsValid)
            {
                string imgName = "IMG" + Guid.NewGuid() + ".jpg";
                try
                {
                    placeCreateInput.Image.SaveAs(Server.MapPath("~/Theme/img/bg-img/" + imgName));

                    var retAddedPlace = _dB.AddPlace(new Place()
                    {
                        PlaceName = placeCreateInput.PlaceName,
                        Subtitle = placeCreateInput.PlaceSubtitle,
                        Description = placeCreateInput.PlaceDescription,
                        PlaceImage = imgName,
                        Coordinates = placeCreateInput.Coordinates,
                        Country= new Country() { CountryName=placeCreateInput.Country,Coordinates=placeCreateInput.Coordinates}
                    });


                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return RedirectToAction("AddPlaceView", "Admin");
                }
            }
            return RedirectToAction("Index", "Places");
        }

    }
}