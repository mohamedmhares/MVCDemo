using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCDemo.Services
{

    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
