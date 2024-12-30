using Lab3.DBContext;
using Microsoft.AspNetCore.Identity;
using Lab3.Models;

namespace Lab3
{
	public class DBInitializer
	{
		public static async Task InitializeAsync(AccountDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			// Создание роли Moderator
			if (await roleManager.FindByNameAsync("Moderator") == null)
			{
				await roleManager.CreateAsync(new IdentityRole("Moderator"));
				dbContext.SaveChanges();
			}

			// Создание роли Journalist
			if (await roleManager.FindByNameAsync("Journalist") == null)
			{
				await roleManager.CreateAsync(new IdentityRole("Journalist"));
				dbContext.SaveChanges();
			}

			// Создание роли User
			if (await roleManager.FindByNameAsync("User") == null)
			{
				await roleManager.CreateAsync(new IdentityRole("User"));
				dbContext.SaveChanges();
			}

			// Создание пользователя Moderator
			string moderatorNick = "moderator";
			string passwordModerator = "moderator";
			string lastNameModerator = "ModeratorLastName";
			if (await userManager.FindByNameAsync(moderatorNick) == null)
			{
				User moderator = new User
				{
					LastName = lastNameModerator,
					UserName = moderatorNick,
					Address = "City"
				};
				IdentityResult result = await userManager.CreateAsync(moderator, passwordModerator);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(moderator, "Moderator");
					dbContext.SaveChanges();
				}
			}

			// Создание пользователя Journalist
			string journalistNick = "journalist";
			string passwordJournalist = "journalist";
			string lastNameJournalist = "JournalistLastName";
			if (await userManager.FindByNameAsync(journalistNick) == null)
			{
				User journalist = new User
				{
					LastName = lastNameJournalist,
					UserName = journalistNick,
					Address = "City"
				};
				IdentityResult result = await userManager.CreateAsync(journalist, passwordJournalist);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(journalist, "Journalist");
					dbContext.SaveChanges();
				}
			}

			// Создание пользователя User (по умолчанию, если нужно)
			string userNick = "user";
			string passwordUser = "user";
			string lastNameUser = "UserLastName";
			if (await userManager.FindByNameAsync(userNick) == null)
			{
				User user = new User
				{
					LastName = lastNameUser,
					UserName = userNick,
					Address = "City"
				};
				IdentityResult result = await userManager.CreateAsync(user, passwordUser);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "User");
					dbContext.SaveChanges();
				}
			}
		}
	}
}
