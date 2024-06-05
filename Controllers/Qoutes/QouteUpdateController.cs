using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers.Qoutes
{
    public class QouteUpdateController: ControllerBase
    {
        private readonly IQouteRepository _qouteRepository;

        public QouteUpdateController(IQouteRepository qouteRepository)
        {
            _qouteRepository = qouteRepository;
        }
        
        [HttpPut]
        [Route("api/Qoute/{id}")]
        public async Task<IActionResult> PutQoute(int id, Qoute qoute)
        {
            if (id != qoute.QouteId)
            {
                return BadRequest();
            }
            try{
            await _qouteRepository.UpdateAsync(qoute);
            return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500,"Por favor ingresa todos los campos");
            }
        }
        
    }
}