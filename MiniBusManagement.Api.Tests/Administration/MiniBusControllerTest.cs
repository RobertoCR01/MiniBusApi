using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiniBusManagement.Api.Controllers.Administration;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Services.Administration;
using Xunit;
using NSubstitute;
using Castle.Core.Resource;

namespace MiniBusManagement.Api.Tests.Administration
{
    public class MiniBusControllerTest
    {
        
        private readonly IOptionsMonitor<HaciendaOptions> _optionsMock;
        private readonly ILogger<MiniBusController> _loggerMock;
        private readonly ILogger<MiniBusController> _logger;
        // Quitar logger duplicado
        private readonly IMapper _mapper;
        private readonly IMiniBusService _miniBusServiceMock;
        private readonly MiniBusController _miniBusController;

        public MiniBusControllerTest()
        {
            _miniBusServiceMock = Substitute.For<IMiniBusService>();
            _optionsMock = Substitute.For<IOptionsMonitor<HaciendaOptions>>();
            _loggerMock = Substitute.For<ILogger<MiniBusController>>();
            
            using var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = logFactory.CreateLogger<MiniBusController>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = configuration.CreateMapper();
            _miniBusController = new MiniBusController(_miniBusServiceMock, _optionsMock, _loggerMock, _mapper);
        }


        [Fact]
        public async Task TestMiniBusControllerGetSuccess()
        {

            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var miniBusList = new List<MiniBus>
            {
                new MiniBus { Id = 1, Company = company, Capacity = 20, Brand = "Toyota" },
                new MiniBus { Id = 2, Company = company, Capacity = 20, Brand = "Isuzu" }
            };

            var serviceMock = Substitute.For<IMiniBusService>();
            serviceMock.GetMinibus(MiniBusController.User, Arg.Any<DateTime>()).Returns(miniBusList);

            var controller = new MiniBusController(serviceMock, _optionsMock, _logger, _mapper);
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

            int miniBusId = 1;
            _miniBusServiceMock.Setup(c => c.GetMiniBusByID(It.IsAny<int>(), MiniBusController.User, It.IsAny<DateTime>())).ReturnsAsync(new MiniBus
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
        
        // TODO: Remove comment -> dejar espacios entre los metodos
        [Fact]
        public async Task TestMiniBusControllerGetByIdNotFound()
        {

            var document = new Mock<MiniBus>();
            int miniBusId = 1;
            _miniBusServiceMock.Setup(c => c.GetMiniBusByID(miniBusId, MiniBusController.User, It.IsAny<DateTime>())).ReturnsAsync(document.Object);
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
            _miniBusServiceMock.Setup(c => c.GetMiniBusByID(document.Id, MiniBusController.User, It.IsAny<DateTime>())).ReturnsAsync(document);
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
            _miniBusServiceMock.Setup(c => c.DeleteMinibus(miniBusInsertar.Id, MiniBusController.User, It.IsAny<DateTime>())).ReturnsAsync(response);
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
                UserInsert = MiniBusController.User,
                UserModifies = MiniBusController.User
            };

            int response = 201;
            _miniBusServiceMock.Setup(c => c.InsertMinibus(It.IsAny<MiniBus>(), MiniBusController.User, It.IsAny<DateTime>())).ReturnsAsync(response);
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
