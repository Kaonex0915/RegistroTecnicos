using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }
        [Required(ErrorMessage = "Es necesario el campo Nombre")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Es necesario especificar el SueldoHora")]
        [Range(100, 600)]
        public int SueldoHora { get; set; }

    }
}
