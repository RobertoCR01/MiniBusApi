﻿using Microsoft.AspNetCore.Mvc;
using MiniBusManagement.Service.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Api.Mapper;
using MiniBusManagement.Api;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.ApplicationInsights.Extensibility;

namespace MiniBusManagement.Api.Controllers.Administration
{
    [Route("api/mini-buses")]
    [ApiController]
    public class MiniBusController : ControllerBase
    {
        private readonly IMiniBusService _miniBusService;
        private readonly string _user = Environment.UserName;
        private readonly DateTime _date = DateTime.Now;
        private readonly MiniBusMapper _mapper;
        private readonly IOptionsMonitor<JwtOptions> _options;
        private readonly ILogger _logger;

        public MiniBusController(IMiniBusService miniBusService, IOptionsMonitor<JwtOptions> options, ILogger<MiniBusController> logger)
        {
            _miniBusService = miniBusService;
            _mapper = new MiniBusMapper();
            _options = options;
            _logger = logger;
        }
        [HttpGet("{id:int}", Name = "GetMiniBus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMiniBus(int id)
        {
            var minibusMensaje = new MiniBus() 
            { Id = 1,
              Brand= "Toyota",
              Capacity="20",
              Year=2020,
              Tipo="Van"     
            };
            _logger.LogInformation("MiniBus:", minibusMensaje);
            _logger.LogError("Error Prueba", minibusMensaje);
            _logger.LogWarning("Warning Prueba", minibusMensaje);
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error Exeption");
                    throw new Exception("Something went wrong.");
                    var todo = _options.CurrentValue.SecretKey;
                    return BadRequest("invalid id");
                };

                MiniBus minibus = await _miniBusService.GetMiniBusByID(id, _user, _date);
                MiniBusDTO minibusDTO = _mapper.MinibusToMiniBusDto(minibus);

                if (minibusDTO.Id == 0)
                {
                    return NotFound("MiniBus does not exist");
                }
                return Ok(minibusDTO);
            } catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor");
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertMiniBus([FromBody] MiniBusDTO minibusProcesar)
        {
            try
            {
                if (minibusProcesar == null)
                {
                    return BadRequest();
                };

                if (minibusProcesar.Id > 0)
                {
                    return BadRequest();
                }

                MiniBus minibus = _mapper.MinibusDtoToMiniBus(minibusProcesar);

                int result = await _miniBusService.InsertMinibus(minibus, _user, _date);
                if (result == 201)
                {
                    return StatusCode(StatusCodes.Status201Created);
                } else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpDelete("{minibusID:int}", Name = "DeleteMiniBus")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMiniBus(int minibusID)
        {
            try
            {
                int result = await _miniBusService.DeleteMinibus(minibusID, _user, _date);
                switch (result)
                {
                    case 204:
                        return NoContent();
                    case 404:
                        return NotFound();
                    default:
                        return StatusCode(StatusCodes.Status500InternalServerError);
                }

            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MiniBusDTO>>> GetMiniBuses()
        {
            try
            {
                var minibuses = await _miniBusService.GetMinibus(_user, _date);
                return Ok(minibuses);
            } catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }
        [HttpPut("{id:int}", Name = "UpdateMiniBus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateMiniBus(int id, [FromBody] MiniBusDTO miniBusProcesar)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                if (miniBusProcesar.Id != id)
                {
                    return Conflict("Different Ids");
                }
                MiniBus minibus = _mapper.MinibusDtoToMiniBus(miniBusProcesar);
                int result = await _miniBusService.UpdateMinibus(id, minibus, _user, _date);
                switch (result) {
                    case 204:
                        return NoContent();
                    case 404:
                        return NotFound();
                    default:
                        return StatusCode(StatusCodes.Status500InternalServerError);
                }
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

             
        }
    }
}