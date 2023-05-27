using MiniBusManagement.Api.Controllers.Administration;
using FakeItEasy;
using MiniBusManagement.Service.Administration;
using Microsoft.Extensions.Options;
using MiniBusManagement.Api;
using MiniBusManagement.Api.Models.Administration;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace MiniBusManagement
{
    public class MiniBusTest
    {
        private readonly IMiniBusService _miniBusService;
        private readonly IOptionsMonitor<JwtOptions> _options;
        public MiniBusTest() 
        {
            _miniBusService = A.Fake<IMiniBusService>();
            _options = A.Fake<IOptionsMonitor<JwtOptions>>();
        }

        [Fact]
        public void TestMiniBusControllerGet()
        {
            var minibuses = A.Fake<ICollection<MiniBusDTO>>();
            var miniBusList = A.Fake<List<MiniBusDTO>>();
            var controller = new MiniBusController(_miniBusService, _options);
            var result = controller.GetMiniBuses();
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ActionResult<IEnumerable<MiniBusDTO>>>>();
        }

        [Fact]
        public void TestMiniBusControllerGetById()
        {
            var controller = new MiniBusController(_miniBusService, _options);
            var result = controller.GetMiniBus(0);
         
 
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<IActionResult>));
        }
    }
}