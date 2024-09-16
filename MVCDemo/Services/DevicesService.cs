using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Data;

namespace MVCDemo.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly DemoDbContext _context;

        public DevicesService(DemoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Devices.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).
                        OrderBy(d => d.Text).AsNoTracking().ToList(); 
        }
    }
}
