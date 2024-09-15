using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class Trabajos
    {
        [Key]
        public int TrabajoId { get; set; }
        [ForeignKey("ClientesId")]
        public int ClienteId { get; set; }

        [ForeignKey("TecnicoId")]
        public int TecnicoId { get; set;}

        [Required(ErrorMessage = "La fecha del trabajo es requerida")]
        public DateTime Fecha {  get; set; } = DateTime.Now;

        [Required(ErrorMessage ="La descriocion del trabajo es requerida")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage ="El monto del trabajo es requerido")]
        public int Monto { get; set; }
        

    }
}
