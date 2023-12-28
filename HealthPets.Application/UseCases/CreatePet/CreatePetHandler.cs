using AutoMapper;
using HealthPets.Domain.Abstractions;
using HealthPets.Domain.Entities;
using MediatR;

namespace HealthPets.Application.UseCases.CreatePet
{
    public sealed class CreatePetHandler : IRequestHandler<CreatePetRequest, CreatePetResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public CreatePetHandler(IMapper mapper, IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreatePetResponse> Handle(CreatePetRequest request, CancellationToken cancellationToken)
        {
            var pet = _mapper.Map<Pet>(request);

            _petRepository.Create(pet);

            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<CreatePetResponse>(pet);
        }
    }
}
