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
    public class HostsController : ControllerBase
    {
        private readonly CRMContainer _context;

        public HostsController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/Hosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hosts>>> GetHosts()
        {
            return await _context.Hosts.ToListAsync();
        }

        // GET: api/Hosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hosts>> GetHosts(int id)
        {
            var hosts = await _context.Hosts.FindAsync(id);

            if (hosts == null)
            {
                return NotFound();
            }

            return hosts;
        }

        // PUT: api/Hosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHosts(int id, Hosts hosts)
        {
            if (id != hosts.HostId)
            {
                return BadRequest();
            }

            _context.Entry(hosts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostsExists(id))
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

        // POST: api/Hosts
        [HttpPost]
        public async Task<ActionResult<Hosts>> PostHosts(Hosts hosts)
        {
            _context.Hosts.Add(hosts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHosts", new { id = hosts.HostId }, hosts);
        }

        // DELETE: api/Hosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hosts>> DeleteHosts(int id)
        {
            var hosts = await _context.Hosts.FindAsync(id);
            if (hosts == null)
            {
                return NotFound();
            }

            _context.Hosts.Remove(hosts);
            await _context.SaveChangesAsync();

            return hosts;
        }

        private bool HostsExists(int id)
        {
            return _context.Hosts.Any(e => e.HostId == id);
        }
    }
}
