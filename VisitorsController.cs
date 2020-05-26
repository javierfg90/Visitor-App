using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentApartment.Models;

namespace RentApartment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly VisitorContext _context;

        public VisitorsController(VisitorContext context)
        {
            _context = context;
        }

        // GET: api/visitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitor>>> GetVisitor()
        {
            return await _context.Visitors.ToListAsync();
        }

        // GET: api/visitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitor>> GetVisitor(long id)
        {
            var visitor = await _context.Visitors.FindAsync(id);

            if (visitor == null)
            {
                return NotFound();
            }

            return visitor;
        }

        // PUT: api/visitors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitor(long id, Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorExists(id))
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

        // POST: api/visitors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            _context.Visitors.Add(visitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisitor), new { id = visitor.Id }, visitor);
        }

        // DELETE: api/visitors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Visitor>> DeleteVisitor(long id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }

            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();

            return visitor;
        }

        private bool VisitorExists(long id)
        {
            return _context.Visitors.Any(e => e.Id == id);
        }
    }
}
