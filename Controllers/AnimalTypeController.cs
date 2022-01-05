using Microsoft.AspNetCore.Mvc;
using AnimalCollectionWithDB.Entities;
using AnimalCollectionWithDB.Repositories;
using AnimalCollectionWithDB.DTOs;
using System.Linq;

namespace AnimalCollectionWithDB.Controllers
{
    [ApiController]
    [Route("api/animaltypes")]
    public class AnimalTypeController : ControllerBase
    {
        private readonly IAnimalTypeRepository _repository;
        public AnimalTypeController(IAnimalTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: /api/animaltypes
        [HttpGet("")]
        public IActionResult GetAnimalTypes()
        {
            var animalTypes = _repository.GetAll()
                .Select(item => new AnimalTypeDTO
                {
                    ID = item.ID,
                    Name = item.Name
                })
                .OrderBy(item => item.Name);

            return Ok(animalTypes);
        }

        // GET: /api/animaltypes/:id
        [HttpGet("{id}")]
        public IActionResult GetAnimalTypeByID(int id)
        {
            AnimalType animalType = _repository.GetByID(id);
            if (animalType == null)
            {
                return NotFound("Can't find animal type with ID: " + id);
            }
            AnimalTypeDTO animalTypeDTO = MapAnimalTypeToAnimalTypeDTO(animalType);

            return Ok(animalTypeDTO);
        }

        // POST: /api/animaltypes
        [HttpPost("")]
        public IActionResult CreateAnimalType([FromBody] AnimalType animalType)
        {
            AnimalType newAnimalType = _repository.CreateAnimalType(animalType);
            AnimalTypeDTO animalTypeDTO = MapAnimalTypeToAnimalTypeDTO(newAnimalType);

            return CreatedAtAction(
                nameof(GetAnimalTypeByID),
                new { id = animalTypeDTO.ID },
                animalTypeDTO);
        }

        // PUT: /api/animaltypes/:id
        [HttpPut("{id}")]
        public IActionResult UpdateAnimalType([FromBody] AnimalType animalType, int id)
        {
            AnimalType updatedAnimalType = _repository.UpdateAnimalType(animalType, id);
            AnimalTypeDTO animalTypeDTO = MapAnimalTypeToAnimalTypeDTO(updatedAnimalType);

            return Ok(animalTypeDTO);
        }

        // PUT: /api/animaltypes/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimalType(int id)
        {
            _repository.DeleteAnimalType(id);
            return NoContent();
        }

        private AnimalTypeDTO MapAnimalTypeToAnimalTypeDTO(AnimalType animalType)
        {
            AnimalTypeDTO animalTypeDTO = new AnimalTypeDTO
            {
                ID = animalType.ID,
                Name = animalType.Name,
            };

            return animalTypeDTO;
        }

    }

}