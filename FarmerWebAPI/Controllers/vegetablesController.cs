using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmerWebAPI.Models;

namespace FarmerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vegetablesController : ControllerBase
    {
        private readonly FarmerDataBaseContext _context;

        public vegetablesController(FarmerDataBaseContext context)
        {
            _context = context;
        }

        // GET: api/vegetables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vegetable>>> Getvegetables()
        {
            return await _context.Vegetables.ToListAsync();
        }

        // GET: api/vegetables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vegetable>> Getvegetable(int id)
        {
            var vegetable = await _context.Vegetables.FindAsync(id);

            if (vegetable == null)
            {
                return NotFound();
            }

            return vegetable;
        }

        // PUT: api/vegetables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putvegetable(int id, Vegetable vegetable)
        {
            /*if (id != vegetable.Id)
            {
                return BadRequest();
            }*/

            _context.Entry(vegetable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /*if (!vegetableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }*/
            }

            return NoContent();
        }

        // POST: api/vegetables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPost("addItem")]
        public async Task<ActionResult<vegetable>> Postvegetable(vegetable vegetable)
        {
            _context.vegetables.Add(vegetable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvegetable", new { id = vegetable.Id }, vegetable);

        }*/




        // DELETE: api/vegetables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vegetable>> Deletevegetable(int id)
        {
            var vegetable = await _context.Vegetables.FindAsync(id);
            if (vegetable == null)
            {
                return NotFound();
            }

            _context.Vegetables.Remove(vegetable);
            await _context.SaveChangesAsync();

            return vegetable;

        }

        /*private bool vegetableExists(int id)
        {
            return _context.vegetables.Any(e => e.Id == id);
        }*/
    }
}
