using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda.Models.Modelos;

namespace Tienda.Controllers
{
    public class ErrorController : Controller
    {
        private readonly masterContext _context;

        public ErrorController(masterContext context)
        {
            _context = context;
        }

        // GET: Error
        public async Task<IActionResult> Index()
        {
            return View(await _context.Errores.ToListAsync());
        }

        // GET: Error/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var errore = await _context.Errores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (errore == null)
            {
                return NotFound();
            }

            return View(errore);
        }

        // GET: Error/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Error/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Mensaje,Codigo")] Error errore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(errore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(errore);
        }

        // GET: Error/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var errore = await _context.Errores.FindAsync(id);
            if (errore == null)
            {
                return NotFound();
            }
            return View(errore);
        }





        private bool ErroreExists(int id)
        {
            return _context.Errores.Any(e => e.Id == id);
        }
    }
}
