using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JSD.PERNOS.Data.Access.Layer.Implementation
{
    public class ProductoRepository : BaseRepository, IProductoRepository
    {

        public ProductoRepository(DataProtector dataProtector) : base(dataProtector){}

        public IEnumerable<Producto> Listar()
        {
            return GetEntities<Producto>("usp_Listar_Productos");
        }

        Producto IProductoRepository.GetProductoById(int id)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@IdProducto", SqlDbType.Int) { Value = id }
            };
            return GetEntity<Producto>("usp_Listar_Productos", parameters);
        }

        public Categoria GetCategoria(int id)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@IdCategoria", SqlDbType.Int) { Value = id }
            };
            return GetEntity<Categoria>("usp_Listar_Categoria_Por_Id", parameters);
        }

        public UnidadMedida GetUnidadMedida(int id)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@IdUnidadMedida", SqlDbType.Int) { Value = id }
            };
            return GetEntity<UnidadMedida>("usp_Listar_UnidadMedida_Por_Id", parameters);
        }

        public bool RegistrarProducto(Producto producto)
        {
            var parameters = new SqlParameter[]
            {
                new("@IdCategoria", SqlDbType.Int) { Value = producto.IdCategoria },
                new("@IdUnidadMedida", SqlDbType.Int) { Value = producto.IdUnidadMedida },
                new("@Nombre", SqlDbType.VarChar, 250) { Value = producto.Nombre },
                new("@Descripcion", SqlDbType.VarChar, 250) { Value = producto.Descripcion },
                new("@Stock", SqlDbType.Int) { Value = producto.Stock },
                new("@PrecioCompra", SqlDbType.Decimal) { Value = producto.PrecioCompra },
                new("@PrecioVenta", SqlDbType.Decimal) { Value = producto.PrecioVenta },
                new("@Estado", SqlDbType.Bit) { Value = producto.Estado },
                new("@ImagenRuta", SqlDbType.VarChar, 255) { Value = producto.ImagenRuta }
            };
            return ExecuteProcedureCRUD("usp_Registrar_Producto", parameters);
        }

        public bool EditarProducto(Producto producto)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@IdProducto", SqlDbType.Int) { Value = producto.IdProducto },
                new SqlParameter("@IdCategoria", SqlDbType.Int) { Value = producto.IdCategoria },
                new SqlParameter("@IdUnidadMedida", SqlDbType.Int) { Value = producto.IdUnidadMedida },
                new SqlParameter("@Nombre", SqlDbType.VarChar, 250) { Value = producto.Nombre },
                new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = producto.Descripcion },
                new SqlParameter("@Stock", SqlDbType.Int) { Value = producto.Stock },
                new SqlParameter("@PrecioCompra", SqlDbType.Decimal) { Value = producto.PrecioCompra },
                new SqlParameter("@PrecioVenta", SqlDbType.Decimal) { Value = producto.PrecioVenta },
                new SqlParameter("@Estado", SqlDbType.Bit) { Value = producto.Estado },
                new SqlParameter("@UsuarioModificacion", SqlDbType.VarChar, 50) { Value = producto.UsuarioModificacion},
                new SqlParameter("@ImagenRuta", SqlDbType.VarChar, 255) { Value = producto.ImagenRuta ?? string.Empty }

            };

            return ExecuteProcedureCRUD("usp_Actualizar_Producto", parameters);
        }


        public bool EliminarProducto(int id)
        {
            var parameters = new SqlParameter[]
            {
                new("@IdProducto", SqlDbType.Int){Value = id}
            };
            return ExecuteProcedureCRUD("usp_Eliminar_Producto", parameters);
        }

        public IEnumerable<Producto> BuscarProductoPorNombre(string nombre)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", SqlDbType.VarChar, 250) { Value = nombre }
            };
            return GetEntities<Producto>("usp_Buscar_Producto_Por_Nombre", parameters);
        }

        public IEnumerable<Producto> GetTopProductos()
        {
            return GetEntities<Producto>("usp_Productos_Mas_Vendidos");
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return GetEntities<Categoria>("usp_Listar_Categoria");
        }

        public IEnumerable<UnidadMedida> GetUnidadesMedidas()
        {
            return GetEntities<UnidadMedida>("usp_Listar_UnidadMedida");
        }

    }
}
