using AnimalCollectionWithDB.Entities;

namespace AnimalCollectionWithDB.DTOs
{
    public class AnimalDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public AnimalTypeDTO AnimalType { get; set; }
    }

    public static class AnimalDTOExtenstions
    {
        public static AnimalDTO MapToAnimalDTO(this Animal animal)
        {
            return new AnimalDTO
            {
                ID = animal.ID,
                Name = animal.Name,
                AnimalType = animal.animalType.MapToAnimalTypeDTO()
            };

        }

        public static List<AnimalDTO> MapToAnimalDTOs(this List<Animal> animals)
        {
            return animals.Select(animal => animal.MapToAnimalDTO()).OrderBy(animal => animal.AnimalType.ID).ToList();
        }

    }
}
