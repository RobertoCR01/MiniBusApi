using Microsoft.AspNetCore.Mvc;
using MiniBusManagement.Services.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Api.Models.Administration;
using Microsoft.Extensions.Options;
using Microsoft.ApplicationInsights;
using AutoMapper;

namespace MiniBusManagement.Api.Controllers.Administration
{
    [Route("api/mini-buses")]
    [ApiController]
    public class MiniBusController : ControllerBase
    {
        private readonly IMiniBusService _miniBusService;
        private readonly string _user = Environment.UserName;
        private readonly DateTime _date = DateTime.Now;

        public MiniBusController(IMiniBusService miniBusService)
        {
            _miniBusService = miniBusService;
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMiniBus(int id)
        {

            try
            {
                if (id == 0)
                {
                    return BadRequest("invalid id");
                };

                MiniBus minibus = await _miniBusService.GetMiniBusByID(id, _user, _date);
                MiniBusDTO minibusDTO = new MiniBusDTO();
                minibusDTO.Id = minibus.Id;
                minibusDTO.Brand = minibus.Brand;

                if (minibusDTO.Id == 0)
                {
                    return NotFound("MiniBus does not exist");
                }
                return Ok(minibusDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }

        }

    }
}