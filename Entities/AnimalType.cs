namespace AnimalCollectionWithDB.Entities
{
    public class AnimalType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Animal> Animals { get; set; }
    }
}
