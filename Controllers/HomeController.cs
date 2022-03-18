using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdoDotNet.Models;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace AdoDotNet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;
    private readonly ILifetimeScope _lifetimeScope;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ILifetimeScope lifetimeScope)
    {
        _logger = logger;
        _configuration = configuration;
        _lifetimeScope = lifetimeScope;
    }

    public IActionResult Index()
    {
        var model = _lifetimeScope.Resolve<HomeModel>();
        
        _logger.LogInformation("this is Home page");
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult CreateNew()
    {
        return View();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult AddData(HomeModel model)
    {
        model.InsertData(_configuration.GetConnectionString("DefaultConnection"));
        return RedirectToAction("Index"); 
    }

    public IActionResult ViewData()
    {
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}