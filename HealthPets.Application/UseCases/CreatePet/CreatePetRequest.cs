using MediatR;

namespace HealthPets.Application.UseCases.CreatePet
{
    public record CreatePetRequest(string Name, string Owner, string Phone, string Address): IRequest<CreatePetResponse>
    {
        public string Breed { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    };
    
}
