
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services;

public class GameService : IGameService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;
    private readonly string _imagesPath;

    public GameService(IUnitOfWork unitOfWork ,IFileService fileService , IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _fileService = fileService;
        _imagesPath = $"{webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
    }


    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _unitOfWork.Game.GetAllAsync(includes: new[] { nameof(Category), $"{nameof(Game.Devices)}.{nameof(Device)}" });
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Game.GetByAsync(g => g.Id == id, includes: new[] { nameof(Category), $"{nameof(Game.Devices)}.{nameof(Device)}" });
    }


    public async Task<Game?> CreateAsync(CreateGameFormViewModel model)
    {

        Game game = new Game
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            Cover = await _fileService.SaveFileAsync(model.Cover, _imagesPath),
            Devices = model.SelectedDevices.Select(d => new GameDevivce { DeviceId = d }).ToList()
        };


        await _unitOfWork.Game.AddAsync(game);

        var effectedRows = _unitOfWork.Compelete();

        if (effectedRows > 0)
            return game;
        else
        {
            _fileService.RemoveFile(game.Cover, _imagesPath);
            return null;
        }

        
    }

    public async Task<Game?> UpdateAsync(EditGameFormViewModel model)
    {
        var game = await _unitOfWork.Game.GetByAsync(g => g.Id == model.Id, includes: [ nameof(Game.Devices) ]);

        if (game is null)
            return null;

        var hasNewCover = model.Cover != null;

        game.Name = model.Name;
        game.Description = model.Description;
        game.CategoryId = model.CategoryId;
        game.Devices = model.SelectedDevices.Select(d => new GameDevivce { DeviceId = d }).ToList();

        if (hasNewCover)
        {
            game.Cover = await _fileService.SaveFileAsync(model.Cover!, _imagesPath);
        }

        _unitOfWork.Game.Update(game);
        var effectedRows = _unitOfWork.Compelete();
        if(effectedRows > 0)
        {
            if (hasNewCover)
            {
                // remove old vover
                _fileService.RemoveFile(model.CurrentCover!,_imagesPath);
            }
            return game;
        }
        else
        {
            // Remove updated cover if the update failed
            if (hasNewCover)
            {
                _fileService.RemoveFile(game.Cover, _imagesPath);
            }
            return null;
        }
        
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = false;
        var game = await _unitOfWork.Game.FindByIdAsync(id);

        if (game is null)
            return isDeleted;

        _unitOfWork.Game.Remove(game);

        var effectedRows =  _unitOfWork.Compelete();

        if(effectedRows > 0)
        {
            isDeleted = true;

            _fileService.RemoveFile(game.Cover, _imagesPath);
        }

        return isDeleted;
    }


    public IEnumerable<SelectListItem> GetCategoryListItems()
    {
        return _unitOfWork.Category.GetListItems();

    }

    public IEnumerable<SelectListItem> GetDeviceListItems()
    {
        return _unitOfWork.Device.GetListItems();

    }

    
}
