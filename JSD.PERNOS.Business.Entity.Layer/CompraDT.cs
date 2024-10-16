using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Entity.Layer
{
    public class CompraDT
    {
        public int IdCompraDT { get; set; }
        public int IdCompraCB { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string UsuarioRegistro { set; get; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual CompraCB CompraCB { get; set; }
    }
}
