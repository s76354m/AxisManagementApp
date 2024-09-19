using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AxisManagementApp.Models;

namespace AxisManagementApp.Controllers
{
    public class CS_EXP_Project_TranslationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CS_EXP_Project_TranslationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CS_EXP_Project_Translation
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectTranslations.ToListAsync());
        }

        // GET: CS_EXP_Project_Translation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cS_EXP_Project_Translation = await _context.ProjectTranslations
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (cS_EXP_Project_Translation == null)
            {
                return NotFound();
            }

            return View(cS_EXP_Project_Translation);
        }

        // GET: CS_EXP_Project_Translation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CS_EXP_Project_Translation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,ProjectID,BenchmarkFileID,ProjectType,ProjectDesc,Analyst,PM,GoLiveDate,MaxMileage,Status,NewMarket,ProvRef,DataLoadDate,LastEditDate,LastEditMSID,NDB_LOB,RefreshInd")] CSEXPProjectTranslation cS_EXP_Project_Translation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cS_EXP_Project_Translation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cS_EXP_Project_Translation);
        }

        // GET: CS_EXP_Project_Translation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cS_EXP_Project_Translation = await _context.ProjectTranslations.FindAsync(id);
            if (cS_EXP_Project_Translation == null)
            {
                return NotFound();
            }
            return View(cS_EXP_Project_Translation);
        }

        // POST: CS_EXP_Project_Translation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,ProjectID,BenchmarkFileID,ProjectType,ProjectDesc,Analyst,PM,GoLiveDate,MaxMileage,Status,NewMarket,ProvRef,DataLoadDate,LastEditDate,LastEditMSID,NDB_LOB,RefreshInd")] CSEXPProjectTranslation cS_EXP_Project_Translation)
        {
            if (id != cS_EXP_Project_Translation.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cS_EXP_Project_Translation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CS_EXP_Project_TranslationExists(cS_EXP_Project_Translation.RecordID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cS_EXP_Project_Translation);
        }

        // GET: CS_EXP_Project_Translation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cS_EXP_Project_Translation = await _context.ProjectTranslations
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (cS_EXP_Project_Translation == null)
            {
                return NotFound();
            }

            return View(cS_EXP_Project_Translation);
        }

        // POST: CS_EXP_Project_Translation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cS_EXP_Project_Translation = await _context.ProjectTranslations.FindAsync(id);
            if (cS_EXP_Project_Translation != null)
            {
                _context.ProjectTranslations.Remove(cS_EXP_Project_Translation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CS_EXP_Project_TranslationExists(int id)
        {
            return _context.ProjectTranslations.Any(e => e.RecordID == id);
        }
    }
}
