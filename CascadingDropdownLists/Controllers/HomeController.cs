using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CascadingDropdownLists.Models;
using CascadingDropdownLists.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CascadingDropdownLists.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public IActionResult Index()
    {
        HomeViewModel vm = new()
        {
            CourseLevelList = _db.CourseLevels.ToList().Select(x => new SelectListItem { Text = x.LevelName, Value = x.Id.ToString() })
        };
        
        return View(vm);
    }

    [HttpGet("/lessons/{levelId}")]
    public JsonResult GetLessonsByLevelId(int levelId)
    {
        var result = _db.Lessons.Where(x => x.CourseLevelId == levelId).ToList();
        return Json(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
