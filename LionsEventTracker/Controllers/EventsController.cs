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
    [Route("api/[controller]")]
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
        public ActionResult<List<Event>> GetAllEvent()
        {
            return _context.Events.ToList();
        }

        // GET api/<controller>/5

        [HttpGet("{id}", Name = "GetEventById")]
        public ActionResult<Event> GetEventById(int id)
        {
            var eventUser = _context.Events.Include(x => x.eventUser).Where(x => x.Id == id).FirstOrDefault();
            if (eventUser == null)
            {
                return NotFound();
            }
            return eventUser;
        }

        // POST api/<controller>
        [HttpPost]
        public void CreateEvent(Event eventUser)
        {
            _context.Events.Add(eventUser);
            //evnt.eventUser.Add(new EventUser()
            //{
            //    eventId = evnt.Id,
            //    userId = 6
            //});     
           _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Event evnt)
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
        public IActionResult Delete(int id)
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
