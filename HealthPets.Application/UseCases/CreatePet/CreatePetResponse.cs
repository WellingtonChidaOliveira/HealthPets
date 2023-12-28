namespace HealthPets.Application.UseCases.CreatePet
{
    public sealed record CreatePetResponse
    {
        public Ulid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
    }
}
