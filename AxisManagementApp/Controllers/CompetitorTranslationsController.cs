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
    public class CompetitorTranslationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetitorTranslationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompetitorTranslations
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompetitorTranslations.ToListAsync());
        }

        // GET: CompetitorTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitorTranslation = await _context.CompetitorTranslations
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (competitorTranslation == null)
            {
                return NotFound();
            }

            return View(competitorTranslation);
        }

        // GET: CompetitorTranslations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetitorTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,ProjectID,ProjectStatus,StrenuusProductCode,Payor,Product,EI,CS,MR,DataLoadDate,LastEditMSID")] CompetitorTranslation competitorTranslation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competitorTranslation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competitorTranslation);
        }

        // GET: CompetitorTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitorTranslation = await _context.CompetitorTranslations.FindAsync(id);
            if (competitorTranslation == null)
            {
                return NotFound();
            }
            return View(competitorTranslation);
        }

        // POST: CompetitorTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,ProjectID,ProjectStatus,StrenuusProductCode,Payor,Product,EI,CS,MR,DataLoadDate,LastEditMSID")] CompetitorTranslation competitorTranslation)
        {
            if (id != competitorTranslation.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competitorTranslation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitorTranslationExists(competitorTranslation.RecordID))
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
            return View(competitorTranslation);
        }

        // GET: CompetitorTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitorTranslation = await _context.CompetitorTranslations
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (competitorTranslation == null)
            {
                return NotFound();
            }

            return View(competitorTranslation);
        }

        // POST: CompetitorTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competitorTranslation = await _context.CompetitorTranslations.FindAsync(id);
            if (competitorTranslation != null)
            {
                _context.CompetitorTranslations.Remove(competitorTranslation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitorTranslationExists(int id)
        {
            return _context.CompetitorTranslations.Any(e => e.RecordID == id);
        }
    }
}
