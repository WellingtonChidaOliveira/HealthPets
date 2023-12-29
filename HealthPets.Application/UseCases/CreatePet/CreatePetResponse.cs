namespace HealthPets.Application.UseCases.CreatePet
{
    public sealed record CreatePetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
    }
}
