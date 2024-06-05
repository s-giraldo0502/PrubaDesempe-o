using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;

namespace Filtro.Controllers.Qoutes
{
    public class QouteController: ControllerBase
    {
        private readonly IQouteRepository _qouteRepository;

        public QouteController(IQouteRepository qouteRepository)
        {
            _qouteRepository = qouteRepository;
        }
        
        [HttpGet]
        [Route("api/Qoutes")]
        public async Task<ActionResult<IEnumerable<Qoute>>> GetQoutes()
        {
            return Ok(await _qouteRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("api/Qoute/{id}")]
        public async Task<ActionResult<Qoute>> GetQoute(int id)
        {
            var qoute = await _qouteRepository.GetByIdAsync(id);
            if (qoute == null)
            {
                return NotFound();
            }
            return Ok(qoute);
        }
    }
}