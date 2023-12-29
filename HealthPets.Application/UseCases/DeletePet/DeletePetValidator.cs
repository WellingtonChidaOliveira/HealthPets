using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPets.Application.UseCases.DeletePet
{
    public class DeletePetValidator : AbstractValidator<DeletePetRequest>
    {
        public DeletePetValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");
        }
    }
}
