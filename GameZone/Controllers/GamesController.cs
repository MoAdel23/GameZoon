
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers;

public class GamesController : Controller
{
    
   
    private readonly IGameService _gameService;
    

    public GamesController(IGameService gameService)
    { 
        _gameService = gameService; 
    }

    public async Task<IActionResult> Index()
    {
        return View(await _gameService.GetAllAsync());
    }




    public async Task<IActionResult> Details(int id)
    {
        var game = await _gameService.GetByIdAsync(id);

        if (game is null)
            return NotFound();


        return View(game);
    }
    

    [HttpGet]
    public  IActionResult Create()
    {

        CreateGameFormViewModel viewModel = new CreateGameFormViewModel
        {
            Categories = _gameService.GetCategoryListItems(),

            Devices = _gameService.GetDeviceListItems()
        };
        
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGameFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _gameService.GetCategoryListItems();
          

            model.Devices = _gameService.GetDeviceListItems();

            return View(model);
        }


        var game =  await _gameService.CreateAsync(model);

        if (game is null)
            return BadRequest();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

        var game = await _gameService.GetByIdAsync(id);

        if (game is null)
            return NotFound();

        EditGameFormViewModel viewModel = new()
        {
            Id = id,
            Name = game.Name,
            Description = game.Description,
            CategoryId = game.CategoryId,
            CurrentCover = game.Cover,
            SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
            Categories = _gameService.GetCategoryListItems(),
            Devices = _gameService.GetDeviceListItems()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditGameFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _gameService.GetCategoryListItems();


            model.Devices = _gameService.GetDeviceListItems();

            return View(model);
        }


        var game = await _gameService.UpdateAsync(model);
        
        if (game is null)
            return BadRequest();


        return RedirectToAction(nameof(Index));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _gameService.DeleteAsync(id);


        return isDeleted ? Ok() : BadRequest();
    }
}
