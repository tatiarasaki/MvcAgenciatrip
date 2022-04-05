using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcAgenciatrip.Data;
using MvcAgenciatrip.Models;

namespace MvcAgenciatrip.Controllers
{
    public class PromocaosController : Controller
    {
        private readonly MvcAgenciatripContext _context;

        public PromocaosController(MvcAgenciatripContext context)
        {
            _context = context;
        }

        // GET: Promocaos
        public async Task<IActionResult> Index()
        {
            var mvcAgenciatripContext = _context.Promocao.Include(p => p.Destino);
            return View(await mvcAgenciatripContext.ToListAsync());
        }

        // GET: Promocaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao
                .Include(p => p.Destino)
                .FirstOrDefaultAsync(m => m.PromocaoId == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // GET: Promocaos/Create
        public IActionResult Create()
        {
            ViewData["DestinoId"] = new SelectList(_context.Destino, "DestinoId", "DestinoId");
            return View();
        }

        // POST: Promocaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromocaoId,DestinoId,Desconto")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoId"] = new SelectList(_context.Destino, "DestinoId", "DestinoId", promocao.DestinoId);
            return View(promocao);
        }

        // GET: Promocaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao.FindAsync(id);
            if (promocao == null)
            {
                return NotFound();
            }
            ViewData["DestinoId"] = new SelectList(_context.Destino, "DestinoId", "DestinoId", promocao.DestinoId);
            return View(promocao);
        }

        // POST: Promocaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromocaoId,DestinoId,Desconto")] Promocao promocao)
        {
            if (id != promocao.PromocaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocaoExists(promocao.PromocaoId))
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
            ViewData["DestinoId"] = new SelectList(_context.Destino, "DestinoId", "DestinoId", promocao.DestinoId);
            return View(promocao);
        }

        // GET: Promocaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocao
                .Include(p => p.Destino)
                .FirstOrDefaultAsync(m => m.PromocaoId == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // POST: Promocaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocao = await _context.Promocao.FindAsync(id);
            _context.Promocao.Remove(promocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocaoExists(int id)
        {
            return _context.Promocao.Any(e => e.PromocaoId == id);
        }
    }
}
