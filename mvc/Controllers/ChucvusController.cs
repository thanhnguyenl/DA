﻿using System;
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
    public class ChucvusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChucvusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chucvus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chucvu.ToListAsync());
        }

        // GET: Chucvus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucvu = await _context.Chucvu
                .FirstOrDefaultAsync(m => m.MaCv == id);
            if (chucvu == null)
            {
                return NotFound();
            }

            return View(chucvu);
        }

        // GET: Chucvus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chucvus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCv,Ten,HeSo")] Chucvu chucvu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chucvu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chucvu);
        }

        // GET: Chucvus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucvu = await _context.Chucvu.FindAsync(id);
            if (chucvu == null)
            {
                return NotFound();
            }
            return View(chucvu);
        }

        // POST: Chucvus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCv,Ten,HeSo")] Chucvu chucvu)
        {
            if (id != chucvu.MaCv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chucvu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChucvuExists(chucvu.MaCv))
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
            return View(chucvu);
        }

        // GET: Chucvus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucvu = await _context.Chucvu
                .FirstOrDefaultAsync(m => m.MaCv == id);
            if (chucvu == null)
            {
                return NotFound();
            }

            return View(chucvu);
        }

        // POST: Chucvus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chucvu = await _context.Chucvu.FindAsync(id);
            _context.Chucvu.Remove(chucvu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChucvuExists(int id)
        {
            return _context.Chucvu.Any(e => e.MaCv == id);
        }

        public async Task<IActionResult> ChucvusByKeyWord(string keyword)
        {
            // lấy ds sp thuộc hãng
            var Chucvus = _context.Chucvu.Where(p => p.Ten.Contains(keyword));
            // chuyển qua view
            return View(await Chucvus.ToListAsync());
        }
    }
}
