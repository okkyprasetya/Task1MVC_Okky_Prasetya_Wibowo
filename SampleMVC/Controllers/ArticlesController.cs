using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BO;

namespace SampleMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleBLL _articleBLL;
        private readonly ICategoryBLL _categoryBLL;
        
        public ArticlesController(IArticleBLL articleBLL,ICategoryBLL categoryBLL)
        {
            _articleBLL = articleBLL;
            _categoryBLL = categoryBLL;
        }

        public IActionResult Index(int? categoryId)
        {
            IEnumerable<ArticleDTO> articles;

            //var models = _articleBLL.GetAll();
            //var categories = _categoryBLL.GetAll();
            //ViewBag.Categories = categories;

            //return View(models);
            if (!categoryId.HasValue || categoryId == 0)
            {
                articles = _articleBLL.GetAll();
            }
            else
            {
                // Fetch articles filtered by categoryId
                articles = _articleBLL.GetArticleWithCategory(categoryId.Value);
            }

            // Fetch all categories to populate the dropdown
            var categories = _categoryBLL.GetAll();
            ViewBag.Categories = categories;



            return View(articles);
        }

        public IActionResult Create() {
            var dropdown = _categoryBLL.GetAll();
            return View(dropdown);
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateDTO article)
        {
            Convert.ToInt32(article.CategoryID);
            _articleBLL.Insert(article);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            _articleBLL.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) { 

            var dataByID = _articleBLL.GetById(id);
            return View(dataByID);
        }

        [HttpPost]
        public IActionResult Update(ArticleUpdateDTO article)
        {

            _articleBLL.Update(article);
            return RedirectToAction("Index");
        }
    }
}
