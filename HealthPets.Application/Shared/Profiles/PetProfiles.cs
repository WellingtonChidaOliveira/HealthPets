using AutoMapper;
using HealthPets.Application.UseCases.CreatePet;
using HealthPets.Application.UseCases.DeletePet;
using HealthPets.Application.UseCases.GetAllPets;
using HealthPets.Application.UseCases.UpdatePet;
using HealthPets.Domain.Entities;

namespace HealthPets.Application.Shared.Profiles
{
    public sealed class PetProfiles : Profile
    {
        public PetProfiles()
        {
            CreateMap<CreatePetRequest, Pet>();
            CreateMap<Pet, CreatePetResponse>();

            CreateMap<Pet, GetAllPetsResponse>();

            CreateMap<UpdatePetRequest, Pet>();
            CreateMap<Pet, UpdatePetResponse>();

            CreateMap<DeletePetRequest, Pet>();
            CreateMap<Pet, DeletePetResponse>();
        }
    }
}
