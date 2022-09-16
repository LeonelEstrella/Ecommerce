using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public byte Estado { get; set; }
        public Cliente ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Orden Orden { get; set; }
        public IList<CarritoProducto> CarritoProductos { get; set; }
    }
}
