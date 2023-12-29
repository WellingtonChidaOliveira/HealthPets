using HealthPets.Application.UseCases.CreatePet;
using HealthPets.Application.UseCases.DeletePet;
using HealthPets.Application.UseCases.GetAllPets;
using HealthPets.Application.UseCases.UpdatePet;
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

        [HttpGet]
        public async Task<ActionResult<List<GetAllPetsResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllPetsRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePetResponse>> Create(CreatePetRequest req, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(req, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePetResponse>> Update(Guid id, UpdatePetRequest req, CancellationToken cancellationToken)
        {
            if(id != req.Id)return BadRequest();

            var response = await _mediator.Send(req, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletePetResponse>> Delete(Guid? id, CancellationToken cancellationToken)
        {
            if(id is null) return BadRequest();

            var response = await _mediator.Send(new DeletePetRequest(id.Value), cancellationToken);
            return Ok(response);
        }
    }
}
