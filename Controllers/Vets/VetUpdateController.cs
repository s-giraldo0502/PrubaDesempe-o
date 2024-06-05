using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers.Vets
{
    public class VetUpdateController: ControllerBase
    {
        private readonly IVetRepository _vetRepository;

        public VetUpdateController(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }
        
        [HttpPut]
        [Route("api/Vet/{id}")]
        public async Task<IActionResult> PutVet(int id, Vet vet)
        {
            if (id != vet.VetId)
            {
                return BadRequest();
            }
            try{
            await _vetRepository.UpdateAsync(vet);
            return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500,"Por favor ingresa todos los campos");
            }
        }
        
    }
}