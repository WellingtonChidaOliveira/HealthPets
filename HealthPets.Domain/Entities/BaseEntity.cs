namespace HealthPets.Domain.Entities
{
    public class BaseEntity
    {
        public Ulid Id { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
