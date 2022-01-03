namespace AnimalCollectionWithDB.Entities
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AnimalTypeID { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}