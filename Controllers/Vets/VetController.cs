using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers.Vets
{
    public class VetController: ControllerBase
    {
        private readonly IVetRepository _vetRepository;

        public VetController(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }
        
        [HttpGet]
        [Route("api/Vets")]
        public async Task<ActionResult<IEnumerable<Vet>>> GetVets()
        {
            return Ok(await _vetRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("api/Vet/{id}")]
        public async Task<ActionResult<Vet>> GetVet(int id)
        {
            var vet = await _vetRepository.GetByIdAsync(id);
            if (vet == null)
            {
                return NotFound();
            }
            return Ok(vet);
        }
    }
}