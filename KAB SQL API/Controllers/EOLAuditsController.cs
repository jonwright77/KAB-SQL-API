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
    public class EOLAuditsController : ControllerBase
    {
        private readonly APIContext _context;

        public EOLAuditsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/EOLAudits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EOLAudit>>> GetEOLAudit()
        {
            return await _context.EOLAudit.ToListAsync();
        }

        // GET: api/EOLAudits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EOLAudit>> GetEOLAudit(int id)
        {
            var eOLAudit = await _context.EOLAudit.FindAsync(id);

            if (eOLAudit == null)
            {
                return NotFound();
            }

            return eOLAudit;
        }

        // PUT: api/EOLAudits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEOLAudit(int id, EOLAudit eOLAudit)
        {
            if (id != eOLAudit.EOLID)
            {
                return BadRequest();
            }

            _context.Entry(eOLAudit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EOLAuditExists(id))
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

        // POST: api/EOLAudits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EOLAudit>> PostEOLAudit(EOLAudit eOLAudit)
        {
            _context.EOLAudit.Add(eOLAudit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEOLAudit", new { id = eOLAudit.EOLID }, eOLAudit);
        }

        // DELETE: api/EOLAudits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EOLAudit>> DeleteEOLAudit(int id)
        {
            var eOLAudit = await _context.EOLAudit.FindAsync(id);
            if (eOLAudit == null)
            {
                return NotFound();
            }

            _context.EOLAudit.Remove(eOLAudit);
            await _context.SaveChangesAsync();

            return eOLAudit;
        }

        private bool EOLAuditExists(int id)
        {
            return _context.EOLAudit.Any(e => e.EOLID == id);
        }
    }
}
