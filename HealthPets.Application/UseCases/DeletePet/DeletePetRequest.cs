using MediatR;

namespace HealthPets.Application.UseCases.DeletePet
{
    public sealed record DeletePetRequest(Guid Id) : IRequest<DeletePetResponse>;
}
