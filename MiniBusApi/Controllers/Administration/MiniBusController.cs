﻿using Microsoft.AspNetCore.Mvc;
using MiniBusManagement.Service.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Api.Mapper;

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

        public MiniBusController(IMiniBusService miniBusService)
        {
            _miniBusService = miniBusService;
            _mapper = new MiniBusMapper();
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
            MiniBusDTO minibusDTO = _mapper.MinibusToMiniBusDto(minibus);

            if (minibusDTO == null)
            {
                return NotFound();
            }
            return Ok(minibusDTO);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

            MiniBus minibus = _mapper.MinibusDtoToMiniBus(minibusProcesar);

            MiniBus miniBusProcesado = await _miniBusService.InsertMinibus(minibus, _user, _date);
            MiniBusDTO miniBusDTO = _mapper.MinibusToMiniBusDto(miniBusProcesado);

            //return CreatedAtRoute("GetMiniBus", new { id = miniBusDTO.Id }, miniBusDTO);
            return Ok(miniBusDTO);

        }
        [HttpDelete("{minibusID:int}", Name = "DeleteMiniBus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteMiniBus(int minibusID)
        {
            MiniBus miniBusProcesado = await _miniBusService.DeleteMinibus(minibusID, _user, _date);
            MiniBusDTO miniBusDTO = _mapper.MinibusToMiniBusDto(miniBusProcesado);
            return Ok(miniBusDTO);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MiniBusDTO>>> GetMiniBuses()
        {
            var minibuses = await _miniBusService.GetMinibus(_user, _date);
            return Ok(minibuses.ToList());

        }
        [HttpPut("{id:int}", Name = "UpdateMiniBus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateMiniBus(int id, [FromBody] MiniBusDTO miniBusProcesar)
        {
            MiniBus minibus = _mapper.MinibusDtoToMiniBus(miniBusProcesar);

            MiniBus miniBusProcesado = await _miniBusService.UpdateMinibus(id, minibus, _user, _date);
            MiniBusDTO miniBusDTO = _mapper.MinibusToMiniBusDto(miniBusProcesado);
            return Ok(miniBusDTO);
        }
    }
}