using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;
using Filtro.Controllers.Mail;


namespace Filtro.Controllers.Qoutes
{
    public class QouteCreateController: ControllerBase
    {
        private readonly IQouteRepository _qouteRepository;

        public QouteCreateController(IQouteRepository qouteRepository)
        {
            _qouteRepository = qouteRepository;
        }


        [HttpPost]
        [Route("api/Qoute/Create")]
        public async Task<ActionResult<Qoute>> PostQoute(Qoute qoute)
        {
            try
            {
                // Lógica para agregar la cita a la base de datos
                await _qouteRepository.AddAsync(qoute);

                // Lógica para enviar el correo
                MailController Email = new MailController();
                Email.EnviarCorreoAsync();
                return Ok(new { message = "Cita Creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la Cita: {ex.Message}");
            }
        } 
    }
}