using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Utils;
using JSD.SUNKU.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Implementation
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        public CategoriaRepository(DataProtector dataProtector) : base(dataProtector)
        {
        }

        public IEnumerable<Categoria> GetCategoria()
        {
            return GetEntities<Categoria>("usp_Listar_Categoria");
        }

        public bool RegistrarCategoria(Categoria categoria)
        {
            return ExecuteProcedureCRUD("usp_Registrar_Categoria", new SqlParameter[]
            {
                new("@Nombre", SqlDbType.VarChar, 250){Value = categoria.Nombre},
                new("@Descripcion", SqlDbType.VarChar, 250){Value = categoria.Descripcion},
                new("@Estado", SqlDbType.Bit){Value = categoria.Estado}
            });
        }

        public bool EditarCategoria(Categoria categoria)
        {
            var parameters = new SqlParameter[]
            {
                new("@Idcategoria", SqlDbType.Int){Value = categoria.IdCategoria},
                new("@Nombre", SqlDbType.VarChar, 250){Value = categoria.Nombre},
                new("@Descripcion", SqlDbType.VarChar, 250){Value = categoria.Descripcion},
                new("@Estado", SqlDbType.Bit){Value = categoria.Estado}
            };
            return ExecuteProcedureCRUD("usp_Actualizar_Categoria", parameters);
        }

        public bool EliminarCategoria(int id)
        {
            var parameters = new SqlParameter[]
            {
                new("@Idcategoria", SqlDbType.Int){Value=id}
            };
            return ExecuteProcedureCRUD("usp_Eliminar_Categoria", parameters);
        }


    }
}
