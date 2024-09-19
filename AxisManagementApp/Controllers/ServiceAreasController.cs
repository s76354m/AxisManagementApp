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
    public class ServiceAreasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceAreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceAreas.ToListAsync());
        }

        // GET: ServiceAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceArea = await _context.ServiceAreas
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (serviceArea == null)
            {
                return NotFound();
            }

            return View(serviceArea);
        }

        // GET: ServiceAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,ProjectID,Region,State,County,ReportInclude,MaxMileage,DataLoadDate,ProjectStatus")] ServiceArea serviceArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceArea);
        }

        // GET: ServiceAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceArea = await _context.ServiceAreas.FindAsync(id);
            if (serviceArea == null)
            {
                return NotFound();
            }
            return View(serviceArea);
        }

        // POST: ServiceAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,ProjectID,Region,State,County,ReportInclude,MaxMileage,DataLoadDate,ProjectStatus")] ServiceArea serviceArea)
        {
            if (id != serviceArea.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceAreaExists(serviceArea.RecordID))
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
            return View(serviceArea);
        }

        // GET: ServiceAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceArea = await _context.ServiceAreas
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (serviceArea == null)
            {
                return NotFound();
            }

            return View(serviceArea);
        }

        // POST: ServiceAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceArea = await _context.ServiceAreas.FindAsync(id);
            if (serviceArea != null)
            {
                _context.ServiceAreas.Remove(serviceArea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceAreaExists(int id)
        {
            return _context.ServiceAreas.Any(e => e.RecordID == id);
        }
    }
}
