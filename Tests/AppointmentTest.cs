using CourseProject.Controllers;
using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class AppointmentTest
    {
    
        [Fact]
        public void About_ReturnsAViewResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.About();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
