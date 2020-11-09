using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KAB_SQL_API.Models;

namespace KAB_SQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceSystemsController : ControllerBase
    {
        private readonly APIContext _context;

        public SourceSystemsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/SourceSystems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SourceSystem>>> GetSourceSystem()
        {
            return await _context.SourceSystem.ToListAsync();
        }

        // GET: api/SourceSystems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SourceSystem>> GetSourceSystem(int id)
        {
            var sourceSystem = await _context.SourceSystem.FindAsync(id);

            if (sourceSystem == null)
            {
                return NotFound();
            }

            return sourceSystem;
        }

        // PUT: api/SourceSystems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSourceSystem(int id, SourceSystem sourceSystem)
        {
            if (id != sourceSystem.SourceSystemId)
            {
                return BadRequest();
            }

            _context.Entry(sourceSystem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourceSystemExists(id))
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

        // POST: api/SourceSystems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SourceSystem>> PostSourceSystem(SourceSystem sourceSystem)
        {
            _context.SourceSystem.Add(sourceSystem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSourceSystem", new { id = sourceSystem.SourceSystemId }, sourceSystem);
        }

        // DELETE: api/SourceSystems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SourceSystem>> DeleteSourceSystem(int id)
        {
            var sourceSystem = await _context.SourceSystem.FindAsync(id);
            if (sourceSystem == null)
            {
                return NotFound();
            }

            _context.SourceSystem.Remove(sourceSystem);
            await _context.SaveChangesAsync();

            return sourceSystem;
        }

        private bool SourceSystemExists(int id)
        {
            return _context.SourceSystem.Any(e => e.SourceSystemId == id);
        }
    }
}
