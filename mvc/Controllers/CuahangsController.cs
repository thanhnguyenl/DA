using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class CuahangsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuahangsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cuahangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuahang.ToListAsync());
        }

        // GET: Cuahangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuahang = await _context.Cuahang
                .FirstOrDefaultAsync(m => m.MaCh == id);
            if (cuahang == null)
            {
                return NotFound();
            }

            return View(cuahang);
        }

        // GET: Cuahangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuahangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCh,Ten,DienThoai,DiaChi")] Cuahang cuahang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuahang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuahang);
        }

        // GET: Cuahangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuahang = await _context.Cuahang.FindAsync(id);
            if (cuahang == null)
            {
                return NotFound();
            }
            return View(cuahang);
        }

        // POST: Cuahangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCh,Ten,DienThoai,DiaChi")] Cuahang cuahang)
        {
            if (id != cuahang.MaCh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuahang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuahangExists(cuahang.MaCh))
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
            return View(cuahang);
        }

        // GET: Cuahangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuahang = await _context.Cuahang
                .FirstOrDefaultAsync(m => m.MaCh == id);
            if (cuahang == null)
            {
                return NotFound();
            }

            return View(cuahang);
        }

        // POST: Cuahangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuahang = await _context.Cuahang.FindAsync(id);
            _context.Cuahang.Remove(cuahang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuahangExists(int id)
        {
            return _context.Cuahang.Any(e => e.MaCh == id);
        }
        public async Task<IActionResult> CuahangsByKeyWord(string keyword)
        {
            // lấy ds sp thuộc hãng
            var Cuahangs = _context.Cuahang.Where(p => p.Ten.Contains(keyword));
            // chuyển qua view
            return View(await Cuahangs.ToListAsync());
        }
    }
}
