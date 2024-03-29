﻿using Microsoft.AspNetCore.Mvc;
namespace SampleMVC.Controllers;

public class HomeController : Controller
{
    // Home/Index
    public IActionResult Index()
    {
        ViewData["title"] = "Home Page";
        //return Content("Hello ASP.NET Core MVC! This is the Home Controller Index action.");
        return View();
    }

    // Home/About
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return Content("This is the Contact action method...");
    }
}