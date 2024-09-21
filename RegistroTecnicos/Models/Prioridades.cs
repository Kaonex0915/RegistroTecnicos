
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El tiempo es requerido")]
        public DateTime Tiempo { get; set; } = DateTime.Now; 
    }
}