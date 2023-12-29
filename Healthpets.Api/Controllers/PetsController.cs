using HealthPets.Application.UseCases.CreatePet;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreatePetResponse>> Create(CreatePetRequest req, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(req, cancellationToken);
            return Ok(response);
        }
    }
}
