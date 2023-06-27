using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiniBusManagement.Api.Controllers.Administration;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Services.Administration;
using Moq;
using Xunit;

namespace MiniBusManagement.Api.Tests.Administration
{
    public class MiniBusControllerTest
    {
        private readonly Mock<IOptionsMonitor<HaciendaOptions>> _optionsMock;
        private readonly Mock<ILogger<MiniBusController>> _loggerMock;
        private readonly IMapper _mapperMock;
        private readonly Mock<IMiniBusService> _miniBusServiceMock;
        private readonly MiniBusController _miniBusController;

        public MiniBusControllerTest()
        {
            _miniBusServiceMock = new Mock<IMiniBusService>();
            _optionsMock = new Mock<IOptionsMonitor<HaciendaOptions>>();
            _loggerMock = new Mock<ILogger<MiniBusController>>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapperMock = configuration.CreateMapper();
            _miniBusController = new MiniBusController(_miniBusServiceMock.Object, _optionsMock.Object, _loggerMock.Object, _mapperMock);
        }


        [Fact]
        public async Task TestMiniBusControllerGetSucces()
        {

            var company = new Company();
            company.Id = 1;
            company.Name = "Prueba";

            var miniBusList = new List<MiniBus>
            {
                new MiniBus { Id = 1, Company = company, Capacity = 20, Brand = "Toyota" },
                new MiniBus { Id = 2, Company = company, Capacity = 20, Brand = "Isuzu" }
            };

            _miniBusServiceMock.Setup(c => c.GetMinibus("Roberto", It.IsAny<DateTime>())).ReturnsAsync(miniBusList);
            var actionResult = await _miniBusController.GetMiniBuses();
            Assert.NotNull(actionResult);
            var result = actionResult.Result;
            Assert.NotNull(result);
            Assert.True(result is ObjectResult or StatusCodeResult);
            if (result is StatusCodeResult)
            {
                var actualResult = actionResult.Result as StatusCodeResult;
                Assert.NotNull(actualResult);
                Assert.NotEqual(0, actualResult.StatusCode);
                Assert.Equal(200, actualResult.StatusCode);

            }
            if (result is ObjectResult)
            {
                var resulObject = actionResult.Result as ObjectResult;
                Assert.NotNull(resulObject);
                Assert.NotNull(resulObject.StatusCode);
                Assert.Equal(200, resulObject.StatusCode);
                var miniBusListObject = resulObject.Value as List<MiniBus>;
                Assert.Equal(2, miniBusListObject?.Count);

            }

        }

