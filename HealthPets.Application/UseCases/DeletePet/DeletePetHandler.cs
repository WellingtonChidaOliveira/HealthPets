using AutoMapper;
using HealthPets.Domain.Abstractions;
using MediatR;

namespace HealthPets.Application.UseCases.DeletePet
{
    public sealed class DeletePetHandler : IRequestHandler<DeletePetRequest, DeletePetResponse>
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePetHandler(IMapper mapper, IUnitOfWork unitOfWork, IPetRepository petRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _petRepository = petRepository;
        }

        public async Task<DeletePetResponse> Handle(DeletePetRequest request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.GetByIdAsync(request.Id, cancellationToken);
            if (pet == null) return default;

            _petRepository.Delete(pet);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<DeletePetResponse>(pet);
        }
    }
}
