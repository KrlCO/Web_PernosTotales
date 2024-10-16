using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.DTO
{
    public class SalidaDTO
    {
        public int IdAlmacen { get; set; }  // Propiedad para el Id del Almacén
        public int IdTipoMovimiento { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaVenta { get; set; }
        public List<DetalleSalidaDTO> detalleSalida { get; set; }
    }

    public class DetalleSalidaDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
