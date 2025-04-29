using System.ComponentModel.DataAnnotations;

namespace Parcial1Prog3.Models
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
