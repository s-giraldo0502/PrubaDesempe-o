using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers.Owners
{
    public class OwnerController: ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        
        [HttpGet]
        [Route("api/Owners")]
        public async Task<ActionResult<IEnumerable<Owner>>> GetCitas()
        {
            return Ok(await _ownerRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("api/Owner/{id}")]
        public async Task<ActionResult<Owner>> GetCita(int id)
        {
            var cita = await _ownerRepository.GetByIdAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            return Ok(cita);
        }
    }
}