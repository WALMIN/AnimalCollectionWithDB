using AnimalCollectionWithDB.Entities;

namespace AnimalCollectionWithDB.DTOs
{
    public class UpdateAnimalDTO
    {
        public string Name { get; set; }
        public int AnimalTypeID { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
