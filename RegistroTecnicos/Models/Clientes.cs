﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }     
        [Required(ErrorMessage = "El nombre del cliente es necesario")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Whatsapp es necesario")]
        [Range(10, 12)]
        public int Whatsapp { get; set; }

    }
}
