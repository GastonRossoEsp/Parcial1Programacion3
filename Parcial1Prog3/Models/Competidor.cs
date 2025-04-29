using System.ComponentModel.DataAnnotations;

namespace Parcial1Prog3.Models
{
    public class Competidor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdDisciplina {  get; set; }
        [Range(0, int.MaxValue, ErrorMessage="El valor debe ser 0 o mayor")]
        public int Edad {  get; set; }
        [Required]
        public string Ciudad {  get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}
