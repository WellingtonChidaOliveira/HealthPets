using MediatR;

namespace HealthPets.Application.UseCases.UpdatePet
{
    //TODO:Add all fields for update
    public sealed record UpdatePetRequest(Guid Id, string Name, string Owner) : IRequest<UpdatePetResponse>;
    
}
