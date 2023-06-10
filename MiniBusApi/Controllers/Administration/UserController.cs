using AutoMapper;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Services.Administration;

namespace MiniBusManagement.Api.Controllers.Administration
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly string _user = Environment.UserName;
        private readonly DateTime _date = DateTime.Now;
        private readonly IMapper _mapper;
        private readonly IOptionsMonitor<JwtOptions> _options;
        private readonly ILogger _logger;
        private readonly TelemetryClient _telemetryClient;
        public UserController(IUserService userService, IOptionsMonitor<JwtOptions> options, ILogger<UserController> logger, TelemetryClient telemetryClient,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            _options = options;
            _logger = logger;
            _telemetryClient = telemetryClient;
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(int id)
        {
            try

            {
                if (id == 0)
                {
                    var todo = _options.CurrentValue.SecretKey;
                    return BadRequest("invalid id");
                };

                User user = await _userService.GetUserByID(id, _user, _date);
                UserDTO userDTO = _mapper.Map<UserDTO>(user);

                if (userDTO.Id == 0)
                {
                    return NotFound("User does not exist");
                }
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
