using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _512143.Context;
using _512143.Models;

namespace _512143.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TovarsController : ControllerBase
    {
        private readonly TovarContext _context;

        public TovarsController(TovarContext context)
        {
            _context = context;
        }

        // GET: api/Tovars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tovar>>> GetTovars()
        {
            return await _context.Tovars.ToListAsync();
        }

        // GET: api/Tovars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tovar>> GetTovar(int id)
        {
            var tovar = await _context.Tovars.FindAsync(id);

            if (tovar == null)
            {
                return NotFound();
            }

            return tovar;
        }

        // PUT: api/Tovars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTovar(int id, Tovar tovar)
        {
            if (id != tovar.id)
            {
                return BadRequest();
            }

            _context.Entry(tovar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TovarExists(id))
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

        // POST: api/Tovars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tovar>> PostTovar(Tovar tovar)
        {
            _context.Tovars.Add(tovar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTovar", new { id = tovar.id }, tovar);
        }

        // DELETE: api/Tovars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tovar>> DeleteTovar(int id)
        {
            var tovar = await _context.Tovars.FindAsync(id);
            if (tovar == null)
            {
                return NotFound();
            }

            _context.Tovars.Remove(tovar);
            await _context.SaveChangesAsync();

            return tovar;
        }

        private bool TovarExists(int id)
        {
            return _context.Tovars.Any(e => e.id == id);
        }
    }
}
