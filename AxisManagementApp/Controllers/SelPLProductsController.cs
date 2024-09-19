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
    public class SelPLProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SelPLProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SelPLProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SelPLProducts.ToListAsync());
        }

        // GET: SelPLProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selPLProduct = await _context.SelPLProducts
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (selPLProduct == null)
            {
                return NotFound();
            }

            return View(selPLProduct);
        }

        // GET: SelPLProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SelPLProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,ProjectID,ProjectStatus,NWNW_ID,NWPR_PFX,GRGR_ID,GRGR_NAME,LastEditMSID,DataLoadDate")] SelPLProduct selPLProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selPLProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(selPLProduct);
        }

        // GET: SelPLProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selPLProduct = await _context.SelPLProducts.FindAsync(id);
            if (selPLProduct == null)
            {
                return NotFound();
            }
            return View(selPLProduct);
        }

        // POST: SelPLProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,ProjectID,ProjectStatus,NWNW_ID,NWPR_PFX,GRGR_ID,GRGR_NAME,LastEditMSID,DataLoadDate")] SelPLProduct selPLProduct)
        {
            if (id != selPLProduct.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selPLProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelPLProductExists(selPLProduct.RecordID))
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
            return View(selPLProduct);
        }

        // GET: SelPLProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selPLProduct = await _context.SelPLProducts
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (selPLProduct == null)
            {
                return NotFound();
            }

            return View(selPLProduct);
        }

        // POST: SelPLProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var selPLProduct = await _context.SelPLProducts.FindAsync(id);
            if (selPLProduct != null)
            {
                _context.SelPLProducts.Remove(selPLProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelPLProductExists(int id)
        {
            return _context.SelPLProducts.Any(e => e.RecordID == id);
        }
    }
}
