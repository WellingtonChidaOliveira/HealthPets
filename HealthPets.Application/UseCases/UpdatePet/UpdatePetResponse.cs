namespace HealthPets.Application.UseCases.UpdatePet
{
    public sealed record class UpdatePetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
    }
}
