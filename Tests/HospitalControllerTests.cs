using EtulasAPI.Interfaces;
using EtulasAPI.Models;
using HospitalOvercrowdingAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace EtulasAPI.Tests
{
    public class HospitalControllerTests
    {
        private readonly Mock<IHospitalService> _hospitalServiceMock;
        private readonly HospitalController _controller;

        public HospitalControllerTests()
        {
            _hospitalServiceMock = new Mock<IHospitalService>();
            _controller = new HospitalController(_hospitalServiceMock.Object);
        }

        [Fact]
        public async Task GetHospital_ReturnsNotFound_WhenHospitalDoesNotExist()
        {
            // Arrange
            int hospitalId = 1;
            _hospitalServiceMock.Setup(s => s.GetHospitalByIdAsync(hospitalId)).ReturnsAsync((Hospital)null);

            // Act
            var result = await _controller.GetHospital(hospitalId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetHospital_ReturnsOk_WhenHospitalExists()
        {
            // Arrange
            int hospitalId = 1;
            var hospital = new Hospital { Id = hospitalId, Name = "Test Hospital", Capacity = 100, OccupiedBeds = 50 };
            _hospitalServiceMock.Setup(s => s.GetHospitalByIdAsync(hospitalId)).ReturnsAsync(hospital);

            // Act
            var result = await _controller.GetHospital(hospitalId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedHospital = Assert.IsType<Hospital>(okResult.Value);
            Assert.Equal(hospitalId, returnedHospital.Id);
        }
    }
}
