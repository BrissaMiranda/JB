using Microsoft.AspNetCore.Mvc;
using app_to_do_mysql.Models;
using app_to_do_mysql.Services;

namespace app_to_do_mysql.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly DogWcfClientService _dogService;

        public AccountController(AuthService authService, DogWcfClientService dogService)
        {
            _authService = authService;
            _dogService = dogService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool valido = _authService.ValidarUsuario(
                model.Usuario ?? "",
                model.Password ?? "");

            if (valido)
                return RedirectToAction("Welcome");

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Welcome()
        {
            var dogModel = await _dogService.ObtenerPerritoDelDia();
            return View(dogModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}