using Microsoft.AspNetCore.Mvc;
using MiniBusApi.Service.administration.services;
using Microsoft.AspNetCore.JsonPatch;
using MiniBusApi.Models.Dto;
using AutoMapper;
using MiniBusApi.Domain.Models;

namespace MiniBusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiniBusController : ControllerBase
    {
        private readonly IMiniBusService _miniBusService;
        private readonly IMapper _mapper;
        private readonly string _user = Environment.UserName;
        private readonly DateTime _date = DateTime.Now;

        public MiniBusController(IMiniBusService miniBusService, IMapper mapper)
        {
            this._miniBusService = miniBusService;
            this._mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "GetMiniBus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(200,Type = typeof(MiniBusDTO))]
        public async Task<ActionResult<MiniBusDTO>> GetMiniBus(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            };

            MiniBus minibus = await _miniBusService.GetMiniBusByID(id, _user, _date);
            MiniBusDTO minibusDTO = _mapper.Map<MiniBusDTO>(minibus);

            if (minibusDTO == null)
            {
                return NotFound();
            }
            return Ok(minibusDTO);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<MiniBusDTO>> InsertMiniBus([FromBody] MiniBusDTO minibusProcesar)
        {
            if (minibusProcesar == null)
            {
                return BadRequest(minibusProcesar);
            };

            if (minibusProcesar.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            MiniBus minibus = _mapper.Map<MiniBus>(minibusProcesar);

            MiniBus miniBusProcesado = await _miniBusService.InsertMinibus(minibus, _user, _date);
            var miniBusDTO = _mapper.Map<MiniBusDTO>(miniBusProcesado);

            return CreatedAtRoute("GetMiniBus", new { id = miniBusDTO.Id }, miniBusDTO);
            return Ok(miniBusDTO);

        }
        [HttpDelete("{minibusID:int}", Name = "DeleteMiniBus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteMiniBus(int minibusID)
        //public async Task<ActionResult<MiniBusDTO>> DeleteMinibus(int minibusID, string loggedUser, DateTime currentDate)
        {
            MiniBus miniBusProcesado = await _miniBusService.DeleteMinibus(minibusID, _user, _date);
            var miniBusDTO = _mapper.Map<MiniBusDTO>(miniBusProcesado);
            return Ok(miniBusDTO);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MiniBusDTO>>> GetMiniBuses()
        {
            var minibuses = await _miniBusService.GetMinibus(_user,_date);
            return Ok(minibuses.ToList());

        }

    }
}