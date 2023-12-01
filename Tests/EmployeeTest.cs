using CourseProject.Controllers;
using CourseProject.Data;
using CourseProject.Models.Domain;
using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class EmployeeTest
    {
        [Fact]
        public async Task View_ReturnsViewModelForEmployee()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CRUDContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var crudContext = new CRUDContext(options); 
            var controller = new EmployeesController(crudContext);

            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Email = "johndoe@email.com",
                Salary = 100000,
                Department = "Engineering",
                DateOfBirth = new DateTime(1980, 1, 1),
                Image = null,
                Description = null
            };

            await crudContext.Employees.AddAsync(employee);
            await crudContext.SaveChangesAsync();

            // Act
            var result = await controller.View(employee.Id);

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<UpdateEmployeeViewModel>(viewResult.Model);
            Assert.Equal(employee.Id, viewModel.Id);
            Assert.Equal(employee.Name, viewModel.Name);
            Assert.Equal(employee.Email, viewModel.Email);
            Assert.Equal(employee.Salary, viewModel.Salary);
            Assert.Equal(employee.Department, viewModel.Department);
            Assert.Equal(employee.DateOfBirth, viewModel.DateOfBirth);
        }
    }
}