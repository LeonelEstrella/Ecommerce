using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        [MaxLength(25)]
        public string Marca { get; set; }

        [MaxLength(25)]
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public IList<CarritoProducto> CarritoProductos { get; set; }
    }
}
