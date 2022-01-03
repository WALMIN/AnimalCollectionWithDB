using System.ComponentModel.DataAnnotations;

namespace AnimalCollectionWithDB.Entities
{
    public class AnimalType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
