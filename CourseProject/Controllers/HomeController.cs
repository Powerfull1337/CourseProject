﻿using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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



	}
}