using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.DTO
{
    public class VentaDTO
    {
        public int IdAlmacen { get; set; }  // Propiedad para el Id del Almacén
        public int IdTipoMovimiento { get; set; }
        public string Tipo { get; set; }
        public List<CarritoDTO> Carrito { get; set; }  // Lista de productos en el carrito
    }

    public class CarritoDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }


}
