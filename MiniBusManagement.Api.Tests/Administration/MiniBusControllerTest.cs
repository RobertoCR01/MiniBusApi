using Microsoft.AspNetCore.Mvc;
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
        private readonly Mock<IOptionsMonitor<HaciendaOptions>> _options;
        private readonly Mock<ILogger<MiniBusController>> _logger;
        private readonly IMapper _mapper;

        public MiniBusControllerTest()
        {
            _options = new Mock<IOptionsMonitor<HaciendaOptions>>();
            _logger = new Mock<ILogger<MiniBusController>>();
            
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
            var controller = new MiniBusController(mockMiniBusService.Object, _options.Object, _logger.Object, _mapper);

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

            loggerMock.Setup(x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<object>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()
            )).Callback((LogLevel level, EventId eventId, object state, Exception exception, Func<object, Exception, string> formatter) => {
                logMessages.Add(formatter(state, exception));
                Console.WriteLine($"Log message added: {formatter(state, exception)}");
            });


            int miniBusId = 1;
            mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMiniBusByID(It.IsAny<int>(), "Roberto", It.IsAny<DateTime>())).ReturnsAsync(new MiniBus
            {
                Id=1, CompanyId=1, Capacity=20,Brand="pruba"
            });
            var controller = new MiniBusController(mockMiniBusService.Object);

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

            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMiniBusByID(miniBusId, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document.Object);
            var controller = new MiniBusController(mockMiniBusService.Object, _options.Object, _logger.Object, _mapper);
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
            var controller = new MiniBusController(mockMiniBusService.Object, _options.Object, _logger.Object, _mapper);
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
            var controller = new MiniBusController(mockMiniBusService.Object, _options.Object, _logger.Object, _mapper);
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
            var controller = new MiniBusController(mockMiniBusService.Object, _options.Object, _logger.Object, _mapper);
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
