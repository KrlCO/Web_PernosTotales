using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Implementation
{
    public class UnidadMedidaRepository : BaseRepository, IUnidadMedidaRepository
    {
        public UnidadMedidaRepository(DataProtector dataProtector) : base(dataProtector)
        {
        }

        public IEnumerable<UnidadMedida> GetUnidadMedida()
        {
            return GetEntities<UnidadMedida>("usp_Listar_UnidadMedida");
        }

        //public IEnumerable<UnidadMedida> GetUnidadMedida(int id)
        //{
        //    var parameters = new SqlParameter[]
        //    {
        //        new("@IdUnidadMedida", SqlDbType.Int){Value = id}
        //    };
        //    return GetEntities<UnidadMedida>("usp_Listar_UnidadMedida", parameters);
        //}

        public bool RegistrarUnidadMedida(UnidadMedida unidadMedida)
        {
            return ExecuteProcedureCRUD("usp_Registrar_UnidadMedida", new SqlParameter[]
            {
                new("@Nombre",SqlDbType.VarChar, 250){Value = unidadMedida.IdUnidadMedida},
                new("@Descripcion", SqlDbType.VarChar, 250){Value = unidadMedida.Descripcion},
                new("@Estado", SqlDbType.Bit){Value = unidadMedida.Estado}
 
            });
        }

        public bool EditarUnidadMedida(UnidadMedida unidadMedida)
        {
            var parameters = new SqlParameter[]
            {
                new("@IdUnidadMedida", SqlDbType.Int){Value = unidadMedida.IdUnidadMedida},
                new("@Nombre",SqlDbType.VarChar, 250){Value = unidadMedida.IdUnidadMedida},
                new("@Descripcion", SqlDbType.VarChar, 250){Value = unidadMedida.Descripcion},
                new("@Estado", SqlDbType.Bit){Value = unidadMedida.Estado}
            };
            return ExecuteProcedureCRUD("usp_Actualizar_UnidadMedida", parameters);
        }

        public bool EliminarUnidadMedida(int id)
        {
            var parameters = new SqlParameter[]
            {
                new("@IdUnidadMedida", SqlDbType.Int){Value = id}
            };
            return ExecuteProcedureCRUD("usp_Eliminar_UnidadMedida", parameters);
        }

        
    }
}
