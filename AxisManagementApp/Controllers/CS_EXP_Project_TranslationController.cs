using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AxisManagementApp.Models;
using AxisManagementApp.ViewModels;

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

        // GET: CS_EXP_Project_Translation/Create
        public IActionResult Create()
        {
            return View(new NewProjectViewModel());
        }

        // POST: CS_EXP_Project_Translation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var projectTranslation = new CSEXPProjectTranslation
                {
                    ProjectID = viewModel.ProjectID,
                    Analyst = viewModel.Analyst,
                    State = viewModel.State,
                    ProjectDesc = viewModel.ProjectDesc,
                    Product = viewModel.Product,
                    PM = viewModel.PM,
                    Iteration = viewModel.Iteration,
                    GoLiveDate = viewModel.GoLiveDate,
                    MaxMileage = viewModel.MaxMileage,
                    IsLimitedExpansionProject = viewModel.IsLimitedExpansionProject,
                    ProjectType = viewModel.IsLimitedExpansionProject ? "L" : "F",
                    Status = "New",
                    DataLoadDate = DateTime.Now,
                    LastEditDate = DateTime.Now,
                    LastEditMSID = User.Identity.Name // Assuming you have user authentication
                };

                _context.Add(projectTranslation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: CS_EXP_Project_Translation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTranslation = await _context.ProjectTranslations.FindAsync(id);
            if (projectTranslation == null)
            {
                return NotFound();
            }

            var viewModel = new NewProjectViewModel
            {
                ProjectID = projectTranslation.ProjectID,
                Analyst = projectTranslation.Analyst,
                State = projectTranslation.State,
                ProjectDesc = projectTranslation.ProjectDesc,
                Product = projectTranslation.Product,
                PM = projectTranslation.PM,
                Iteration = projectTranslation.Iteration,
                GoLiveDate = projectTranslation.GoLiveDate,
                MaxMileage = projectTranslation.MaxMileage,
                IsLimitedExpansionProject = projectTranslation.IsLimitedExpansionProject
            };

            return View(viewModel);
        }

        // POST: CS_EXP_Project_Translation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewProjectViewModel viewModel)
        {
            var projectTranslation = await _context.ProjectTranslations.FindAsync(id);
            if (projectTranslation == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                projectTranslation.ProjectID = viewModel.ProjectID;
                projectTranslation.Analyst = viewModel.Analyst;
                projectTranslation.State = viewModel.State;
                projectTranslation.ProjectDesc = viewModel.ProjectDesc;
                projectTranslation.Product = viewModel.Product;
                projectTranslation.PM = viewModel.PM;
                projectTranslation.Iteration = viewModel.Iteration;
                projectTranslation.GoLiveDate = viewModel.GoLiveDate;
                projectTranslation.MaxMileage = viewModel.MaxMileage;
                projectTranslation.IsLimitedExpansionProject = viewModel.IsLimitedExpansionProject;
                projectTranslation.ProjectType = viewModel.IsLimitedExpansionProject ? "L" : "F";
                projectTranslation.LastEditDate = DateTime.Now;
                projectTranslation.LastEditMSID = User.Identity.Name;

                try
                {
                    _context.Update(projectTranslation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CSEXPProjectTranslationExists(projectTranslation.RecordID))
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
            return View(viewModel);
        }

        // GET: CS_EXP_Project_Translation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTranslation = await _context.ProjectTranslations
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (projectTranslation == null)
            {
                return NotFound();
            }

            return View(projectTranslation);
        }

        // POST: CS_EXP_Project_Translation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectTranslation = await _context.ProjectTranslations.FindAsync(id);
            _context.ProjectTranslations.Remove(projectTranslation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CSEXPProjectTranslationExists(int id)
        {
            return _context.ProjectTranslations.Any(e => e.RecordID == id);
        }
    }
}