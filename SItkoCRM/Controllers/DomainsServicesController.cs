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
    public class DomainsServicesController : ControllerBase
    {
        private readonly CRMContainer _context;

        public DomainsServicesController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/DomainsServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomainsServices>>> GetDomainsServices()
        {
            return await _context.DomainsServices.ToListAsync();
        }

        // GET: api/DomainsServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DomainsServices>> GetDomainsServices(int id)
        {
            var domainsServices = await _context.DomainsServices.FindAsync(id);

            if (domainsServices == null)
            {
                return NotFound();
            }

            return domainsServices;
        }

        // PUT: api/DomainsServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomainsServices(int id, DomainsServices domainsServices)
        {
            if (id != domainsServices.Id)
            {
                return BadRequest();
            }

            _context.Entry(domainsServices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomainsServicesExists(id))
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

        // POST: api/DomainsServices
        [HttpPost]
        public async Task<ActionResult<DomainsServices>> PostDomainsServices(DomainsServices domainsServices)
        {
            _context.DomainsServices.Add(domainsServices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDomainsServices", new { id = domainsServices.Id }, domainsServices);
        }

        // DELETE: api/DomainsServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DomainsServices>> DeleteDomainsServices(int id)
        {
            var domainsServices = await _context.DomainsServices.FindAsync(id);
            if (domainsServices == null)
            {
                return NotFound();
            }

            _context.DomainsServices.Remove(domainsServices);
            await _context.SaveChangesAsync();

            return domainsServices;
        }

        private bool DomainsServicesExists(int id)
        {
            return _context.DomainsServices.Any(e => e.Id == id);
        }
    }
}
