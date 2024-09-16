using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCDemo.Services
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetSelectList();

    }
}
