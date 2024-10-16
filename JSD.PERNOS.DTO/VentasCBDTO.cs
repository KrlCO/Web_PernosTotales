using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.DTO
{
    public class VentasCBDTO
    {
        public int IdVentaCB { get; set; }
        public int IdAlmacen { get; set; }
        public int IdTipoMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime Periodo { get; set; }
        public DateTime FechaRegistro { get; set; }
       
    }
}
