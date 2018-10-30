using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Churras.Models;
using Microsoft.AspNetCore.Authorization;
using PartyMaker.Data;

namespace PartyMaker.Controllers
{
    public class ParticipantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Participantes
        [Authorize]
        public async Task<IActionResult> Index(int Id)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.IdEvento == Id);
            if (evento != null)
            {
                ViewBag.EventoNome = evento.Nome;
                ViewBag.EventoId = Id;
                var retorno = await _context.Participantes.Where(x => x.Evento == evento).ToListAsync();
                return View(retorno);
            }
            return RedirectToAction("Index", "Eventos");
        }

        // GET: Participantes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes
                .FirstOrDefaultAsync(m => m.IdParticipante == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // GET: Participantes/Create
        [Authorize]
        public IActionResult Create(int Id)
        {
            var evento = _context.Eventos.FirstOrDefault(x => x.IdEvento == Id);
            if (evento != null)
            {
                ViewBag.EventoId = Id;
                return View();
            }
            return RedirectToAction("Index", "Eventos");
        }

        // POST: Participantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("IdParticipante,Email,Nome")] Participante participante, int EventoId)
        {
            if (ModelState.IsValid)
            {
                var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.IdEvento == EventoId);
                participante.Evento = evento;
                participante.HashCode = Guid.NewGuid().ToString();
                _context.Add(participante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participante);
        }

        // GET: Participantes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            return View(participante);
        }

        // POST: Participantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("IdParticipante,Email,Nome")] Participante participante)
        {
            if (id != participante.IdParticipante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipanteExists(participante.IdParticipante))
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
            return View(participante);
        }

        // GET: Participantes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes
                .FirstOrDefaultAsync(m => m.IdParticipante == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

        // POST: Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipanteExists(int id)
        {
            return _context.Participantes.Any(e => e.IdParticipante == id);
        }
    }
}
