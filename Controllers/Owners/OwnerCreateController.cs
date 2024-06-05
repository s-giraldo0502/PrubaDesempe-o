using Microsoft.AspNetCore.Mvc;
using Filtro.Models;
using Filtro.Services;


namespace Filtro.Controllers.Owners
{
    public class OwnerCreateController: ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerCreateController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }


        [HttpPost]
        [Route("api/Owner/Create")]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            try
            {
                // Lógica para agregar la cita a la base de datos
                await _ownerRepository.AddAsync(owner);

                // Lógica para enviar el correo
                // MailController Email = new MailController();
                // Email.EnviarCorreoAsync();
                return Ok(new { message = "Cliente creado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el Cliente: {ex.Message}");
            }
        } 
    }
}