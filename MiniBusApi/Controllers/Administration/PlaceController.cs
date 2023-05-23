using Microsoft.AspNetCore.Mvc;
using MiniBusManagement.Api.Mapper;
using MiniBusManagement.Api.Models.Administration;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Service.Administration;

namespace MiniBusManagement.Api.Controllers.Administration
{
        [Route("api/places")]
        [ApiController]
        public class PlaceController : ControllerBase
        {
            private readonly IMiniBusService _miniBusService;
            private readonly string _user = Environment.UserName;
            private readonly DateTime _date = DateTime.Now;
            private readonly MiniBusMapper _mapper;

            public PlaceController(IMiniBusService miniBusService)
            {
                _miniBusService = miniBusService;
                _mapper = new MiniBusMapper();
            }

            [HttpGet("{id:int}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            // [ProducesResponseType(200,Type = typeof(MiniBusDTO))]
            public async Task<ActionResult<MiniBusDTO>> GetMiniBus(int id)
            {
                try
                {
                    if (id == 0)
                    {
                        return StatusCode(400);
                    };

                    MiniBus minibus = await _miniBusService.GetMiniBusByID(id, _user, _date);
                    MiniBusDTO minibusDTO = _mapper.MinibusToMiniBusDto(minibus);

                    if (minibusDTO.Id == 0)
                    {
                        return StatusCode(404);
                    }
                    return StatusCode(200, minibusDTO);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult<MiniBusDTO>> InsertMiniBus([FromBody] MiniBusDTO minibusProcesar)
            {
                try
                {
                    if (minibusProcesar == null)
                    {
                        return StatusCode(400);
                    };

                    if (minibusProcesar.Id > 0)
                    {
                        return StatusCode(500);
                    }

                    MiniBus minibus = _mapper.MinibusDtoToMiniBus(minibusProcesar);

                    int result = await _miniBusService.InsertMinibus(minibus, _user, _date);
                    return StatusCode(result);
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }

            }

            [HttpDelete("{minibusID:int}")]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]

            public async Task<IActionResult> DeleteMiniBus(int minibusID)
            {
                try
                {
                    int result = await _miniBusService.DeleteMinibus(minibusID, _user, _date);
                    return StatusCode(result);

                }
                catch (Exception)
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
                    return StatusCode(200, minibuses);
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }


            }
            [HttpPut("{id:int}")]
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
                        return StatusCode(400);
                    }
                    if (miniBusProcesar.Id != id)
                    {
                        return StatusCode(409);
                    }
                    MiniBus minibus = _mapper.MinibusDtoToMiniBus(miniBusProcesar);
                    int result = await _miniBusService.UpdateMinibus(id, minibus, _user, _date);
                    return StatusCode(result);
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }


            }
        }
    
}
