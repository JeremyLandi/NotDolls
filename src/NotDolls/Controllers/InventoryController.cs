using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using EFGetStarted.AspNetCore.NewDb.Models;
using NotDolls.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NotDolls.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class InventoryController : Controller
    {
        private NotDollsContext _context;

        public InventoryController(NotDollsContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public IActionResult Get([FromQuery]int? GeekId, int? Year)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Inventory> inventory = from i in _context.Inventory
                                           select i;

            if (GeekId != null)
            {
                inventory = inventory.Where(inv => inv.GeekId == GeekId);
            }

            if (Year != null)
            {
                inventory = inventory.Where(inv => inv.Year == Year);
            }

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);            
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetbyId")]
        public IActionResult GetbyId(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Inventory inventory = _context.Inventory.Single(m => m.InventoryId == id);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // POST api/values
        public IActionResult Post([FromBody]Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inventory.Add(inventory);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InventoryExists(inventory.InventoryId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetInventory", new { id = inventory.InventoryId }, inventory);
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

            Inventory inventory = _context.Inventory.Single(m => m.InventoryId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(inventory);
            _context.SaveChanges();

            return Ok(inventory);
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Count(e => e.InventoryId == id) > 0;
        }
    }
}
