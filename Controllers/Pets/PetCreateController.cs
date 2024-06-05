using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;


namespace Filtro.Controllers.Pets
{
    public class PetCreateController: ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetCreateController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }


        [HttpPost]
        [Route("api/Pet/Create")]
        public async Task<ActionResult<Pet>> PostPets(Pet pet)
        {
            try
            {
                // Lógica para agregar la cita a la base de datos
                await _petRepository.AddAsync(pet);

                // Lógica para enviar el correo
                // MailController Email = new MailController();
                // Email.EnviarCorreoAsync();
                return Ok(new { message = "Mascota Creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la Mascota: {ex.Message}");
            }
        } 
    }
}