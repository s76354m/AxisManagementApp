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
    public class YLineTranslationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YLineTranslationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YLineTranslations
        public async Task<IActionResult> Index()
        {
            return View(await _context.YLineTranslations.ToListAsync());
        }

        // GET: YLineTranslations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yLineTranslation = await _context.YLineTranslations
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (yLineTranslation == null)
            {
                return NotFound();
            }

            return View(yLineTranslation);
        }

        // GET: YLineTranslations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YLineTranslations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,ProjectID,ProjectStatus,NDB_Yline_ProdCd,NDB_Yline_IPA,NDB_Yline_MktNum,DataLoadDate,LastEditDate,LastEditMSID,PreAward")] YLineTranslation yLineTranslation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yLineTranslation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yLineTranslation);
        }

        // GET: YLineTranslations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yLineTranslation = await _context.YLineTranslations.FindAsync(id);
            if (yLineTranslation == null)
            {
                return NotFound();
            }
            return View(yLineTranslation);
        }

        // POST: YLineTranslations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,ProjectID,ProjectStatus,NDB_Yline_ProdCd,NDB_Yline_IPA,NDB_Yline_MktNum,DataLoadDate,LastEditDate,LastEditMSID,PreAward")] YLineTranslation yLineTranslation)
        {
            if (id != yLineTranslation.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yLineTranslation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YLineTranslationExists(yLineTranslation.RecordID))
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
            return View(yLineTranslation);
        }

        // GET: YLineTranslations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yLineTranslation = await _context.YLineTranslations
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (yLineTranslation == null)
            {
                return NotFound();
            }

            return View(yLineTranslation);
        }

        // POST: YLineTranslations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yLineTranslation = await _context.YLineTranslations.FindAsync(id);
            if (yLineTranslation != null)
            {
                _context.YLineTranslations.Remove(yLineTranslation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YLineTranslationExists(int id)
        {
            return _context.YLineTranslations.Any(e => e.RecordID == id);
        }
    }
}
