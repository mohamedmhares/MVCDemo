using MVCDemo.Models;
using MVCDemo.ViewModel;

namespace MVCDemo.Services
{
    public interface IGamesService
    {
        IEnumerable<Games> GetAll();
        Task Create(CreateGameFormViewModel model);
    }
}
