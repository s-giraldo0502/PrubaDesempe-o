using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;


namespace Filtro.Controllers.Vets
{
    public class VetCreateController: ControllerBase
    {
        private readonly IVetRepository _vetRepository;

        public VetCreateController(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }


        [HttpPost]
        [Route("api/Vet/Create")]
        public async Task<ActionResult<Vet>> PostVets(Vet vet)
        {
            try
            {
                // Lógica para agregar la cita a la base de datos
                await _vetRepository.AddAsync(vet);

                // Lógica para enviar el correo
                // MailController Email = new MailController();
                // Email.EnviarCorreoAsync();
                return Ok(new { message = "Veterinaria Creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la Mascota: {ex.Message}");
            }
        } 
    }
}