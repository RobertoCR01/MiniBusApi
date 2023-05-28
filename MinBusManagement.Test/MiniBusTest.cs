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

namespace MiniBusManagement
{
    public class MiniBusTest
    {
        private readonly IOptionsMonitor<JwtOptions> _options;
        public MiniBusTest() 
        {
            _options = A.Fake<IOptionsMonitor<JwtOptions>>();
        }

        [Fact]
        public async Task TestMiniBusControllerGet()
        {
            var minibuses = A.Fake<ICollection<MiniBus>>();
            var miniBusList = A.Fake<List<MiniBus>>();
            miniBusList.Add(new MiniBus { Id = 1, IdCompany = 2, Capacity = "20", Brand = "Toyota" });
            miniBusList.Add(new MiniBus { Id = 2, IdCompany = 2, Capacity = "20", Brand = "Isuzu" });
            

            var mockBookService = new Mock<IMiniBusService>();
            mockBookService.Setup(c => c.GetMinibus( "Roberto", It.IsAny<DateTime>())).ReturnsAsync(miniBusList);
            var controller = new MiniBusController(mockBookService.Object, _options);
            var actionResult = await controller.GetMiniBuses();
           
            //Assert
            var result = actionResult.Result as ObjectResult;
            Assert.NotNull(result);
            var miniBus = result.Value as List<MiniBus>;
            Assert.NotNull(miniBus);



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
            int miniBusId = 0;
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
                var bus = actualResult.Value;
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
    }
}