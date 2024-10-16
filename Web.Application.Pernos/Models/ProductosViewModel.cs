using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Application.Pernos.Models
{
    public class ProductosViewModel
    {
        public IEnumerable<ProductoViewModel>? Productos { get; set; }
        public IEnumerable<ProductoViewModel>? TodosLosProductos { get; set; }
        public IEnumerable<ProductoViewModel>? TopProductos { get; set; }
        public int TotalProductos { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public string? NombreProducto { get; set; }

    }

    public class ProductoViewModel
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        //Propiedad para ver Nombre de la Cate
        public string? CategoriaNombre { get; set; }
        public int IdUnidadMedida { get; set; }
        //Propiedad para ver Nombre de la UnMed
        public string? UnidadMedidaNombre { get; set; }
        public string? Nombre { get; set; }     
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        //public string? CodigoUnico { get; set; }
        public bool Estado { get; set; }
        public string? ImagenRuta { get; set; }

        public string? UsuarioModificacion { get; set; }
        public IFormFile? Imagen { get; set; }

    }
}
