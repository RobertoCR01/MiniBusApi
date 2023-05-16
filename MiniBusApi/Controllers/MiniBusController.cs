using Microsoft.AspNetCore.Mvc;
using MiniBusApi.Domain.Dto;
using MiniBusApi.Data.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace MiniBusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiniBusController : ControllerBase
    {
    
        public MiniBusController(ILogger<MiniBusController> logger)
        {
   
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MiniBusDTO>> GetMiniBuses()
        {
            _logger.LogInformation("Getting all minibuses");
            return Ok(MiniBusStore.miniBusList);

        }

        [HttpGet("{id:int}", Name = "GetMiniBus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(200,Type = typeof(MiniBusDTO))]
        public ActionResult<MiniBusDTO> GetMiniBus(int id)
        {
            if (id == 0)
            {
                _logger.LogInformation($" Get Minibus error with id = {id}");
                return BadRequest();
            };

            var miniBus = MiniBusStore.miniBusList.FirstOrDefault(u => u.Id == id);

            if (miniBus == null)
            {
                return NotFound();
            }
            return Ok(miniBus);

        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<MiniBusDTO> CreateMiniBus([FromBody] MiniBusDTO miniBusDTO)
        {
            if(MiniBusStore.miniBusList.FirstOrDefault(u => u.Brand.ToLower() == miniBusDTO.Brand.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError","Minibus already exist");
                return BadRequest(ModelState);
            }
            if (miniBusDTO == null)
            {
                return BadRequest(miniBusDTO);
            };

            if (miniBusDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            miniBusDTO.Id = MiniBusStore.miniBusList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            MiniBusStore.miniBusList.Add(miniBusDTO);
            return CreatedAtRoute("GetMiniBus", new { id = miniBusDTO.Id }, miniBusDTO);
            return Ok(miniBusDTO);

        }
        
        [HttpDelete("{id:int}", Name = "DeleteMiniBus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteMiniBus(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var miniBus = MiniBusStore.miniBusList.FirstOrDefault(u => u.Id == id);
            if (miniBus == null)
            {
                return NotFound();
            }
            MiniBusStore.miniBusList.Remove(miniBus);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateMiniBus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateMiniBus(int id, [FromBody]  MiniBusDTO miniBusDTO) 
        {
        if (miniBusDTO == null || miniBusDTO.Id != id)
            {
                return BadRequest();
            }
            var miniBus = MiniBusStore.miniBusList.FirstOrDefault(u => u.Id == id);
            miniBus.Brand = miniBusDTO.Brand;
            miniBus.Capacity = miniBusDTO.Capacity;
            miniBus.IdCompany = miniBusDTO.IdCompany;
            miniBus.Tipo = miniBusDTO.Tipo;

            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdatePartialMiniBus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult UpdatePartialMinibus(int id, JsonPatchDocument<MiniBusDTO> patchDto) 
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var miniBus = MiniBusStore.miniBusList.FirstOrDefault(u => u.Id == id);
            if (miniBus == null)
            {
                return NotFound();
            }
            patchDto.ApplyTo(miniBus,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }
}