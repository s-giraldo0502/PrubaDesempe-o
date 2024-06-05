using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers.Pets
{
    public class PetController: ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        
        [HttpGet]
        [Route("api/Pets")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetCitas()
        {
            return Ok(await _petRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("api/Pet/{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _petRepository.GetByIdAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }
    }
}