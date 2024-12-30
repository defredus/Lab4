using Microsoft.AspNetCore.Mvc;
using NewsPortalBLL.DTO;
using NewsPortalBLL.Interfaces;
using NewsPortalBLL.Services;

namespace Lab3.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService userService)
        {
            _authorService = userService;
        }

        // Отображение списка пользователей
        public IActionResult Index()
        {
            var users = _authorService.GetAll();
            return View(users);
        }

        // Детали пользователя
        public IActionResult Details(int id)
        {
            var user = _authorService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string username, string email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userDto = new AuthorDTO
                    {
                        Username = username,
                        Email = email
                    };

                    _authorService.Add(userDto);
                    ViewData["SuccessMessage"] = "User has been successfully created.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "There was an error while creating the user.";
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _authorService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(int id, string username, string email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userDto = new AuthorDTO
                    {
                        Id = id,
                        Username = username,
                        Email = email
                    };

                    _authorService.Update(userDto);
                    ViewData["SuccessMessage"] = "User has been successfully updated.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "There was an error while updating the user.";
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _authorService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _authorService.Delete(id);
                ViewData["SuccessMessage"] = "User has been successfully deleted.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "There was an error while deleting the user.";
            }

            return RedirectToAction("Index");
        }
    }
}
