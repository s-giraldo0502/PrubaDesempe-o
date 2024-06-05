using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Filtro.Models
{
    public class Pet
    {
        [Key]
        public required int PetId { get; set; }
        public required string Name { get; set; }
        public required string Specie { get; set; }
        public required string Race { get; set; }
        public required DateTime Date { get; set; }
        public Owner Owners { get; set; }
        public required string Photo { get; set; }
    }
}