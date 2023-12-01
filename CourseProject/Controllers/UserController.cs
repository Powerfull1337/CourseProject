using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using CourseProject.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CourseProject.Models.ViewModel;

namespace CourseProject.Controllers
{
	public class UserController : Controller
	{
		private readonly CRUDContext crudContext;
        private readonly UserManager<ApplicationUser> userManager;
        public UserController(CRUDContext crudContext, UserManager<ApplicationUser> userManager)
		{
			this.crudContext = crudContext;
            this.userManager = userManager;

        }
        [HttpGet]
        public async Task<IActionResult> UserAccounts(Guid id)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());

            if (user != null)
            {
                var viewModel = new UpdateUserViewModel
                {
                    Id = Guid.Parse(user.Id),
                    Name = user.Name,
                    Email = user.Email,
                    Username = user.UserName,


                };
                return await Task.Run(() => View("UserAccounts", viewModel));
            }

            return RedirectToAction("UserAccounts");
        }
        [HttpPost]
        public async Task<IActionResult> UserAccounts(UpdateUserViewModel model)
        {
            var user = await crudContext.Users.FindAsync(model.Id);

            if (user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                await crudContext.SaveChangesAsync();
                model.Role = "user";
                return RedirectToAction("UserAccounts");
            }
            return RedirectToAction("UserAccounts");
        }
    


        [HttpGet]
		public async Task<IActionResult> UserAppointments()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var appointments = await crudContext.Appointements
				.Where(a => a.UserId == userId)  
				.ToListAsync();

			return View(appointments);
		}
	}
}
