using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using SampleMVC.Models;

namespace SampleMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryBLL _categoryBLL;
    public CategoriesController(ICategoryBLL categoryBLL)
    {
        _categoryBLL = categoryBLL;
    }

    public IActionResult Index()
    {
        var models = _categoryBLL.GetAll();
        return View(models);
    }

    public IActionResult Detail(int id)
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CategoryCreateDTO category)
    {
        _categoryBLL.Insert(category);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var dtoModel = _categoryBLL.GetById(id);
        var viewModel = new SampleMVC.Models.Category
        {
            // Map properties from DTO to ViewModel here
            CategoryID = dtoModel.CategoryID,
            CategoryName = dtoModel.CategoryName,
            // Other properties...
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(CategoryUpdateDTO category)
    {
        _categoryBLL.Update(category);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Search(string search)
    {
        
        var dtoModel = _categoryBLL.GetByName(search);
        return View("Index",dtoModel);

    }

    public IActionResult Delete(int id)
    {

        _categoryBLL.Delete(id);
        return RedirectToAction("Index");
    }


}