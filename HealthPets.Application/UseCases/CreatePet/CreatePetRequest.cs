using MediatR;

namespace HealthPets.Application.UseCases.CreatePet
{
    public record CreatePetRequest(string Name,string Breed ,string Owner, string Phone, string Address): IRequest<CreatePetResponse>;
    
}
