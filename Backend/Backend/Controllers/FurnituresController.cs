using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FurnituresController : ControllerBase
    {
        private readonly TodoContext _context;

        public FurnituresController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Furnitures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Furniture>>> GetFurnitures()
        {
            return await _context.Furnitures.ToListAsync();
        }

        // GET: api/Furnitures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Furniture>> GetFurniture(int id)
        {
            var furniture = await _context.Furnitures.FindAsync(id);

            if (furniture == null)
            {
                return NotFound();
            }

            return furniture;
        }

        // PUT: api/Furnitures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFurniture(int id, Furniture furniture)
        {
            if (id != furniture.Id)
            {
                return BadRequest();
            }

            _context.Entry(furniture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnitureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Furnitures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Furniture>> PostFurniture(Furniture furniture)
        {
            _context.Furnitures.Add(furniture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFurniture", new { id = furniture.Id }, furniture);
        }

        // DELETE: api/Furnitures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Furniture>> DeleteFurniture(int id)
        {
            var furniture = await _context.Furnitures.FindAsync(id);
            if (furniture == null)
            {
                return NotFound();
            }

            _context.Furnitures.Remove(furniture);
            await _context.SaveChangesAsync();

            return furniture;
        }

        private bool FurnitureExists(int id)
        {
            return _context.Furnitures.Any(e => e.Id == id);
        }
    }
}
