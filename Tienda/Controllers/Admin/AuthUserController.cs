using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda.Models.Modelos;

namespace Tienda.Controllers
{
    public class AuthUserController : Controller
    {
        private readonly masterContext _context;

        public AuthUserController(masterContext context)
        {
            _context = context;
        }

        // GET: AuthUser
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuthUsers.ToListAsync());
        }


        // GET: AuthUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authUser = await _context.AuthUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authUser == null)
            {
                return NotFound();
            }

            return View(authUser);
        }

        // GET: AuthUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUser,Email,Pwd,salt,Password,saltt")] AuthUser authUser)
        {
            authUser.saltt = Cryptographic.GenerateSalt();
            authUser.Password = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(authUser.Pwd), authUser.saltt);
            authUser.Pwd = "";
            if (ModelState.IsValid)
            {
                _context.Add(authUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authUser);
        }

        // GET: AuthUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authUser = await _context.AuthUsers.FindAsync(id);
            if (authUser == null)
            {
                return NotFound();
            }
            return View(authUser);
        }

        // POST: AuthUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,Email,Pwd,salt")] AuthUser authUser)
        {
            if (id != authUser.Id) { return NotFound(); }
            var authUserViejo = await _context.AuthUsers.FindAsync(id);
            authUserViejo.Email = authUser.Email;

            authUserViejo.Password = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(authUser.Pwd), authUserViejo.saltt);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authUserViejo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthUserExists(authUserViejo.Id))
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
            return View(authUserViejo);
        }

        // GET: AuthUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authUser = await _context.AuthUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authUser == null)
            {
                return NotFound();
            }

            return View(authUser);
        }

        // POST: AuthUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authUser = await _context.AuthUsers.FindAsync(id);
            _context.AuthUsers.Remove(authUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool AuthUserExists(int id)
        {
            return _context.AuthUsers.Any(e => e.Id == id);
        }

    }
}
