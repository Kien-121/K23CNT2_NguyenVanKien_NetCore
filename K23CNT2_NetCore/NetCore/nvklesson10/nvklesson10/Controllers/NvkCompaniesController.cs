using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nvklesson10.Models;

namespace nvklesson10.Controllers
{
    public class NvkCompaniesController : Controller
    {
        private readonly NvkK23cnt2lesson10CbContext _context;

        public NvkCompaniesController(NvkK23cnt2lesson10CbContext context)
        {
            _context = context;
        }

        // GET: NvkCompanies
        public async Task<IActionResult> NvkIndex()
        {
            return View(await _context.Companies.ToListAsync());
        }

        // GET: NvkCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: NvkCompanies/Create
        public IActionResult NvkCreate()
        {
            return View();
        }

        // POST: NvkCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkCreate([Bind("CateId,CateName,CateStatus")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: NvkCompanies/Edit/5
        public async Task<IActionResult> NvkEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: NvkCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkEdit(int id, [Bind("CateId,CateName,CateStatus")] Company company)
        {
            if (id != company.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CateId))
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
            return View(company);
        }

        // GET: NvkCompanies/Delete/5
        public async Task<IActionResult> NvkDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: NvkCompanies/Delete/5
        [HttpPost, ActionName("NvkDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CateId == id);
        }
    }
}
