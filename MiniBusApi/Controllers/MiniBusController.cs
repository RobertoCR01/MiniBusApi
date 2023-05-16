using Microsoft.AspNetCore.Mvc;
using MiniBusApi.Domain.Dto;
using MiniBusApi.Domain.Models;
using MiniBusApi.Data.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace MiniBusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiniBusController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MiniBusController(ApplicationDbContext db)      
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MiniBusDTO>> GetMiniBuses()
        {
            return Ok(_db.Minibuses.ToList());

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

            var miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == id);

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
            if(_db.Minibuses.FirstOrDefault(u => u.Brand.ToLower() == miniBusDTO.Brand.ToLower()) != null)
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
            MiniBus model = new()
            {
                Id = miniBusDTO.Id,
                IdCompany = miniBusDTO.IdCompany,
                Brand = miniBusDTO.Brand,
                Tipo = miniBusDTO.Tipo,
                Year = miniBusDTO.Year,
                Capacity = miniBusDTO.Capacity,
                UserInsert = miniBusDTO.UserInsert,
                InsertionDate = miniBusDTO.InsertionDate,
                UserModifies = miniBusDTO.UserModifies,
                ModificationDate = miniBusDTO.ModificationDate


            };

            _db.Minibuses.Add(model);
            _db.SaveChanges();

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
            var miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == id);
            if (miniBus == null)
            {
                return NotFound();
            }
            _db.Minibuses.Remove(miniBus);
            _db.SaveChanges();
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
            //var miniBus = _db.Minibuses.FirstOrDefault(u => u.Id == id);
            //miniBus.Brand = miniBusDTO.Brand;
            //miniBus.Capacity = miniBusDTO.Capacity;
            //miniBus.IdCompany = miniBusDTO.IdCompany;
            //miniBus.Tipo = miniBusDTO.Tipo;
            MiniBus model = new()
            {
                Id = miniBusDTO.Id,
                IdCompany = miniBusDTO.IdCompany,
                Brand = miniBusDTO.Brand,
                Tipo = miniBusDTO.Tipo,
                Year = miniBusDTO.Year,
                Capacity = miniBusDTO.Capacity,
                UserInsert = miniBusDTO.UserInsert,
                InsertionDate = miniBusDTO.InsertionDate,
                UserModifies = miniBusDTO.UserModifies,
                ModificationDate = miniBusDTO.ModificationDate


            };
            _db.Minibuses.Update(model);
            _db.SaveChanges();
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
            var miniBus = _db.Minibuses.AsNoTracking().FirstOrDefault(u => u.Id == id);

            MiniBusDTO miniBusDTO = new()
            {
                Id = miniBus.Id,
                IdCompany = miniBus.IdCompany,
                Brand = miniBus.Brand,
                Tipo = miniBus.Tipo,
                Year = miniBus.Year,
                Capacity = miniBus.Capacity,
                UserInsert = miniBus.UserInsert,
                InsertionDate = miniBus.InsertionDate,
                UserModifies = miniBus.UserModifies,
                ModificationDate = miniBus.ModificationDate


            };

            if (miniBus == null)
            {
                return NotFound();
            }
            patchDto.ApplyTo(miniBusDTO, ModelState);

            MiniBus model = new()
            {
                Id = miniBusDTO.Id,
                IdCompany = miniBusDTO.IdCompany,
                Brand = miniBusDTO.Brand,
                Tipo = miniBusDTO.Tipo,
                Year = miniBusDTO.Year,
                Capacity = miniBusDTO.Capacity,
                UserInsert = miniBusDTO.UserInsert,
                InsertionDate = miniBusDTO.InsertionDate,
                UserModifies = miniBusDTO.UserModifies,
                ModificationDate = miniBusDTO.ModificationDate


            };
            _db.Minibuses.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }
}