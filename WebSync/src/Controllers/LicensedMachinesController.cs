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
        public IEnumerable<LicenseMachine> GetLicensedMachines()
        {
            return _context.LicenseMachines;
        }

        // GET: api/LicensedMachines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLicensedMachine([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var licensedMachine = await _context.LicenseMachines.SingleOrDefaultAsync(m => m.LicenseMachineId == id);

            if (licensedMachine == null)
            {
                return NotFound();
            }

            return Ok(licensedMachine);
        }


      


    }
}