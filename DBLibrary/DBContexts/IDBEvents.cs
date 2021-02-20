using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public interface IDBEvents : IDBAccess<Event>
    {
        EventOcena_Tbl CreateOcenaAssignToEvent(int ID);
        IEnumerable<Event> GetEvents();
        IEnumerable<Event> GetEventsBySearch(int ID,string EventSearch);
        Event GetEventById(int ID);
        Ocena AddOcenaToEvent(string Email,int EventID, int Ocena);
        EventComment AddEventComment(InputEventComment eventComment, string Email);
        IEnumerable<EventComment> GetEventCommentsByEvent(int ID);
        Event CreateEvent(Event inputEvent);
    }
}
