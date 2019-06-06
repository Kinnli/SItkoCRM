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
    public class ClientContactsController : ControllerBase
    {
        private readonly CRMContainer _context;

        public ClientContactsController(CRMContainer context)
        {
            _context = context;
        }

        // GET: api/ClientContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientContacts>>> GetClientContacts()
        {
            return await _context.ClientContacts.ToListAsync();
        }

        // GET: api/ClientContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientContacts>> GetClientContacts(int id)
        {
            var clientContacts = await _context.ClientContacts.FindAsync(id);

            if (clientContacts == null)
            {
                return NotFound();
            }

            return clientContacts;
        }

        // PUT: api/ClientContacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientContacts(int id, ClientContacts clientContacts)
        {
            if (id != clientContacts.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(clientContacts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientContactsExists(id))
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

        // POST: api/ClientContacts
        [HttpPost]
        public async Task<ActionResult<ClientContacts>> PostClientContacts(ClientContacts clientContacts)
        {
            _context.ClientContacts.Add(clientContacts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientContacts", new { id = clientContacts.ContactId }, clientContacts);
        }

        // DELETE: api/ClientContacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientContacts>> DeleteClientContacts(int id)
        {
            var clientContacts = await _context.ClientContacts.FindAsync(id);
            if (clientContacts == null)
            {
                return NotFound();
            }

            _context.ClientContacts.Remove(clientContacts);
            await _context.SaveChangesAsync();

            return clientContacts;
        }

        private bool ClientContactsExists(int id)
        {
            return _context.ClientContacts.Any(e => e.ContactId == id);
        }
    }
}
