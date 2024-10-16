using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.DTO
{
    public class CompraCBDTO
    {
        public int IdCompraCB { get; set; }
        public int IdAlmacen { get; set; }
        public string RUC { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public DateTime FechaCompra { get; set; }

        public List<CompraDTDTO> ComprasDetalles { get; set; }
    }
}
