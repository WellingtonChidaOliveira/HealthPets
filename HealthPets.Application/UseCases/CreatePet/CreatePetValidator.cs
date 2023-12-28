using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HealthPets.Application.UseCases.CreatePet
{
    public sealed class CreatePetValidator : AbstractValidator<CreatePetRequest>
    {
        public CreatePetValidator()
        {
            RuleFor(pet => pet.Name)
                .NotEmpty()
                .WithMessage("The name is required")
                .MaximumLength(100)
                .WithMessage("The name must be less than 100 characters");

            RuleFor(pet => pet.Breed)
                .NotEmpty()
                .WithMessage("The breed is required")
                .MaximumLength(100)
                .WithMessage("The breed must be less than 100 characters");

            RuleFor(pet => pet.Owner)
                .NotEmpty()
                .WithMessage("The owner is required")
                .MaximumLength(100)
                .WithMessage("The owner must be less than 100 characters");

            RuleFor(pet => pet.Phone)
                .NotEmpty()
                .NotNull().WithMessage("Phone Number is required.")
                .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
                .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");

            RuleFor(pet => pet.Address)
                .NotEmpty()
                .WithMessage("The address is required")
                .MaximumLength(100)
                .WithMessage("The address must be less than 100 characters");
        }
    }
}
