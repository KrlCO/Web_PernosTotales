using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.DTO
{
     public class ValeCBDTO
    {
        public int IdValeCB { get; set; }
        public string CodigoVale { get; set; }
        public int IdVenta { get; set; }
        public int IdCompra { get; set; }
        public int IdAlmacen { get; set; }
        public DateTime Periodo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdTipoMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public string Tipo { get; set; }

        public List<ValeDTDTO> ValeDetalles { get; set; }
    }
}
