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
    public class ServersController : ControllerBase
    {
        private readonly CRMContainer _context;

        public ServersController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/Servers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servers>>> GetServices()
        {
            return await _context.Servers.ToListAsync();
        }

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servers>> GetServers(int id)
        {
            var servers = await _context.Servers.FindAsync(id);

            if (servers == null)
            {
                return NotFound();
            }

            return servers;
        }

        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServers(int id, Servers servers)
        {
            if (id != servers.ServerId)
            {
                return BadRequest();
            }

            _context.Entry(servers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServersExists(id))
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

        // POST: api/Servers
        [HttpPost]
        public async Task<ActionResult<Servers>> PostServers(Servers servers)
        {
            _context.Servers.Add(servers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServers", new { id = servers.ServerId }, servers);
        }

        // DELETE: api/Servers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Servers>> DeleteServers(int id)
        {
            var servers = await _context.Servers.FindAsync(id);
            if (servers == null)
            {
                return NotFound();
            }

            _context.Servers.Remove(servers);
            await _context.SaveChangesAsync();

            return servers;
        }

        private bool ServersExists(int id)
        {
            return _context.Servers.Any(e => e.ServerId == id);
        }
    }
}
