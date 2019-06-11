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
    public class ServicesPricesController : ControllerBase
    {
        private readonly CRMContainer _context;

        public ServicesPricesController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/ServicesPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesPrices>>> GetPrices()
        {
            return await _context.Prices.ToListAsync();
        }

        // GET: api/ServicesPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesPrices>> GetServicesPrices(int id)
        {
            var servicesPrices = await _context.Prices.FindAsync(id);

            if (servicesPrices == null) return NotFound();

            return servicesPrices;
        }

        // PUT: api/ServicesPrices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicesPrices(int id, ServicesPrices servicesPrices)
        {
            if (id != servicesPrices.SerPriceId) return BadRequest();

            _context.Entry(servicesPrices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesPricesExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/ServicesPrices
        [HttpPost]
        public async Task<ActionResult<ServicesPrices>> PostServicesPrices(ServicesPrices servicesPrices)
        {
            _context.Prices.Add(servicesPrices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicesPrices", new {id = servicesPrices.SerPriceId}, servicesPrices);
        }

        // DELETE: api/ServicesPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicesPrices>> DeleteServicesPrices(int id)
        {
            var servicesPrices = await _context.Prices.FindAsync(id);
            if (servicesPrices == null) return NotFound();

            _context.Prices.Remove(servicesPrices);
            await _context.SaveChangesAsync();

            return servicesPrices;
        }

        private bool ServicesPricesExists(int id)
        {
            return _context.Prices.Any(e => e.SerPriceId == id);
        }
    }
}