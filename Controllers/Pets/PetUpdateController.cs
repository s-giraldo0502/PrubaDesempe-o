using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers.Pets
{
    public class PetUpdateController: ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetUpdateController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        
        [HttpPut]
        [Route("api/Pet/{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.PetId)
            {
                return BadRequest();
            }
            try{
            await _petRepository.UpdateAsync(pet);
            return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500,"Por favor ingresa todos los campos");
            }
        }
        
    }
}