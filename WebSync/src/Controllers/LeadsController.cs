using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Addon365.Models.Leads;
using Addon365.WebSync.DAL;

namespace Addon365.WebSync.Controllers
{
    [Produces("application/json")]
    [Route("api/Leads")]
    public class LeadsController : Controller
    {
        private readonly SyncAppContext _context;

        public LeadsController(SyncAppContext context)
        {
            _context = context;
        }

        // GET: api/Leads
        [HttpGet]
        public IEnumerable<Lead> GetLeads()
        {
            return _context.Leads
                .Include(l => l.Profile)
                .Include(l => l.LeadSource);
        }

        // GET: api/Leads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLead([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lead = await _context.Leads.SingleOrDefaultAsync(m => m.LeadId == id);

            if (lead == null)
            {
                return NotFound();
            }

            return Ok(lead);
        }

        // PUT: api/Leads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead([FromRoute] Guid id, [FromBody] Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lead.LeadId)
            {
                return BadRequest();
            }

            _context.Entry(lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
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

        // POST: api/Leads
        [HttpPost]
        public async Task<IActionResult> PostLead([FromBody] Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLead", new { id = lead.LeadId }, lead);
        }

        // DELETE: api/Leads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lead = await _context.Leads.SingleOrDefaultAsync(m => m.LeadId == id);
            if (lead == null)
            {
                return NotFound();
            }

            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();

            return Ok(lead);
        }

        private bool LeadExists(Guid id)
        {
            return _context.Leads.Any(e => e.LeadId == id);
        }
    }
}