using MiniBusManagement.Api.Controllers.Administration;
using FakeItEasy;
using MiniBusManagement.Service.Administration;
using Microsoft.Extensions.Options;
using MiniBusManagement.Api;
using MiniBusManagement.Api.Models.Administration;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MiniBusManagement.Domain.Models.Administration;
using Moq;

namespace MiniBusManagement
{
    public class MiniBusTest
    {
        private readonly IMiniBusService _miniBusService;
        private readonly IOptionsMonitor<JwtOptions> _options;
        public MiniBusTest() 
        {
            _miniBusService = A.Fake<IMiniBusService>();
            _options = A.Fake<IOptionsMonitor<JwtOptions>>();
        }

        [Fact]
        public void TestMiniBusControllerGet()
        {
            var minibuses = A.Fake<ICollection<MiniBusDTO>>();
            var miniBusList = A.Fake<List<MiniBusDTO>>();
            var controller = new MiniBusController(_miniBusService, _options);
            var result = controller.GetMiniBuses();
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ActionResult<IEnumerable<MiniBusDTO>>>>();
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task TestMiniBusControllerGetByNameSuccess()
        {
            // var controller = new Mock<IMiniBusService>();
            MiniBus document = new MiniBus()
            {
                Id = 1,
                Brand = "Prueba",
                Tipo = "Van"
            };
            int miniBusId = 1;
            var mockBookService = new Mock<IMiniBusService>();
            mockBookService.Setup(c => c.GetMiniBusByID(document.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document);

            //Act
            var controller = new MiniBusController(mockBookService.Object, _options);
            var result = await controller.GetMiniBus(miniBusId);


            //Assert
            //Return proper HTTPStatus code
            Assert.True(result is ObjectResult || result is StatusCodeResult);
            int statusCode = 0;
            if (result is StatusCodeResult)
            {
                var actualResult = (StatusCodeResult)result;
                statusCode = actualResult.StatusCode;
            }
            if (result is ObjectResult)
            {
                var actualResult = (ObjectResult)result;
                statusCode = actualResult.StatusCode.Value;
            }

            //OR
            Assert.Equal(200, statusCode);
            //Addtional asserts
            // TODO: arreglar warning
            var resultDto = (MiniBusDTO)((ObjectResult)result).Value;
            Assert.Equal(document.Brand, resultDto.Brand);
            Assert.Equal(document.Tipo, resultDto.Tipo);
            Assert.Equal(document.Id, resultDto.Id);

        }

        [Fact]
        public void TestMiniBusControllerGetById() {
            MiniBus document = new MiniBus();
            document.Id = 1;
            // Arrange
            var controller = new MiniBusController(_miniBusService,_options);

            // Act
            var result = controller.GetMiniBus(1);
            Assert.IsType<MiniBusDTO>(result);


            // Assert
            Assert.NotNull(result);
            Assert.IsType<MiniBusDTO>(result);
            //Assert.IsType<OkResult>(result);
            // Add more assertions to validate the expected behavior
        }
    }
}