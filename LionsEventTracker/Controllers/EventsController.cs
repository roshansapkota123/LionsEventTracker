using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LionsEventTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LionsEventTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EventsController : Controller
    {
        private readonly DatabaseContext _context;

        public EventsController(DatabaseContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Events.Add(new Event { });
                _context.SaveChanges();
            }
        }


        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Event>> GetEvents()
        {
            var eventsLists = _context.Events.ToList();

            var events = eventsLists.OrderByDescending(eventList => eventList.Date).
                ThenByDescending(eventsList => eventsList.Time);

            return events.ToList();
        }

        // GET api/<controller>/5
   
        [HttpGet("{id}")]
        public ActionResult<Event> GetEventsById(int? id)
        {
            var evnt = _context.Events.Include(x => x.eventUsers).Where(x => x.Id == id).FirstOrDefault();
            if (evnt == null)
            {
                return NotFound();
            }
            return evnt;
        }
        // create event
        // POST api/<controller>
        [HttpPost]
        [ActionName("CreateEvent")]
        public void CreateEvent([FromBody]Event evnt)
        {
            _context.Events.Add(evnt);
            _context.SaveChanges();
        }

        // POST api/<controller>
        
      // add user
        [HttpPost]
        [ActionName("Subscribe")]
        public void Subscribe(int eventId, int userId)
        {
            var newXref = new EventUser()
            {
                eventId = eventId,
                userId = userId
            };

            var foundEvent = _context.Events.Include(x => x.eventUsers).Where(x => x.Id == eventId).FirstOrDefault();
            if (foundEvent.eventUsers == null)
            {
                foundEvent.eventUsers = new List<EventUser>();
            }
            foundEvent.eventUsers.Add(newXref);
           _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Index(int id, Event evnt)
        {
            var eventInDb = _context.Events.Find(id);
            if (eventInDb == null)
            {
                return NotFound();
            }
            eventInDb.Name = evnt.Name;
            eventInDb.Date = evnt.Date;
            eventInDb.Time = evnt.Time;
            eventInDb.Venue = evnt.Venue;

            _context.Events.Update(eventInDb);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Index(int id)
        {
            var evnt = _context.Events.Find(id);
            if (evnt == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evnt);
            _context.SaveChanges();
            return NoContent();
        }

    }
} 