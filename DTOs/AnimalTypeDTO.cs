using AnimalCollectionWithDB.Entities;

namespace AnimalCollectionWithDB.DTOs
{
    public class AnimalTypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public static class AnimalTypeDTOExtensions
    {
        public static AnimalTypeDTO MapToAnimalTypeDTO(this AnimalType animalType)
        {
            return new AnimalTypeDTO
            {
                ID = animalType.ID,
                Name = animalType.Name
            };

        }

        public static List<AnimalTypeDTO> MapToAnimalTypeDTOs(this List<AnimalType> animalType)
        {
            return animalType.Select(animalType => animalType.MapToAnimalTypeDTO()).OrderBy(animal => animal.ID).ToList();

        }

    }

}