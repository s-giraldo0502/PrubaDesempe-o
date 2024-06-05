using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers.Owners
{
    public class OwnerUpdateController: ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerUpdateController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        
        [HttpPut]
        [Route("api/Owner/{id}")]
        public async Task<IActionResult> PutCita(int id, Owner owner)
        {
            if (id != owner.OwnerId)
            {
                return BadRequest();
            }
            try{
            await _ownerRepository.UpdateAsync(owner);
            return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500,"Por favor ingresa todos los campos");
            }
        }
        
    }
}