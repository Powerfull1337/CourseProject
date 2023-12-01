using CourseProject.Controllers;
using CourseProject.Models.DTO;
using CourseProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class UserTest
    {
        [Fact]
        public async Task Login_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var authServiceMock = new Mock<IUserAuthenticationService>();
            authServiceMock.Setup(x => x.LoginAsync(It.IsAny<LoginModel>()))
                .ReturnsAsync(new Status { StatusCode = 1 });

            var controller = new UserAuthenticationController(authServiceMock.Object);
            var loginModel = new LoginModel { 
            Username = "admin1",
            Password = "admin@12345#"
            };

            // Act
            var result = await controller.Login(loginModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public async Task Login_InvalidModel_ReturnsViewResult()
        {
            // Arrange
            var authServiceMock = new Mock<IUserAuthenticationService>();
            var controller = new UserAuthenticationController(authServiceMock.Object);
            var loginModel = new LoginModel { 
            Username = "admin1",
            Password = "Admin@12345#"
            };
            controller.ModelState.AddModelError("Key", "Error Message");

            // Act
            var result = await controller.Login(loginModel) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(loginModel, result.Model);
        }

    }
}
