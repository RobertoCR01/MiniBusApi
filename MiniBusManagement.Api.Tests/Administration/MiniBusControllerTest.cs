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

        private Mock<IMiniBusService> mockMiniBusService;
        public MiniBusControllerTest()
        {
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
        }
  
    }
}
