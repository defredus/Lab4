using NewsPortalBLL.DTO;
using NewsPortalBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class CommentaryController : Controller
    {
        private readonly ICommentaryService _commentaryService;

        public CommentaryController(ICommentaryService commentaryService)
        {
            _commentaryService = commentaryService;
        }

        public IActionResult Index()
        {
            var comments = _commentaryService.GetAll();
            return View(comments);
        }

        public IActionResult Details(int id)
        {
            var comment = _commentaryService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var comment = _commentaryService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment); // Передаем комментарий на страницу для подтверждения удаления
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Выполнение удаления через сервис
                _commentaryService.Delete(id);
                ViewData["SuccessMessage"] = "Comment has been successfully deleted.";

                // Перенаправление на страницу списка комментариев
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "There was an error while deleting the comment.";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var comment = _commentaryService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            // Передаем комментарий на страницу редактирования
            return View(comment);
        }

        [HttpPost]
        public IActionResult Update(int id, string content, int user_id, int article_id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var commentDto = new CommentaryDTO
                    {
                        id = id,
                        content = content,
                        UserId = user_id,
                        ArticleId = article_id
                    };
                    _commentaryService.Update(commentDto);
                    ViewData["SuccessMessage"] = "Comment has been successfully updated.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "There was an error while updating the comment.";
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create(int articleId, int userId)
        {
            return View(new { ArticleId = articleId, UserId = userId });
        }
        [HttpPost]
        public IActionResult Create(int articleId, int userId, string content)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var commentDto = new CommentaryDTO
                    {
                        ArticleId = articleId,
                        UserId = userId,
                        content = content
                    };
                    _commentaryService.Add(commentDto);
                    ViewData["SuccessMessage"] = "Comment has been successfully added.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "There was an error while adding the comment.";
                    return View();
                }
            }
            return View();
        }
    }
}
