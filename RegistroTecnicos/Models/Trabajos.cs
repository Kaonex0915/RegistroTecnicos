using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class Trabajos
    {
        [Key]
        public int TrabajosId { get; set; }
        [ForeignKey("ClientesId")]
        public int ClientesId { get; set; }

        [ForeignKey("TecnicoId")]
        public int TecnicoId { get; set;}

        [Required(ErrorMessage = "La fecha del trabajo es requerida")]
        public DateTime Fecha {  get; set; }

        [Required(ErrorMessage ="La descriocion del trabajo es requerida")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage ="El monto del trabajo es requerido")]
        public int Monto { get; set; }
        

    }
}
