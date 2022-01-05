using AnimalCollectionWithDB.DTOs;
using AnimalCollectionWithDB.Entities;
using AnimalCollectionWithDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnimalCollectionWithDB.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        // GET: /api/animals
        [HttpGet("")]
        public IActionResult GetAnimals()
        {
            var animals = _animalRepository.GetAll().ToList().MapToAnimalDTOs();

            return Ok(animals);
        }

        // GET: /api/animals/:id
        [HttpGet("{id}")]
        public IActionResult GetAnimalByID(int id)
        {
            Animal animal = _animalRepository.GetByID(id);
            if (animal == null)
            {
                return NotFound("Can't find animal with ID: " + id);
            }
            AnimalDTO animalDTO = animal.MapToAnimalDTO();

            return Ok(animalDTO);

        }

        // POST: /api/animals
        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] CreateUpdateAnimalDTO createUpdateAnimalDTO)
        {
            Animal newAnimal = _animalRepository.CreateAnimal(createUpdateAnimalDTO);
            AnimalDTO animalDTO = _animalRepository.GetByID(newAnimal.ID).MapToAnimalDTO();

            return CreatedAtAction(
                nameof(GetAnimalByID),
                new { id = animalDTO.ID },
                animalDTO);
        }

        // PUT: /api/animals/:id
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromBody] CreateUpdateAnimalDTO createUpdateAnimalDTO, int id)
        {
            Animal updatedAnimal = _animalRepository.UpdateAnimal(createUpdateAnimalDTO, id);
            AnimalDTO animalDTO = _animalRepository.GetByID(id).MapToAnimalDTO();

            return Ok(animalDTO);
        }

        // PUT: /api/animals/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _animalRepository.DeleteAnimal(id);
            return NoContent();
        }

    }

}