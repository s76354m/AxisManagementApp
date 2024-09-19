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
    public class ProjectNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectNotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectNotes.ToListAsync());
        }

        // GET: ProjectNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectNote = await _context.ProjectNotes
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (projectNote == null)
            {
                return NotFound();
            }

            return View(projectNote);
        }

        // GET: ProjectNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,ProjectID,Notes,ActionItem,ProjectStatus,DataLoadDate,LastEditDate,OrigNoteMSID,LastEditMSID,ProjectCategory")] ProjectNote projectNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectNote);
        }

        // GET: ProjectNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectNote = await _context.ProjectNotes.FindAsync(id);
            if (projectNote == null)
            {
                return NotFound();
            }
            return View(projectNote);
        }

        // POST: ProjectNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,ProjectID,Notes,ActionItem,ProjectStatus,DataLoadDate,LastEditDate,OrigNoteMSID,LastEditMSID,ProjectCategory")] ProjectNote projectNote)
        {
            if (id != projectNote.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectNoteExists(projectNote.RecordID))
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
            return View(projectNote);
        }

        // GET: ProjectNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectNote = await _context.ProjectNotes
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (projectNote == null)
            {
                return NotFound();
            }

            return View(projectNote);
        }

        // POST: ProjectNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectNote = await _context.ProjectNotes.FindAsync(id);
            if (projectNote != null)
            {
                _context.ProjectNotes.Remove(projectNote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectNoteExists(int id)
        {
            return _context.ProjectNotes.Any(e => e.RecordID == id);
        }
    }
}
