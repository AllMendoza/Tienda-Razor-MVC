using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Models.Modelos;

namespace Tienda.Controllers.Admin
{
    public class LoginController : Controller
    {
        private readonly masterContext _context;
        public LoginController(masterContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Indexx()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        // POST: Login/Autenticate/email, pwd
        public IActionResult Autenticate(AuthUser user)
        {
            if (isValidPasswordAsync(user.Email, user.Pwd).Result)
            {

                return RedirectToAction("Index");
                //lblResultado.Text = $"Bienvenido {username} , su password ingresado es correcto";
            }
            else
            {
                return RedirectToAction("Index");
                //lblResultado.Text = $"Usuario y/o password son incorrectos";
            }

            return RedirectToAction("Index");
        }        


        private async Task<bool> isValidPasswordAsync(string email, string password)
        {
            AuthUser user = await searchAsync(email);
            bool isValid = false;

            if (!string.IsNullOrEmpty(user.Email))
            {
                byte[] hashedPassword = Cryptographic.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), user.saltt);

                if (hashedPassword.SequenceEqual(user.Password))
                    isValid = true;
            }

            return isValid;
        }
        private async Task<AuthUser> searchAsync(string email)
        {
            if (email == null) { return null; }

            var authUser = await _context.AuthUsers
                .FirstOrDefaultAsync(m => m.Email == email);

            if (authUser == null) { return null; }

            return authUser;
        }

    }
}
