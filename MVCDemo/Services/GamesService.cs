using Microsoft.EntityFrameworkCore;
using MVCDemo.Data;
using MVCDemo.Models;
using MVCDemo.Settings;
using MVCDemo.ViewModel;

namespace MVCDemo.Services
{
    public class GamesService : IGamesService
    {
        private readonly DemoDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _ImagePath;

        public GamesService(DemoDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _ImagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagePath}";
        }
        public IEnumerable<Games> GetAll()
        {
            return _context.Games
                .AsNoTracking()
                .ToList();
        }
        public async Task Create(CreateGameFormViewModel model)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_ImagePath , CoverName);

            using var stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);            
            Games game = new() 
            {
                Name = model.Name,
                Description = model.Description,
                CategoryID = model.CategoryID,
                Cover  = CoverName,
                Devices = model.SelectedDevices.Select(d => new GameDevice {DeviceId = d }).ToList()
            };
            _context.Add(game);
            _context.SaveChanges();
        }

       
    }
}
