using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using CourseProject.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CourseProject.Controllers
{
	public class UserController : Controller
	{
		private readonly CRUDContext crudContext;

		public UserController(CRUDContext crudContext)
		{
			this.crudContext = crudContext;
		}

		public IActionResult UserAccount()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UserAccounts()
		{
			// Отримати ідентифікатор поточного користувача
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			// Отримати замовлення тільки для поточного користувача
			var appointments = await crudContext.Appointements
				.Where(a => a.UserId == userId)  // Додайте поле UserId у модель Appointement
				.ToListAsync();

			return View(appointments);
		}
	}
}
