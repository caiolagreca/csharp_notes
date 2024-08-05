using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DI.Models;
using DI.Services;

namespace DI.Controllers;

public class HomeController : Controller
{

    ITransientService _transient;
    IScopedService _scoped;
    ISingletonService _singleton;

    public HomeController(ITransientService transient, IScopedService scoped, ISingletonService singleton)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
    }

    public IActionResult Index()
    {
        @ViewBag.message1 = "Transient: " + _transient.GetId().ToString();
        @ViewBag.message2 = "Scoped: " + _scoped.GetId().ToString();
        @ViewBag.message3 = "Singleton: " + _singleton.GetId().ToString();
        return View();
    }


}
