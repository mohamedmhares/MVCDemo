using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Data;
using MVCDemo.ViewModel;
using MVCDemo.Services;

namespace MVCDemo.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ICategoriesService categoriesService, IDevicesService devicesService, IGamesService gamesService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Create() 
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
            }; ;
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model) {
            model.Categories = _categoriesService.GetSelectList();
            model.Devices = _devicesService.GetSelectList();
            if (!ModelState.IsValid) {
            return View(model);
            }
            //Save To Database 
            //Save Covet to Server 

            await _gamesService.Create(model);
            return RedirectToAction(nameof(Index));    
        }
    }
}
