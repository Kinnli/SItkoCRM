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
    public class ServicesStatusesController : ControllerBase
    {
        private readonly CRMContainer _context;

        public ServicesStatusesController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/ServicesStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesStatuses>>> GetServicesStatuses()
        {
            return await _context.ServicesStatuses.ToListAsync();
        }

        // GET: api/ServicesStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesStatuses>> GetServicesStatuses(int id)
        {
            var servicesStatuses = await _context.ServicesStatuses.FindAsync(id);

            if (servicesStatuses == null)
            {
                return NotFound();
            }

            return servicesStatuses;
        }

        // PUT: api/ServicesStatuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicesStatuses(int id, ServicesStatuses servicesStatuses)
        {
            if (id != servicesStatuses.SerStatusId)
            {
                return BadRequest();
            }

            _context.Entry(servicesStatuses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesStatusesExists(id))
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

        // POST: api/ServicesStatuses
        [HttpPost]
        public async Task<ActionResult<ServicesStatuses>> PostServicesStatuses(ServicesStatuses servicesStatuses)
        {
            _context.ServicesStatuses.Add(servicesStatuses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicesStatuses", new { id = servicesStatuses.SerStatusId }, servicesStatuses);
        }

        // DELETE: api/ServicesStatuses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicesStatuses>> DeleteServicesStatuses(int id)
        {
            var servicesStatuses = await _context.ServicesStatuses.FindAsync(id);
            if (servicesStatuses == null)
            {
                return NotFound();
            }

            _context.ServicesStatuses.Remove(servicesStatuses);
            await _context.SaveChangesAsync();

            return servicesStatuses;
        }

        private bool ServicesStatusesExists(int id)
        {
            return _context.ServicesStatuses.Any(e => e.SerStatusId == id);
        }
    }
}
