using System.ComponentModel.DataAnnotations;

namespace Filtro.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        public required string Names { get; set; }
        public required string LastNames { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
    }
}