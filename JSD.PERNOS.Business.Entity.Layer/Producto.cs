using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Entity.Layer
{
    public class Producto
    {

        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public int IdUnidadMedida { get; set; }
        public string Nombre {get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal CostoPromedio { get; set; }
        public string CodigoUnico { get; set; }
        public bool Estado { get; set; }
        public IFormFile Imagen { get; set; }
        public string ImagenRuta { get; set; }

        // Propiedades para almacenar los nombres de Categoria y UnidadMedida
        public string CategoriaNombre { get; set; }
        public string UnidadMedidaNombre { get; set; }

        // Campos de auditoría, no se mostrarán al usuario
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

    }


}
