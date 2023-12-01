using CourseProject.Data;
using Microsoft.AspNetCore.Mvc;
using CourseProject.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using CourseProject.Models.ViewModel;
using CourseProject.Models;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
		private readonly CRUDContext crudContext;

		public HomeController(CRUDContext crudContext)
		{
			this.crudContext = crudContext;
		}


        public async Task<IActionResult> Index()
        {
			var service = await crudContext.Services.ToListAsync();
			return View(service);
		}

        public IActionResult About()
        {
            return View();
        }

		public IActionResult Services()
		{
			return View();
		}

		public async Task<IActionResult> Appointment()
		{
			var addAppointmentModel = new AddAppointmentViewModel(); 
			var service = await crudContext.Services.ToListAsync();

			var viewModel = new AppointmentsViewModel
			{
				AddAppointmentModel = addAppointmentModel,
				Services = service
			};

			return View(viewModel);
		}


		[HttpGet]
		public async Task<IActionResult> Appointments()
		{
			var appointments = await crudContext.Appointements.ToListAsync();
			return View(appointments);
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
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var appointment = new Appointement()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    FirstName = addAppointmentRequest.FirstName,
                    Email = addAppointmentRequest.Email,
                    Phone = addAppointmentRequest.Phone,
                    ServiceName = addAppointmentRequest.ServiceName,
					Price = addAppointmentRequest.Price,
					DateOfBook = addAppointmentRequest.DateOfBook,
					TimeOfBook = addAppointmentRequest.TimeOfBook,
					Description = addAppointmentRequest.Description,
				};

				await crudContext.Appointements.AddAsync(appointment);
				await crudContext.SaveChangesAsync();

				return View("Confirm");
			}
			else
			{
				return View(addAppointmentRequest);
			}
		}

		[HttpGet]
        public async Task<IActionResult> PreviewAppointment(Guid id)
        {
            var appointment = await crudContext.Appointements.FirstOrDefaultAsync(x => x.Id == id);


            if (appointment != null)
            {
                var viewmodel = new UpdateAppointmentViewModel
                {
                    Id = Guid.NewGuid(),
                    FirstName = appointment.FirstName,
					TimeOfBook = appointment.TimeOfBook,
					Email = appointment.Email,
                    Phone = appointment.Phone,
                    ServiceName = appointment.ServiceName,
					Price = appointment.Price,
					DateOfBook = appointment.DateOfBook,
                    Description = appointment.Description,
                };
                return await Task.Run(() => View("PreviewAppointment", viewmodel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> PreviewAppointment(UpdateAppointmentViewModel model)
        {
            var appointment = await crudContext.Appointements.FindAsync(model.Id);

            if (appointment != null)
            {
                appointment.FirstName = model.FirstName;
				appointment.TimeOfBook = model.TimeOfBook;
				appointment.Email = model.Email;
                appointment.Phone= model.Phone;
                appointment.ServiceName = model.ServiceName;
				appointment.Price = model.Price;
				appointment.DateOfBook = model.DateOfBook;
                appointment.Description = model.Description;
                await crudContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateAppointmentViewModel model)
        {
            var appointment = await crudContext.Appointements.FindAsync(model.Id);

            if (appointment != null)
            {
                crudContext.Appointements.Remove(appointment);
                await crudContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Barbers()
        {
            var emploees = await crudContext.Employees.ToListAsync();
            return View(emploees);
        }
    }

}