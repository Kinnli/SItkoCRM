using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitkoCRM.DAL;

namespace SitkoCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainsController : ControllerBase
    {
        private readonly CRMContainer _context;

        public DomainsController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/Domains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domains>>> GetDomains()
        {
            return await _context.Domains.ToListAsync();
        }

        // GET: api/Domains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domains>> GetDomains(int id)
        {
            var domains = await _context.Domains.FindAsync(id);

            if (domains == null)
            {
                return NotFound();
            }

            return domains;
        }

        // PUT: api/Domains/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomains(int id, Domains domains)
        {
            if (id != domains.DomainId)
            {
                return BadRequest();
            }

            _context.Entry(domains).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomainsExists(id))
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

        // POST: api/Domains
        [HttpPost]
        public async Task<ActionResult<Domains>> PostDomains(Domains domains)
        {
            _context.Domains.Add(domains);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDomains", new { id = domains.DomainId }, domains);
        }

        // DELETE: api/Domains/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Domains>> DeleteDomains(int id)
        {
            var domains = await _context.Domains.FindAsync(id);
            if (domains == null)
            {
                return NotFound();
            }

            _context.Domains.Remove(domains);
            await _context.SaveChangesAsync();

            return domains;
        }

        private bool DomainsExists(int id)
        {
            return _context.Domains.Any(e => e.DomainId == id);
        }
    }
}
