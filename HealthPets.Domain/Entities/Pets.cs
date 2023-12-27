namespace HealthPets.Domain.Entities
{
    //anemic class, but should be a rich domain class
    public sealed class Pets : BaseEntity
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
