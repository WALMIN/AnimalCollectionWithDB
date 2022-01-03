using AnimalCollectionWithDB.Entities;

namespace AnimalCollectionWithDB.Repositories
{
    public class AnimalTypeRepository : IAnimalTypeRepository
    {
        private ApplicationContext _context;

        public AnimalTypeRepository(ApplicationContext context)
        {
            //_animalTypes = PopulateAnimalTypeData();
            _context = context;
        }


        public List<AnimalType> GetAll()
        {
            return _context.AnimalTypes.ToList();
        }


        public AnimalType GetByID(int id)
        {
            AnimalType animalType = _context.AnimalTypes.Find(id);
            return animalType;
        }


        public AnimalType CreateAnimalType(AnimalType animalType)
        {
            AnimalType newAnimalType = animalType;

            _context.AnimalTypes.Add(animalType);
            _context.SaveChanges();

            return newAnimalType;
        }


        public AnimalType UpdateAnimalType(AnimalType animalType, int id)
        {
            AnimalType currentAnimalType = _context.AnimalTypes.FirstOrDefault(item => item.ID == animalType.ID);
            if (currentAnimalType != null)
            {
                currentAnimalType.Name = animalType.Name;
            }

            _context.SaveChanges();
            return currentAnimalType;
        }


        public void DeleteAnimalType(int id)
        {
            _context.AnimalTypes.Remove(GetByID(id));
            _context.SaveChanges();
        }

    }

}