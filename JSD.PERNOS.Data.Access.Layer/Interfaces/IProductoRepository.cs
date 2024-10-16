using JSD.PERNOS.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Interfaces
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> Listar();
        Producto GetProductoById(int id);
        Categoria GetCategoria(int id);
        UnidadMedida GetUnidadMedida(int id);
        bool RegistrarProducto(Producto producto);
        bool EditarProducto(Producto producto);
        bool EliminarProducto(int id);
        IEnumerable<Producto> BuscarProductoPorNombre(string nombre);
        IEnumerable<Producto> GetTopProductos();
        IEnumerable<Categoria>GetCategorias();
        IEnumerable<UnidadMedida> GetUnidadesMedidas();

    }
}
