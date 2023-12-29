using MediatR;
using System.Collections.Generic;

namespace HealthPets.Application.UseCases.GetAllPets
{
    public record GetAllPetsRequest : IRequest<List<GetAllPetsResponse>>;
}
