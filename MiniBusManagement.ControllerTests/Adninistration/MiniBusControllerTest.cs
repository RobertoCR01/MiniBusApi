using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiniBusManagement.Api;
using MiniBusManagement.Api.Controllers.Administration;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Services.Administration;
using Moq;
using Xunit;

namespace MiniBusManagement.ControllerTests.Administration
{
    public class MiniBusControllerTest
    {
        private readonly IOptionsMonitor<HaciendaOptions> _options;
        private readonly ILogger<MiniBusController> _logger;
        private readonly IMapper _mapper;
        public MiniBusControllerTest()
        {
            _options = Mock.Of<IOptionsMonitor<HaciendaOptions>>();
            _logger = Mock.Of<ILogger<MiniBusController>>();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            _mapper = new Mapper(config);
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

            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMinibus("Roberto", It.IsAny<DateTime>())).ReturnsAsync(miniBusList);
            var controller = new MiniBusController(mockMiniBusService.Object, _options, _logger, _mapper);
            var actionResult = await controller.GetMiniBuses();
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
                Assert.Equal(2, miniBusListObject.Count);

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
                Company = company,
                Capacity = 20,
                Brand = "Toyota",
            };

            int miniBusId = 1;

            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMiniBusByID(document.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document);
            var controller = new MiniBusController(mockMiniBusService.Object, _options, _logger, _mapper);
            var actionResult = await controller.GetMiniBus(miniBusId);
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
        }
        [Fact]
        public async Task TestMiniBusControllerGetByIdNotFound()
        {
            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var document = new Mock<MiniBus>();
            int miniBusId = 5;

            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMiniBusByID(miniBusId, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document.Object);
            var controller = new MiniBusController(mockMiniBusService.Object, _options, _logger, _mapper);
            var actionResult = await controller.GetMiniBus(miniBusId);
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
            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMiniBusByID(document.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document);
            var controller = new MiniBusController(mockMiniBusService.Object, _options, _logger, _mapper);
            var actionResult = await controller.GetMiniBus(miniBusId);
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


            var mockMiniBusService = new Mock<IMiniBusService>();
            int response = 204;
            mockMiniBusService.Setup(c => c.DeleteMinibus(miniBusInsertar.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(response);
            var controller = new MiniBusController(mockMiniBusService.Object, _options, _logger, _mapper);
            var actionResult = await controller.DeleteMiniBus(miniBusInsertar.Id);
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

            var mockMiniBusService = new Mock<IMiniBusService>();
            int response = 201;
            mockMiniBusService.Setup(c => c.InsertMinibus(It.IsAny<MiniBus>(), "Roberto", It.IsAny<DateTime>())).ReturnsAsync(response);
            var controller = new MiniBusController(mockMiniBusService.Object, _options, _logger, _mapper);
            var actionResult = await controller.InsertMiniBus(miniBusDTOInsertar);
            Assert.NotNull(actionResult);
            var actualResult = actionResult as StatusCodeResult;
            Assert.True(actualResult is not null);
            Assert.NotNull(actualResult);
            Assert.NotEqual(0, actualResult.StatusCode);
            Assert.Equal(201, actualResult.StatusCode);
        }
    }
}
