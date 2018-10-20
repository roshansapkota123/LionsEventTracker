using LionsEventTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;

namespace LionsEventTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
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
        [ActionName("SignUp")]

        public IActionResult SignUp([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userNameInDb = _context.Users.SingleOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);
            if (userNameInDb == null)
            {
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                
                user.Password = this.GetHashedPassword(user.Password, salt);
                user.salt = salt;
                _context.Users.Add(user);
                _context.SaveChanges();
                return new OkResult();
            }
            return BadRequest("Username or email already exists.");

        }

        //salt => formula
        public String GetHashedPassword(String pwd, byte[] salt)
        {
           

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: pwd,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }


        //[HttpPost]
        //[ActionName("AddEvent")]
        //public void AddEvent(int userId, int eventId)
        //{
        //    var newEvent = new EventUser()
        //    {
        //        userId = userId,
        //         eventId = eventId
        //    };

        //    var foundUser = _context.Users.Include(x => x.eventUsers).Where(x => x.Id == userId).FirstOrDefault();
        //    if (foundUser.eventUsers == null)
        //    {
        //        foundUser.eventUsers = new List<EventUser>();
        //    }
        //    foundUser.eventUsers.Add(newEvent);
        //    _context.SaveChanges();
        //}
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
        [HttpPost]
        [ActionName("LogIn")]
        public IActionResult LogIn([FromBody] User user)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == GetHashedPassword(user.Password, u.salt));
            if(userInDb != null)
            {
                HttpContext.Session.SetString("Id", userInDb.Id.ToString());
                HttpContext.Session.SetString("UserName", userInDb.UserName);
                return Ok(userInDb);
            }
            return NotFound("USerName or Password is incorrect");
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Index(int id, User user)
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
        public IActionResult Index(int id)
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

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Ok();

        }
    }
}
