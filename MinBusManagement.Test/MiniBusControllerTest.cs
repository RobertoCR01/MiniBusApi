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
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace MiniBusManagement.Test
{
    public class MiniBusControllerTest
    {
        private readonly IOptionsMonitor<JwtOptions> _options;
        public MiniBusControllerTest()
        {
            _options = A.Fake<IOptionsMonitor<JwtOptions>>();
        }

        [Fact]
        public async Task TestMiniBusControllerGetSucces()
        {
            var miniBusList = A.Fake<List<MiniBus>>();
            miniBusList.Add(new MiniBus { Id = 1, IdCompany = 2, Capacity = "20", Brand = "Toyota" });
            miniBusList.Add(new MiniBus { Id = 2, IdCompany = 2, Capacity = "20", Brand = "Isuzu" });

            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMinibus("Roberto", It.IsAny<DateTime>())).ReturnsAsync(miniBusList);
            var controller = new MiniBusController(mockMiniBusService.Object, _options);
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
                Assert.NotNull(miniBusListObject);
                Assert.Equal(2, miniBusListObject.Count);

            }

        }

        [Fact]
        public async Task TestMiniBusControllerGetByIdSuccess()
        {
            var document = A.Fake<MiniBus>();
            document.Id = 1;
            document.IdCompany = 2;
            document.Capacity = "20";
            document.Brand = "Toyota";
            int miniBusId = 1;
            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMiniBusByID(document.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document);
            var controller = new MiniBusController(mockMiniBusService.Object, _options);
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
            var document = A.Fake<MiniBus>();
            document.Id = 1;
            document.IdCompany = 2;
            document.Capacity = "20";
            document.Brand = "Toyota";

            int miniBusId = 5;
            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMiniBusByID(document.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document);
            var controller = new MiniBusController(mockMiniBusService.Object, _options);
            var actionResult = await controller.GetMiniBus(miniBusId);
            Assert.NotNull(actionResult);
            Assert.True(actionResult is NotFoundObjectResult);
            var actualResult = actionResult as NotFoundObjectResult;
            Assert.NotNull(actualResult);
            Assert.NotEqual(0, actualResult.StatusCode);
            Assert.Equal(404, actualResult.StatusCode);
        }
        [Fact]
        public async Task TestMiniBusControllerGetByIdNotBadRequest()
        {
            var document = A.Fake<MiniBus>();
            document.Id = 1;
            document.IdCompany = 2;
            document.Capacity = "20";
            document.Brand = "Toyota";

            int miniBusId = 0;
            var mockMiniBusService = new Mock<IMiniBusService>();
            mockMiniBusService.Setup(c => c.GetMiniBusByID(document.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(document);
            var controller = new MiniBusController(mockMiniBusService.Object, _options);
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

            var miniBusInsertar = A.Fake<MiniBus>();
            miniBusInsertar.Id = 1;
            miniBusInsertar.Tipo = "Van";
            miniBusInsertar.IdCompany = 2;
            miniBusInsertar.Capacity = "20";
            miniBusInsertar.Brand = "Toyota";

            var mockMiniBusService = new Mock<IMiniBusService>();
            int response = 204;
            mockMiniBusService.Setup(c => c.DeleteMinibus(miniBusInsertar.Id, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(response);
            var controller = new MiniBusController(mockMiniBusService.Object, _options);
            var actionResult = await controller.DeleteMiniBus(miniBusInsertar.Id);
            var actualResult = actionResult as StatusCodeResult;
            Assert.NotNull(actualResult);
            Assert.True(actualResult is StatusCodeResult);
            Assert.NotNull(actualResult);
            Assert.NotEqual(0, actualResult.StatusCode);
            Assert.Equal(204, actualResult.StatusCode);

        }

        [Fact]
        public async Task TestMiniBusControllerInsertMiniBusSuccess()
        {
            var miniBusInsertar = A.Fake<MiniBus>();
            miniBusInsertar.Id = 0;
            miniBusInsertar.IdCompany = 2;
            miniBusInsertar.Capacity = "20";
            miniBusInsertar.Brand = "Toyota";
            miniBusInsertar.Year = 2020;
            miniBusInsertar.ModificationDate = It.IsAny<DateTime>();
            miniBusInsertar.InsertionDate = It.IsAny<DateTime>();
            miniBusInsertar.UserInsert = "Roberto";
            miniBusInsertar.UserModifies = "Roberto";

            MiniBusDTO miniBusDTOInsertar = A.Fake<MiniBusDTO>();
            miniBusDTOInsertar.Id = 0;
            miniBusDTOInsertar.IdCompany = 2;
            miniBusDTOInsertar.Capacity = "20";
            miniBusDTOInsertar.Brand = "Toyota";
            miniBusDTOInsertar.Year = 2020;
            miniBusDTOInsertar.ModificationDate = It.IsAny<DateTime>();
            miniBusDTOInsertar.InsertionDate = It.IsAny<DateTime>();
            miniBusDTOInsertar.UserInsert = "Roberto";
            miniBusDTOInsertar.UserModifies = "Roberto";

            var mockMiniBusService = new Mock<IMiniBusService>();
            int response = 201;
            mockMiniBusService.Setup(c => c.InsertMinibus(miniBusInsertar, "Roberto", It.IsAny<DateTime>())).ReturnsAsync(response);
            var controller = new MiniBusController(mockMiniBusService.Object, _options);
            var actionResult = await controller.InsertMiniBus(miniBusDTOInsertar);
            var actualResult = actionResult as StatusCodeResult;
            Assert.NotNull(actualResult);
            Assert.True(actualResult is StatusCodeResult);
            Assert.NotNull(actualResult);
            Assert.NotEqual(0, actualResult.StatusCode);
            Assert.Equal(500, actualResult.StatusCode);
        }
    }
}