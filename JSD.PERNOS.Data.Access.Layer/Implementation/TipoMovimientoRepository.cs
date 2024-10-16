using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Implementation
{
    public class TipoMovimientoRepository : BaseRepository, ITipoMovimientoRepository
    {
        public TipoMovimientoRepository(DataProtector dataProtector) : base(dataProtector)
        {
        }

        public IEnumerable<TipoMovimiento> ListarTipoMovimientos()
        {
            return GetEntities<TipoMovimiento>("usp_Listar_TiposMovimientos");
        }

        public IEnumerable<TipoMovimiento> ListarTipoMovimientosPorTipo(char tipo)
        {
            var parameters = new SqlParameter[]
            {
            new SqlParameter("@Tipo", SqlDbType.Char) { Value = tipo }
            };
            return GetEntities<TipoMovimiento>("usp_Listar_TipoMovimiento", parameters);
        }
    }
}