        [Fact]
        public async Task TestMiniBusControllerGetByIdSuccess()
        {
            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var document = new MiniBus
            {
                Id = 1,
                CompanyId = 1,
                Capacity = 20,
                Brand = "Toyota",
            };

            var loggerMock = new Mock<ILogger<MiniBusController>>();
            var logMessages = new List<string>();

            int miniBusId = 1;
            _miniBusServiceMock.Setup(c => c.GetMiniBusByID(It.IsAny<int>(), "Roberto", It.IsAny<DateTime>())).ReturnsAsync(new MiniBus
            {
                Id=1, CompanyId=1, Capacity=20,Brand="pruba"
            });
            var actionResult = await _miniBusController.GetMiniBus(miniBusId);
            Assert.NotNull(actionResult);
            Assert.True(actionResult is ObjectResult || actionResult is StatusCodeResult);
            if (actionResult is StatusCodeResult)
            {
                var actualResult = actionResult as StatusCodeResult;
                Assert.NotNull(actualResult);
                Assert.NotEqual(0, actualResult.StatusCode);
                Assert.Equal(200, actualResult.StatusCode);
            }
            if (actionResult is ObjectResult)
            {
                var resulObject = actionResult as ObjectResult;
                Assert.NotNull(resulObject);
                Assert.NotNull(resulObject.StatusCode);
                Assert.Equal(200, resulObject.StatusCode);
                var miniObject = resulObject.Value as MiniBusDTO;
                Assert.NotNull(miniObject);
                Assert.Equal(1, miniObject.Id);

            }
            Console.WriteLine("pruebas 01 ");
            foreach (var logMessage in logMessages)
            {
                Console.WriteLine(logMessage);
            }

        }
        [Fact]
        public async Task TestMiniBusControllerGetByIdNotFound()
        {

            var document = new Mock<MiniBus>();
            int miniBusId = 1;
            _miniBusServiceMock.Setup(c => c.GetMiniBusByID(miniBusId, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document.Object);
            var actionResult = await _miniBusController.GetMiniBus(miniBusId);
            Assert.NotNull(actionResult);
            Assert.True(actionResult is ObjectResult || actionResult is StatusCodeResult);
            if (actionResult is StatusCodeResult)
            {
                var actualResult = actionResult as StatusCodeResult;
                Assert.NotNull(actualResult);
                Assert.NotEqual(0, actualResult.StatusCode);
                Assert.Equal(404, actualResult.StatusCode);
            }
            if (actionResult is ObjectResult)
            {
                var resulObject = actionResult as ObjectResult;
                Assert.NotNull(resulObject);
                Assert.NotNull(resulObject.StatusCode);
                Assert.Equal(404, resulObject.StatusCode);
            }
        }
        [Fact]
        public async Task TestMiniBusControllerGetByIdNotBadRequest()
        {
            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var document = new MiniBus
            {
                Id = 1,
                Company = company,
                Capacity = 20,
                Brand = "Toyota",
            };

            int miniBusId = 0;
            _miniBusServiceMock.Setup(c => c.GetMiniBusByID(document.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document);
            var actionResult = await _miniBusController.GetMiniBus(miniBusId);
            Assert.NotNull(actionResult);
            Assert.True(actionResult is BadRequestObjectResult);
            var actualResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(actualResult);
            Assert.NotEqual(0, actualResult.StatusCode);
            Assert.Equal(400, actualResult.StatusCode);

        }
        [Fact]
        public async Task TestMiniBusControllerDeleteMiniBusSuccess()
        {

            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var miniBusInsertar = new MiniBus
            {
                Id = 1,
                Company = company,
                Capacity = 20,
                Brand = "Toyota",
            };
            int response = 204;
            _miniBusServiceMock.Setup(c => c.DeleteMinibus(miniBusInsertar.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(response);
            var actionResult = await _miniBusController.DeleteMiniBus(miniBusInsertar.Id);
            Assert.NotNull(actionResult);
            var actualResult = actionResult as StatusCodeResult;
            Assert.NotNull(actualResult);
            Assert.True(actualResult is not null);
            Assert.NotNull(actualResult);
            Assert.NotEqual(0, actualResult.StatusCode);
            Assert.Equal(204, actualResult.StatusCode);
        }

        [Fact]
        public async Task TestMiniBusControllerInsertMiniBusSuccess()
        {
            var minibus = new MiniBusDTO ();
            var company = new CompanyDTO
            {
                Id = 1,
                Name = "Prueba"
            };

            MiniBusDTO miniBusDTOInsertar = new()
            {
                Id = 0,
                Company = company,
                Capacity = 20,
                Brand = "Toyota",
                Year = 2020,
                ModificationDate = It.IsAny<DateTime>(),
                InsertionDate = It.IsAny<DateTime>(),
                UserInsert = "Roberto",
                UserModifies = "Roberto"
            };

            int response = 201;
            _miniBusServiceMock.Setup(c => c.InsertMinibus(It.IsAny<MiniBus>(), "Roberto", It.IsAny<DateTime>())).ReturnsAsync(response);
            var actionResult = await _miniBusController.InsertMiniBus(miniBusDTOInsertar);
            Assert.NotNull(actionResult);
            var actualResult = actionResult as StatusCodeResult;
            Assert.True(actualResult is not null);
            Assert.NotNull(actualResult);
            Assert.NotEqual(0, actualResult.StatusCode);
            Assert.Equal(201, actualResult.StatusCode);
        }
    }
}
