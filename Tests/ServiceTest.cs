using CourseProject.Controllers;
using CourseProject.Data;
using CourseProject.Models;
using CourseProject.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace Tests
{
    public class ServiceTest
    {
        [Fact]
        public async Task Index_ReturnsViewWithServices()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CRUDContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new CRUDContext(options))
            {
        
                context.Services.Add(new Service {
                 Id = Guid.NewGuid(),
                 Name = "Стрижка",
                 Price = 200,
                 Description = "стрижка голови",
                 Image = "/image/photo"

                });
                context.SaveChanges();
            }

            using (var context = new CRUDContext(options))
            {
                var controller = new HomeController(context);

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Service>>(viewResult.ViewData.Model);
                Assert.NotEmpty(model);
            }
        }
    }
}