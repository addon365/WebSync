using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Addon365.Models;
using Addon365.WebSync.DAL;

namespace Addon365.WebSync.Controllers
{
    [Produces("application/json")]
    [Route("api/Licenses")]
    public class LicensesController : Controller
    {
        private readonly SyncAppContext _context;

        public LicensesController(SyncAppContext context)
        {
            _context = context;
        }

        // GET: api/Licenses
        [HttpGet]
        public IEnumerable<License> GetLicenses()
        {
            return _context.Licenses;
        }

        // GET: api/Licenses/A100-123
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLicense([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //License newlicense = new License();
            //newlicense.LicenseId = Guid.NewGuid();
            //newlicense.CustomId = "A100-123";
            //_context.Licenses.Add(newlicense);
            //await _context.SaveChangesAsync();
            var license = await _context.Licenses.SingleOrDefaultAsync(m => m.CustomId == id);

            if (license == null)
            {
                return NotFound();
            }

            return Ok(license);
        }

        // PUT: api/Licenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicense([FromRoute] Guid id, [FromBody] License license)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != license.LicenseId)
            {
                return BadRequest();
            }

            _context.Entry(license).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenseExists(id))
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

        // POST: api/Licenses
        [HttpPost]
        public async Task<IActionResult> PostLicense([FromBody] License license)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Licenses.Add(license);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLicense", new { id = license.LicenseId }, license);
        }

        // DELETE: api/Licenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicense([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var license = await _context.Licenses.SingleOrDefaultAsync(m => m.LicenseId == id);
            if (license == null)
            {
                return NotFound();
            }

            _context.Licenses.Remove(license);
            await _context.SaveChangesAsync();

            return Ok(license);
        }

        private bool LicenseExists(Guid id)
        {
            return _context.Licenses.Any(e => e.LicenseId == id);
        }
    }
}