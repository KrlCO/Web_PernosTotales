using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.DTO;
using JSD.SUNKU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JSD.PERNOS.Business.Logic.Layer.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<ProductoDTO> Listar();
        ProductoDTO GetProductoById(int id);
        bool RegistrarProducto(ProductoDTO productoDto);
        Result<bool> EditarProducto(ProductoDTO productoDto);
        Result<bool> EliminarProducto(int id);
        IEnumerable<ProductoDTO> BuscarProductoPorNombre(string nombre);
        IEnumerable<ProductoDTO> GetTopProductos();
        IEnumerable<ProductoDTO> GetProductosPaginados(string nombreProducto, int page, int pageSize, out int totalProductos);

        IEnumerable<CategoriaDTO> GetCategorias();
        IEnumerable<UnidadMedidaDTO> GetUnidadesMedidas();


    }
}
