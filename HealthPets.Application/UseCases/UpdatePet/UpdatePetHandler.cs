using AutoMapper;
using HealthPets.Domain.Abstractions;
using MediatR;

namespace HealthPets.Application.UseCases.UpdatePet
{
    public sealed class UpdatePetHandler : IRequestHandler<UpdatePetRequest, UpdatePetResponse>
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePetHandler(IUnitOfWork unitOfWork, IPetRepository petRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePetResponse> Handle(UpdatePetRequest request, CancellationToken cancellationToken)
        {
            var pets = await _petRepository.GetByIdAsync(request.Id, cancellationToken);
            if (pets == null) return default;

            pets.Name = request.Name;
            pets.Owner = request.Owner;

            _petRepository.Update(pets);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<UpdatePetResponse>(pets);    
        }
    }
}
