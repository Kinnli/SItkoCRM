using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitkoCRM.Models;

namespace SitkoCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainsStatusesController : ControllerBase
    {
        private readonly CRMContainer _context;

        public DomainsStatusesController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/DomainsStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomainsStatuses>>> GetDomainsStatuses()
        {
            return await _context.DomainsStatuses.ToListAsync();
        }

        // GET: api/DomainsStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DomainsStatuses>> GetDomainsStatuses(int id)
        {
            var domainsStatuses = await _context.DomainsStatuses.FindAsync(id);

            if (domainsStatuses == null)
            {
                return NotFound();
            }

            return domainsStatuses;
        }

        // PUT: api/DomainsStatuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomainsStatuses(int id, DomainsStatuses domainsStatuses)
        {
            if (id != domainsStatuses.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(domainsStatuses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomainsStatusesExists(id))
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

        // POST: api/DomainsStatuses
        [HttpPost]
        public async Task<ActionResult<DomainsStatuses>> PostDomainsStatuses(DomainsStatuses domainsStatuses)
        {
            _context.DomainsStatuses.Add(domainsStatuses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDomainsStatuses", new { id = domainsStatuses.StatusId }, domainsStatuses);
        }

        // DELETE: api/DomainsStatuses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DomainsStatuses>> DeleteDomainsStatuses(int id)
        {
            var domainsStatuses = await _context.DomainsStatuses.FindAsync(id);
            if (domainsStatuses == null)
            {
                return NotFound();
            }

            _context.DomainsStatuses.Remove(domainsStatuses);
            await _context.SaveChangesAsync();

            return domainsStatuses;
        }

        private bool DomainsStatusesExists(int id)
        {
            return _context.DomainsStatuses.Any(e => e.StatusId == id);
        }
    }
}
