using AutoMapper;
using HealthPets.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPets.Application.UseCases.GetAllPets
{
    public sealed class GetAllPetsHandler : IRequestHandler<GetAllPetsRequest, List<GetAllPetsResponse>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public GetAllPetsHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPetsResponse>> Handle(GetAllPetsRequest request, CancellationToken cancellationToken)
        {
            var pets = await _petRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<GetAllPetsResponse>>(pets);
        }
    }
}
