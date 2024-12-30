using Lab3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Controllers
{
    [Authorize(Roles = "Station Master")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserManagementController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
            var users = userManager.Users.AsNoTracking().ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = registerModel.UserName, LastName = registerModel.LastName, Email = registerModel.Email, Address = registerModel.Address };
                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new RegisterModel
            {
                UserName = user.UserName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, RegisterModel registerModel)
        {
            //if (ModelState.IsValid)
            //{
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.UserName = registerModel.UserName;
            user.LastName = registerModel.LastName;
            user.Email = registerModel.Email;
            user.Address = registerModel.Address;

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            //}
            return View(registerModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
