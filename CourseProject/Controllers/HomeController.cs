using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using CourseProject.Models.Domain;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
		private readonly CRUDContext crudContext;

		public HomeController(CRUDContext crudContext)
		{
			this.crudContext = crudContext;
		}


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
		public IActionResult Barbers()
		{
			return View();
		}
		public IActionResult Services()
		{
			return View();
		}

		public IActionResult Appointment()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddAppointmentViewModel addAppointmentRequest)
		{
			
			if (ModelState.IsValid)
			{
				var appointment = new Appointement()
				{
					Id = Guid.NewGuid(),
					FirstName = addAppointmentRequest.FirstName,
					LastName = addAppointmentRequest.LastName,
					Email = addAppointmentRequest.Email,
					Phone = addAppointmentRequest.Phone,
					DateOfBook = addAppointmentRequest.DateOfBook,
					Description = addAppointmentRequest.Description,
				};
				await crudContext.Appointements.AddAsync(appointment);
				await crudContext.SaveChangesAsync();
				return View("Index");
			}
			else
			{
				return View(addAppointmentRequest); // Повертаємо вид із помилками валідації
			}
		}

	}
}