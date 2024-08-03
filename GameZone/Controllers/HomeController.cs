
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers;

public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _unitOfWork.Game.GetAllAsync(includes: new[] { nameof(Category), $"{nameof(Game.Devices)}.{nameof(Device)}" }));
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
