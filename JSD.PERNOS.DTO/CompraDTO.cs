using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.DTO
{
    public class CompraDTO
    {
        public int IdAlmacen { get; set; }
        public int IdTipoMovimiento { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaCompra { get; set; }
        public List<DetalleCompraDTO> detalleCompra { get; set; }
        
    }

    public class DetalleCompraDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        
    }

}
