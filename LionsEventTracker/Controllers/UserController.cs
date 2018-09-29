using LionsEventTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LionsEventTracker.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Users.Add(new User { });
                _context.SaveChanges();
            }
        }


        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            var user = await _context.Users.ToListAsync();
            return Json(user);
        }

        // GET api/<controller>/5

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userNameInDb = _context.Users.Single(u => u.UserName == user.UserName);
            if (userNameInDb == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return new OkResult();
            }
            return BadRequest();

        }
        //[Route("addEvent")]
        //[HttpPost("{id}/{eventId")]
        //public IActionResult AddEvent(int id, int eventId)
        //{
        //    User dbUser = _context.eventUser.Where(x => x.id == id).Include(x => x.evnt).First();
        //    Event dbEvent = _context.evnt.Where(x => x.id == eventId).First();
        //    dbUser.events.Add(new Model.EventUser { events = dbEvent });
        //    _context.SaveChanges();
        //    return Json(dbUser);
        //}
        public IActionResult LogIn(User user)
        {
            var userInDb = _context.Users.Single(u => u.UserName == user.UserName);
            if(userInDb != null)
            {
                return Ok(userInDb);
            }
            return NotFound();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            var userInDb = _context.Users.Find(id);
            if (userInDb == null)
            {
                return NotFound();
            }
            userInDb.FirstName = user.FirstName;
            userInDb.LastName = user.LastName;
            userInDb.Email = user.Email;
            userInDb.UserName = user.UserName;

            _context.Users.Update(userInDb);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
