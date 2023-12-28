using AutoMapper;
using HealthPets.Domain.Entities;

namespace HealthPets.Application.UseCases.CreatePet
{
    public sealed class CreatePetMapper : Profile
    {
        public CreatePetMapper()
        {
            CreateMap<CreatePetRequest, Pet>();
            CreateMap<Pet, CreatePetResponse>();
        }
            
    }
}
