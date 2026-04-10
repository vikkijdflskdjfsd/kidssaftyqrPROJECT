using Microsoft.AspNetCore.Mvc;
using KidsSafetyQR.Data;
using KidsSafetyQR.Models;

public class KidsController : Controller
{
    private readonly AppDbContext _context;

    public KidsController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Add()
    {
        return View(); // 👈 ye important hai
    }

    [HttpPost]
    [HttpPost]
    [HttpPost]
    public IActionResult Add(Kid kid)
    {
        kid.Code = Guid.NewGuid().ToString(); // 👈 UNIQUE CODE
        kid.IsLost = false;

        _context.Kids.Add(kid);
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }
}