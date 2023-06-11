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
            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var miniBusList = new List<MiniBus> {
                new MiniBus { Id = 1, Company = company, Capacity = 20, Brand = "Toyota" },
                new MiniBus { Id = 2, Company = company, Capacity = 20, Brand = "Isuzu" }
            };

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
            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var miniBus = new MiniBus
            {
                Id = 1,
                Company = company,
                Capacity = 20,
                Brand = "Toyota",
            };

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
            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var miniBus = new MiniBus
            {
                Id = 1,
                Company = company,
                Capacity = 20,
                Brand = "Toyota",
            };

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
            var company = new Company
            {
                Id = 1,
                Name = "Prueba"
            };

            var miniBus = new MiniBus
            {
                Id = 1,
                Company = company,
                Capacity = 20,
                Brand = "Toyota",
                Year = 2020,
                ModificationDate = It.IsAny<DateTime>(),
                InsertionDate = It.IsAny<DateTime>(),
                UserInsert = "Roberto",
                UserModifies = "Roberto"
            };
            
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
