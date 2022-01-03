using AnimalCollectionWithDB.DTOs;
using AnimalCollectionWithDB.Entities;
using AnimalCollectionWithDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalCollectionWithDB.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalTypeRepository _animalTypeRepository;
        public AnimalController(IAnimalRepository animalRepository, IAnimalTypeRepository animalTypeRepository)
        {
            _animalRepository = animalRepository;
            _animalTypeRepository = animalTypeRepository;
        }

        // GET: /api/[controller]
        [HttpGet("")]
        public IActionResult GetAnimals()
        {
            List<AnimalDTO> animals = _animalRepository.GetAll().ToList().MapToAnimalDTOs();

            return Ok(animals);
        }

        // GET: /api/[controller]/:id
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

        // POST: /api/[controller]
        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] Animal animal)
        {
            Animal newAnimal = _animalRepository.CreateAnimal(animal);
            AnimalDTO animalDTO = _animalRepository.GetByID(newAnimal.ID).MapToAnimalDTO();

            return CreatedAtAction(
                nameof(GetAnimalByID),
                new { id = animalDTO.ID },
                animalDTO);
        }

        // PUT: /api/[controller]/:id
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal, int id)
        {
            Animal updatedAnimal = _animalRepository.UpdateAnimal(animal, id);
            AnimalDTO animalDTO = _animalRepository.GetByID(id).MapToAnimalDTO();


            return Ok(animalDTO);
        }

        // PUT: /api/[controller]/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _animalRepository.DeleteAnimal(id);
            return NoContent();
        }

    }

}