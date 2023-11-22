using CourseProject.Data;
using CourseProject.Models.Domain;
using CourseProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseProject.Migrations;
using CourseProject.Models;

namespace CourseProject.Controllers
{
    public class ServiceController : Controller
	{
		private readonly CRUDContext crudContext;

		public ServiceController(CRUDContext crudContext)
		{
			this.crudContext = crudContext;
		}


		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var services = await crudContext.Services.ToListAsync();
			return View(services);
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddServiceViewModel addserviceRequest)
		{
			var service = new Service()
			{
				Id = Guid.NewGuid(),
				Name = addserviceRequest.Name,
				Price = addserviceRequest.Price,
				Image = addserviceRequest.Image,
				Description = addserviceRequest.Description,
			};
			await crudContext.Services.AddAsync(service);
			await crudContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> View(Guid id)
		{
			var service = await crudContext.Services.FirstOrDefaultAsync(x => x.Id == id);


			if (service != null)
			{
				var viewmodel = new UpdateServiceViewModel
				{
					Id = service.Id,
					Name = service.Name,
					Price = service.Price,
					Image = service.Image,
					Description = service.Description,
				};
				return await Task.Run(() => View("View", viewmodel));
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> View(UpdateServiceViewModel model)
		{
			var service = await crudContext.Services.FindAsync(model.Id);

			if (service != null)
			{
				service.Name = model.Name;
				service.Price = model.Price;
				service.Image = model.Image;
				service.Description = model.Description;
				await crudContext.SaveChangesAsync();

				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}


		[HttpPost]
		public async Task<IActionResult> Delete(UpdateServiceViewModel model)
		{
			var service = await crudContext.Services.FindAsync(model.Id);

			if (service != null)
			{
				crudContext.Services.Remove(service);
				await crudContext.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}
