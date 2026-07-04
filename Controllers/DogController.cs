using Microsoft.AspNetCore.Mvc;
using app_to_do_mysql.Services;

namespace app_to_do_mysql.Controllers
{
    public class DogController : Controller
    {
        private readonly DogWcfClientService _dogService;

        public DogController(DogWcfClientService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _dogService.ObtenerPerritoDelDia();
            return View(model);
        }
    }
}
