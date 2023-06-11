using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Data.Repositories.Administration;
using Moq;
using Xunit;

namespace MiniBusManagement.DataTests.Administration
{
    public class MiniBusRepositoryTest
    {

        [Fact]
        public async Task TestGetMiniBusSucces()
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

            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.GetMinibus()).ReturnsAsync(miniBusList);
            var actionResult = await mockMiniBusRepository.Object.GetMinibus();
            Assert.NotNull(actionResult);
            var listMiniBusResponse = (List<MiniBus>)actionResult;
            Assert.NotNull(listMiniBusResponse);
            Assert.Equal(2, listMiniBusResponse.Count);
        }
        [Fact]
        public async Task TestGetMinibusByIDSucces()
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
                Brand = "Toyota"
            };

            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.GetMinibusByID(miniBus.Id)).ReturnsAsync(miniBus);
             var actionResult = await mockMiniBusRepository.Object.GetMinibusByID(1);
            Assert.NotNull(actionResult);
            var miniBusResponse = (MiniBus)actionResult;
            Assert.NotNull(miniBusResponse);
            Assert.Equal(1, miniBusResponse.Id);
        }
        [Fact]
        public async Task TestInsertMinibusSucces()
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
                Brand = "Toyota"
            };

            var response = 201;
            var mockMiniBusRepository = new Mock<IMiniBusRepository>();
            mockMiniBusRepository.Setup(c => c.InsertMinibus(miniBus)).ReturnsAsync(response);
            var actionResult = await mockMiniBusRepository.Object.InsertMinibus(miniBus);
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
            var actionResult = await mockMiniBusRepository.Object.UpdateMinibus(miniBus);
            Assert.Equal(201, actionResult);
        }
    }
}
