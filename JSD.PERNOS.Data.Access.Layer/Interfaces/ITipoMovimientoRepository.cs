using JSD.PERNOS.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Interfaces
{
    public interface ITipoMovimientoRepository
    {

        IEnumerable<TipoMovimiento> ListarTipoMovimientosPorTipo(char tipo);
        IEnumerable<TipoMovimiento> ListarTipoMovimientos();

    }
}
