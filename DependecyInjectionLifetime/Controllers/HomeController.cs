using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DependecyInjectionLifetime.Models;

namespace DependecyInjectionLifetime.Controllers;

public class HomeController : Controller
{
    ITransientService _transientService1;
    ITransientService _transientService2;

    IScopedService _scopedService1;
    IScopedService _scopedService2;

    ISingletonService _singletonService1;
    ISingletonService _singletonService2;

    public HomeController(ITransientService transientService1, ITransientService transientService2, IScopedService scopedService1, IScopedService scopedService2, ISingletonService singletonService1, ISingletonService singletonService2)
    {
        _transientService1 = transientService1;
        _transientService2 = transientService2;

        _scopedService1 = scopedService1;
        _scopedService2 = scopedService2;

        _singletonService1 = singletonService1;
        _singletonService2 = singletonService2;

    }

    public IActionResult Index()
    {
        ViewBag.message1 = "transient 1: " + _transientService1.GetID().ToString();
        ViewBag.message2 = "transient 2: " + _transientService2.GetID().ToString();

        ViewBag.message3 = "scoped 1: " + _scopedService1.GetID().ToString();
        ViewBag.message4 = "scoped 2: " + _scopedService2.GetID().ToString();

        ViewBag.message5 = "singleton 1: " + _singletonService1.GetID().ToString();
        ViewBag.message6 = "singleton 2: " + _singletonService2.GetID().ToString();
        return View();
    }
}
