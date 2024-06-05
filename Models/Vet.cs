using System.ComponentModel.DataAnnotations;

namespace Filtro.Models
{
    public class Vet
    {
        [Key]
        public required int VetId { get; set;}
        public required string Names { get; set;}
        public required string Phone { get; set;}
        public required string Address { get; set;}
        public required string Email { get; set;}
    }
}