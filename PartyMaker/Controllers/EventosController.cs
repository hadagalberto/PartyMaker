using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyMaker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using PartyMaker.Data;
using PartyMaker.Helpers;

namespace PartyMaker.Controllers
{
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public EventosController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
            _context.Database.Migrate();
        }

        // GET: Eventos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            TempData.Keep();
            var user = await GetUser();
            return View(await _context.Eventos.Where(x => x.Usuario == user).ToListAsync());
        }

        private async Task<IdentityUser> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);
            return user;
        }

        // GET: Eventoes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.IdEvento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventoes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Nome,Local,DataEvento")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                evento.Usuario = await GetUser();
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Eventoes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Local,DataEvento")] Evento evento)
        {
            if (id != evento.IdEvento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (evento.Usuario != await GetUser())
                    {
                        return NotFound();
                    }
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.IdEvento))
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
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.IdEvento == id);
            if (evento == null)
            {
                return NotFound();
            }
            if (evento.Usuario != await GetUser())
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento.Usuario != await GetUser())
            {
                return NotFound();
            }
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Eventos/EnviarEmails/5
        [Authorize]
        public async Task<IActionResult> EnviarEmails(int id)
        {
            if (EventoExists(id))
            {
                var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.IdEvento == id);
                var participantes = _context.Participantes.Where(x => x.Evento == evento).ToList();
                if (participantes.Any())
                {
                    foreach (var participante in participantes)
                    {
                        try
                        {
                            _emailSender.SendEmailAsync(participante.Email, "Notificação: " + evento.Nome, EmailsHelper.EmailNotificacao(evento.Nome, participante.Nome, evento.DataEvento.ToString("dd/MM/yyyy 'às' HH:mm"), "http://www.partymaker.com"));
                        }
                        catch (Exception ex)
                        {
                            TempData["MensagemErro"] = ex.Message;
                        }
                    }
                    TempData["MensagemSucesso"] = $"{participantes.Count} e-mails enviados";
                }
                else
                {
                    TempData["MensagemAtencao"] = "Não existe nenhum participante nesse evento";
                }
            }
            else
            {
                TempData["MensagemErro"] = "Evento inexistente";
            }
            TempData.Keep();
            return RedirectToAction("Index", id);
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.IdEvento == id);
        }

    }
}
