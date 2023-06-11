using FakeItEasy;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Data.Administration;
using MiniBusManagement.Services.Administration;
using Moq;
using Xunit;


namespace MiniBusManagement.Test.Administration
{
    public class MiniBusServiceTest
    {

        [Fact]
        public async Task TestMiniBusServiceGetSucces()
        {
            var company = A.Fake<Company>();
            company.Id = 1;
            company.Name = "Prueba";

            var miniBusList = A.Fake<List<MiniBus>>();
            miniBusList.Add(new MiniBus { Id = 1, Company = company, Capacity = 20, Brand = "Toyota" });
            miniBusList.Add(new MiniBus { Id = 2, Company = company, Capacity = 20, Brand = "Isuzu" });

            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.GetMinibus()).ReturnsAsync(miniBusList);
            var service = new MiniBusService(mockMiniBusRepository.Object);
            var actionResult = await service.GetMinibus("Roberto", It.IsAny<DateTime>());
            Assert.NotNull(actionResult);
            var listMiniBusResponse = (List<MiniBus>)actionResult;
            Assert.NotNull(listMiniBusResponse);
            Assert.Equal(2, listMiniBusResponse.Count);
        }
        [Fact]
        public async Task TestMiniBusServiceGetByIDSucces()
        {
            var miniBus = A.Fake<MiniBus>();
            var company = A.Fake<Company>();
            company.Id = 1;
            company.Name = "Prueba";

            miniBus.Id = 1;
            miniBus.Company = company;
            miniBus.Capacity = 20;
            miniBus.Brand = "Toyota";

            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.GetMinibusByID(miniBus.Id)).ReturnsAsync(miniBus);
            var service = new MiniBusService(mockMiniBusRepository.Object);
            var actionResult = await service.GetMiniBusByID(1, "Roberto", It.IsAny<DateTime>());
            Assert.NotNull(actionResult);
            var miniBusResponse = (MiniBus)actionResult;
            Assert.NotNull(miniBusResponse);
            Assert.Equal(1, miniBusResponse.Id);
        }
        [Fact]
        public async Task TestMiniBusServiceInsertSucces()
        {   
            var miniBus = A.Fake<MiniBus>();

            var company = A.Fake<Company>();
            company.Id = 1;
            company.Name = "Prueba";

            miniBus.Id = 1;
            miniBus.Company = company;
            miniBus.Capacity = 20;
            miniBus.Brand = "Toyota";
            var response = 201;
            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.InsertMinibus(miniBus)).ReturnsAsync(response);
            var service = new MiniBusService(mockMiniBusRepository.Object);
            var actionResult = await service.InsertMinibus(miniBus, "Roberto", It.IsAny<DateTime>());
            Assert.Equal(201, actionResult);
        }
        [Fact]
        public async Task TestMiniBusServiceUpdateucces()
        {
            var miniBus = A.Fake<MiniBus>();

            var company = A.Fake<Company>();
            company.Id = 1;
            company.Name = "Prueba";

            miniBus.Id = 1;
            miniBus.Company = company;
            miniBus.Capacity = 20;
            miniBus.Brand = "Toyota";
            miniBus.Year = 2020;
            miniBus.ModificationDate = It.IsAny<DateTime>();
            miniBus.InsertionDate = It.IsAny<DateTime>();
            miniBus.UserInsert = "Roberto";
            miniBus.UserModifies = "Roberto";
            var response = 201;
            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.UpdateMinibus(miniBus)).ReturnsAsync(response);
            mockMiniBusRepository.Setup(c => c.GetMinibusByID(miniBus.Id)).ReturnsAsync(miniBus);
            var service = new MiniBusService(mockMiniBusRepository.Object);
            var actionResult = await service.UpdateMinibus(1, miniBus, "Roberto", It.IsAny<DateTime>());
            Assert.Equal(201, actionResult);
        }
    }
}
