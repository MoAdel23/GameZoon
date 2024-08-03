using GameZone.Entities.Models;
using GameZone.Entities.ViewModels;

namespace GameZone.Entities.Interfaces;

public interface IGameService
{
    
    Task<IEnumerable<Game>> GetAllAsync();

    Task<Game?> GetByIdAsync(int id);

    Task<Game?> CreateAsync(CreateGameFormViewModel model);
    Task<Game?> UpdateAsync(EditGameFormViewModel model);

    Task<bool> DeleteAsync(int id);

    IEnumerable<SelectListItem> GetCategoryListItems();
    IEnumerable<SelectListItem> GetDeviceListItems();

}
