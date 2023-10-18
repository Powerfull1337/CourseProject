﻿using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using CourseProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

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
                    LastName = appointment.LastName,
                    Email = appointment.Email,
                    Phone = appointment.Phone,
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
                appointment.FirstName = model.LastName;
                appointment.Email = model.Email;
                appointment.Phone= model.Phone;
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
    }
}