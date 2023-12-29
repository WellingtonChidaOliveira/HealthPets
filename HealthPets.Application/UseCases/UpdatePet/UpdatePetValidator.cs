using FluentValidation;

namespace HealthPets.Application.UseCases.UpdatePet
{
    public class UpdatePetValidator : AbstractValidator<UpdatePetRequest>
    {
        public UpdatePetValidator()
        {
            RuleFor(pet => pet.Id)
                .NotEmpty()
                .WithMessage("The pet Id must have value");

            RuleFor(pet => pet.Name)
                .NotEmpty()
                .WithMessage("The Pet name is required")
                .MaximumLength(100)
                 .WithMessage("The name must be less than 100 characters");

            RuleFor(pet => pet.Owner)
                .NotEmpty()
                .WithMessage("The owner is required")
                .MinimumLength(3)
                .WithMessage("The owner must be more than or equal 3 characters")
                .MaximumLength(100)
                .WithMessage("The owner name must be less than 100 characters");
        }
    }
}
