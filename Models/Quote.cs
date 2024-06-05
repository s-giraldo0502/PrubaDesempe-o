using System.ComponentModel.DataAnnotations;

namespace Filtro.Models
{
    public class Qoute
    {
        [Key]
        public required int QouteId { get; set; }
        public required DateTime Date{ get; set; }
        public Pet pet{ get; set; }
        public Vet vet{ get; set; }
        public required string Description { get; set; }
    }
}