using Microsoft.AspNetCore.Mvc;
using MiniBusApi.Domain.Dto;
using MiniBusApi.Data.Data;


namespace MiniBusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiniBusController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<MiniBusDTO> GetMiniBuses()
        {
            return MiniBusStore.miniBusList;

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
    }
}