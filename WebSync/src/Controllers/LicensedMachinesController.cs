using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Addon365.WebSync.DAL;
using Addon365.Models;

namespace Addon365.WebSync.Controllers
{
    [Produces("application/json")]
    [Route("api/LicensedMachines")]
    public class LicensedMachinesController : Controller
    {
        private readonly SyncAppContext _context;
        
        public LicensedMachinesController(SyncAppContext context)
        {
            _context = context;
        }

        // GET: api/LicensedMachines
        [HttpGet]
        public IEnumerable<LicensedMachine> GetLicensedMachines()
        {
            return _context.LicensedMachines;
        }

        // GET: api/LicensedMachines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLicensedMachine([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var licensedMachine = await _context.LicensedMachines.SingleOrDefaultAsync(m => m.LicensedMachineId == id);

            if (licensedMachine == null)
            {
                return NotFound();
            }

            return Ok(licensedMachine);
        }

        // PUT: api/LicensedMachines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicensedMachine([FromRoute] Guid id, [FromBody] LicensedMachine licensedMachine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != licensedMachine.LicensedMachineId)
            {
                return BadRequest();
            }

            _context.Entry(licensedMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicensedMachineExists(id))
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

        // POST: api/LicensedMachines
        [HttpPost]
        public async Task<IActionResult> PostLicensedMachine([FromBody] LicensedMachine licensedMachine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LicensedMachines.Add(licensedMachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLicensedMachine", new { id = licensedMachine.LicensedMachineId }, licensedMachine);
        }

        // DELETE: api/LicensedMachines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicensedMachine([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var licensedMachine = await _context.LicensedMachines.SingleOrDefaultAsync(m => m.LicensedMachineId == id);
            if (licensedMachine == null)
            {
                return NotFound();
            }

            _context.LicensedMachines.Remove(licensedMachine);
            await _context.SaveChangesAsync();

            return Ok(licensedMachine);
        }

        private bool LicensedMachineExists(Guid id)
        {
            return _context.LicensedMachines.Any(e => e.LicensedMachineId == id);
        }
    }
}