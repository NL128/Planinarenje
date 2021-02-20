using DBLibrary.DBContexts;
using Planinarenje.Models.ClientInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Controllers
{
    public class CommentController : BaseController
    {
        private IDBInheritAccessCountryEvents _dbCommand;
        public CommentController(IDBInheritAccessCountryEvents dbCommand)
        {
            _dbCommand = dbCommand;
        }
        public ActionResult Place(int Place)
        {
           var commants= _dbCommand.GetPlaceComments(Place);
            PlaceCommentOutput placeCommentOutput = new PlaceCommentOutput();
            placeCommentOutput.comentPlaces_Tbls = commants;
            placeCommentOutput.placeID = Place;
            return View(placeCommentOutput);
        }
        
        [HttpPost]
        
        public ActionResult AddComment(PlaceCommentInput placeCommentInput)
        {
         
                if (!ModelState.IsValid)
                {

                    var commants = _dbCommand.GetComentPlacesByUser(User.Identity.Name, placeCommentInput.Place);
                    return PartialView("_PlaceComment", commants);
                }
                else
                {
                    var ocenaAdded = _dbCommand.AddOcena(User.Identity.Name, placeCommentInput.Place, placeCommentInput.Ocena);
                    if (ocenaAdded != null)
                    {
                        var commants = _dbCommand.AddPlaceComment(User.Identity.Name, placeCommentInput.Place, placeCommentInput.Comment, ocenaAdded.ID, placeCommentInput.Ocena);
                        return PartialView("_PlaceComment", commants);
                    }

                    var commants2 = _dbCommand.GetComentPlacesByUser(User.Identity.Name, placeCommentInput.Place);
                    return PartialView("_PlaceComment", commants2);
                }
            
        
        }
    }
}