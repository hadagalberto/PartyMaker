using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartyMaker.Data;
using PartyMaker.Models;

namespace PartyMaker.Controllers
{
    public class RecursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recursoes
        public async Task<IActionResult> Index(int Id)
        {
            ViewBag.IdEvento = Id;
            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.IdEvento == Id);
            return View(await _context.Recursos.Where(r => r.Evento == evento).ToListAsync());
        }

        // GET: Recursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos
                .FirstOrDefaultAsync(m => m.IdRecurso == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // GET: Recursoes/Create
        public IActionResult Create(int Id)
        {
            var evento = _context.Eventos.FirstOrDefault(x => x.IdEvento == Id);
            if (evento != null)
            {
                ViewBag.EventoId = Id;
                return View();
            }
            return View();
        }

        // POST: Recursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecurso,NomeRecurso,Quantidade,TipoRecurso")] Recurso recurso, int idEvento)
        {
            if (ModelState.IsValid)
            {
                recurso.Evento = await _context.Eventos.FirstOrDefaultAsync(e => e.IdEvento == idEvento);
                _context.Add(recurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        // GET: Recursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }
            return View(recurso);
        }

        // POST: Recursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecurso,NomeRecurso,Quantidade,TipoRecurso")] Recurso recurso)
        {
            if (id != recurso.IdRecurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecursoExists(recurso.IdRecurso))
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
            return View(recurso);
        }

        // GET: Recursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos
                .FirstOrDefaultAsync(m => m.IdRecurso == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // POST: Recursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recurso = await _context.Recursos.FindAsync(id);
            _context.Recursos.Remove(recurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursoExists(int id)
        {
            return _context.Recursos.Any(e => e.IdRecurso == id);
        }
    }
}
