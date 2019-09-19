using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIN_WebAPP.Data;
using PIN_WebAPP.Models;
using PIN_WebAPP.Utility;

namespace PIN_WebAPP.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class CaroselsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaroselsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Carosels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carosel.ToListAsync());
        }

        // GET: Admin/Carosels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carosel = await _context.Carosel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carosel == null)
            {
                return NotFound();
            }

            return View(carosel);
        }

        // GET: Admin/Carosels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Carosels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Picture")] Carosel carosel)
        {

                if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p = null;
                    using (var fs = files[0].OpenReadStream())
                    {
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            p = ms.ToArray();
                        }
                    }
                    carosel.Picture = p;
                }

                _context.Add(carosel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carosel);
        }

     

     

        // GET: Admin/Carosels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carosel = await _context.Carosel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carosel == null)
            {
                return NotFound();
            }

            return View(carosel);
        }

        // POST: Admin/Carosels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carosel = await _context.Carosel.FindAsync(id);
            _context.Carosel.Remove(carosel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaroselExists(int id)
        {
            return _context.Carosel.Any(e => e.Id == id);
        }
    }
}
