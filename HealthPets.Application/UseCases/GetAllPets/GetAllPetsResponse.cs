namespace HealthPets.Application.UseCases.GetAllPets
{
    public sealed record class GetAllPetsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
