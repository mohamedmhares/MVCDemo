using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Data;

namespace MVCDemo.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly DemoDbContext _context;

        public CategoriesService(DemoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Categories.
                    Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                    OrderBy(c => c.Text).AsNoTracking().ToList();
        }
    }
}
