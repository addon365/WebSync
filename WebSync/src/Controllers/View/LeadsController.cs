using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Addon365.WebSync.DAL;
using Addon365.WebSync.ViewModels;
using Addon365.Models.Leads;
using MicrosoftHeader = Microsoft.Net.Http.Headers;
using SystemHeader = System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

using System.Globalization;
using System.Text;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Filters;
using Addon365.WebSync.Helpers;

namespace Addon365.WebSync.Controllers.View
{
    public class MyViewModel
    {
        public string Username { get; set; }
    }
    public class LeadsController : Controller
    {
        private readonly SyncAppContext _context;

        public LeadsController(SyncAppContext context)
        {
            _context = context;
        }

        // GET: Leads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leads.ToListAsync());
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> UploadForm()
        {
            String folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                + "\\websync";
            String fileName = "Excel_" + DateTime.Now.ToLongDateString() + ".xlsx";


            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);


            String fullPath = folder + "\\" + fileName;

            FormValueProvider formModel;
            using (var stream = System.IO.File.Create(fullPath))
            {
                formModel = await Request.StreamFile(stream);
            }

            var viewModel = new MyViewModel();

            var bindingSuccessful = await TryUpdateModelAsync(viewModel, prefix: "",
               valueProvider: formModel);

            if (!bindingSuccessful)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            }
            IList<Lead> leads = ExcelFileHandler.LoadExcelData(fullPath, _context.LeadSources.ToList());
            if (leads == null)
                return BadRequest("Marked with * are must, " +
                    "please update the missed fields and upload again");
            else
            {
                _context.Leads.AddRange(leads.ToArray());
                await _context.SaveChangesAsync();
                return Ok("You data has been updated.");
            }
        }

        // GET: Leads/Create
        public IActionResult Create()
        {
            ViewBag.LeadSources = _context.LeadSources.ToList<LeadSource>();
            return View();
        }

        // POST: Leads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeadViewModelId,Name,MobileNumber,SourceId,CreatedDate")] LeadViewModel leadViewModel)
        {
            if (ModelState.IsValid)
            {
                Models.Profile profile = new Models.Profile
                {
                    ProfileId = Guid.NewGuid(),
                    Name = leadViewModel.Name,
                    MobileNumber = leadViewModel.MobileNumber
                };
                Lead lead = new Lead
                {
                    LeadId = Guid.NewGuid(),
                    Profile = profile,
                    SourceId = leadViewModel.SourceId
                };
                _context.Add(profile);
                _context.Add(lead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadViewModel);
        }

        #region TODO: Need to fix issues in EDIT & DELETE
        //// GET: Leads/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leadViewModel = await _context.LeadViewModel.SingleOrDefaultAsync(m => m.LeadViewModelId == id);
        //    if (leadViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(leadViewModel);
        //}

        //// POST: Leads/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("LeadViewModelId,Name,MobileNumber,SourceId,CreatedDate")] LeadViewModel leadViewModel)
        //{
        //    if (id != leadViewModel.LeadViewModelId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(leadViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LeadViewModelExists(leadViewModel.LeadViewModelId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(leadViewModel);
        //}

        //// GET: Leads/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leadViewModel = await _context.LeadViewModel
        //        .SingleOrDefaultAsync(m => m.LeadViewModelId == id);
        //    if (leadViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(leadViewModel);
        //}

        //// POST: Leads/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var leadViewModel = await _context.LeadViewModel.SingleOrDefaultAsync(m => m.LeadViewModelId == id);
        //    _context.LeadViewModel.Remove(leadViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LeadViewModelExists(Guid id)
        //{
        //    return _context.LeadViewModel.Any(e => e.LeadViewModelId == id);
        //}
        #endregion
    }
}
