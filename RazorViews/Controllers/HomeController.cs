using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RazorViews.Models;

namespace RazorViews.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Greeting"] = "Hello World";
        ViewData["Product"] = new ProductModel()
        {
            ProductID = 1,
            Name = "Samsung galaxy Note",
            Brand = "Samsung",
            Price = 19000
        };
        return View();
    }

    //usando ViewBag
    /* 
    public IActionResult SomeAction()
    {
        ViewBag.Greeting = "Hello";
        ViewBag.Product = new ProductModel()
        {
            ProductID = 1,
            Name = "Samsung galaxy Note",
            Brand = "Samsung",
            Price = 19000
        };
 
        return View();
    }
     */
}
