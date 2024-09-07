using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }
        [Required(ErrorMessage = "Es necesario el campo Nombre")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Es necesario especificar el SueldoHora")]
        [Range(1, 15000)]
        public int SueldoHora { get; set; }
        [ForeignKey("TipoTecnicosId")]    
        public int TipoTecnicosId { get; set; }
    }