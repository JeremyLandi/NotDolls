using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using NotDolls.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NotDolls.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class GeekController : Controller
    {

        private NotDollsContext _context;

        public GeekController(NotDollsContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<object> users = from user in _context.Geek
                                       select new
                                       {
                                           user.GeekId,
                                           user.UserName,
                                           user.Email,
                                           user.Created_Date,
                                           user.Location,
                                       //    Figurines = String.Format("/api/Inventory?GeekId={0}", user.GeekId)
                                       //};

                                            Figurines = from geek in _context.Geek
                                                        join inv in _context.Inventory
                                                        on geek.GeekId equals inv.GeekId
                                                        where inv.GeekId == geek.GeekId
                                                        select new Inventory
                                                        {
                                                            InventoryId = inv.InventoryId,
                                                            Name = inv.Name,
                                                            InventoryDescription = inv.InventoryDescription,
                                                            Price = inv.Price,
                                                            Quantity = inv.Quantity,
                                                            Height = inv.Height,
                                                            Weight = inv.Weight,
                                                            Year = inv.Year,
                                                            Quality = inv.Quality,
                                                            Sold = inv.Sold,
                                                            CreatedDate = inv.CreatedDate
                                                        }
                                        };

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetGeek")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Geek geek = _context.Geek.Single(m => m.GeekId == id);

            if (geek == null)
            {
                return NotFound();
            }

            return Ok(geek);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Geek geek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existinUser = from g in _context.Geek
                              where g.UserName == geek.UserName
                              select g;

            if (existinUser == null)
            {
                _context.Geek.Add(geek);
            }

            _context.Geek.Add(geek);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GeekExists(geek.GeekId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetGeek", new { id = geek.GeekId }, geek);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Geek geek = _context.Geek.Single(m => m.GeekId == id);
            if (geek == null)
            {
                return NotFound();
            }

            _context.Geek.Remove(geek);
            _context.SaveChanges();

            return Ok(geek);
        }

        private bool GeekExists(int id)
        {
            return _context.Geek.Count(e => e.GeekId == id) > 0;
        }
    }
}
