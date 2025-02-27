using AutoFixture;
using HumanResource_Microservice.Controllers;
using HumanResource_Microservice.Models.Outgoing;
using HumanResource_Microservice.Persistence;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace HumanResource_Microservice_UnitTest
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo = new();
        private readonly EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _controller = new EmployeeController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetEmployeeById_WhenCalledAndEntryExists_ReturnsOkResult()
        {
            // Arrange
            var fixture = new Fixture();
            var employeeId = fixture.Create<int>();
            _mockRepo
                .Setup(repo => repo.GetEmployeeById(employeeId))
                .ReturnsAsync(fixture.Create<FoundEmployeeDto>());
            // Act
            var result = await _controller.GetEmployeeById(employeeId);
            // Assert
            result.ShouldBeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetEmployeeById_WhenCalledAndNoEntryExists_ReturnsNotFound()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var controller = new EmployeeController(mockRepo.Object);
            var fixture = new Fixture();
            var employeeId = fixture.Create<int>();
            // Act
            var result = await controller.GetEmployeeById(employeeId);
            // Assert
            result.ShouldBeOfType<NotFoundResult>();
        }
    }
}
