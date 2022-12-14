using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [MaxLength(10)]
        public int DNI { get; set; }

        [MaxLength(25)]
        public string Nombre { get; set; }

        [MaxLength(25)]
        public string Apellido { get; set; }
        public string Direccion { get; set; }

        [MaxLength(13)]
        public string Telefono { get; set; }

        public Carrito Carrito { get; set; }
    }
}
