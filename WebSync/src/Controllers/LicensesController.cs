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

        // GET: /api/Licenses/12313424
        [HttpGet("{id}")]
        public IEnumerable<License> GetLicense([FromRoute] string id)
        {
            var LicMac=_context.LicenseMachines.SingleOrDefault(n => n.DeviceId == id);
            return _context.Licenses.Where<License>(m=>m.Id== LicMac.LicenseId);
        }

        //// GET: api/Licenses/A100-123
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetLicense([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    //License newlicense = new License();
        //    //newlicense.LicenseId = Guid.NewGuid();
        //    //newlicense.CustomId = "A100-123";
        //    //_context.Licenses.Add(newlicense);
        //    //await _context.SaveChangesAsync();
        //    var license = await _context.Licenses.SingleOrDefaultAsync(m => m.LicenseId == id);

        //    if (license == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(license);
        //}

       

      
      

       
    }


}