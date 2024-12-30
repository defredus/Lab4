using NewsPortalBLL.DTO;
using NewsPortalBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var articles = _articleService.GetAll();
            return View("Index", articles);  // Явно указываем имя представления
        }

        public IActionResult Details(int id)
        {
            var article = _articleService.GetById(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // Страница для обновления статьи
        [HttpGet]
        public IActionResult Update(int id)
        {
            var article = _articleService.GetById(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article); // Передаем статью на страницу редактирования
        }

        [HttpPost]
        public IActionResult Update(int id, string title, string content, DateTime publicationDate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var articleDto = new ArticleDTO
                    {
                        Id = id,
                        Title = title,
                        Content = content,
                        PublicationDate = publicationDate
                    };

                    // Выполнение обновления через сервис
                    _articleService.Update(articleDto);
                    ViewData["SuccessMessage"] = "Article has been successfully updated.";

                    // Перенаправление на страницу списка статей
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "There was an error while updating the article.";
                    return View();
                }
            }

            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string content, DateTime publicationDate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var articleDto = new ArticleDTO
                    {
                        Title = title,
                        Content = content,
                        PublicationDate = publicationDate
                    };

                    // Выполнение сохранения через сервис
                    _articleService.Add(articleDto);
                    ViewData["SuccessMessage"] = "Article has been successfully created.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "There was an error while creating the article.";
                    return View();
                }
            }
            return View();
        }
        // Страница подтверждения удаления статьи
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var article = _articleService.GetById(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article); // Передаем статью на страницу для подтверждения удаления
        }
        // Выполнение удаления статьи
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Выполнение удаления через сервис
                _articleService.Delete(id);
                ViewData["SuccessMessage"] = "Article has been successfully deleted.";

                // Перенаправление на страницу списка статей
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "There was an error while deleting the article.";
                return RedirectToAction("Index");
            }
        }

    }
}
