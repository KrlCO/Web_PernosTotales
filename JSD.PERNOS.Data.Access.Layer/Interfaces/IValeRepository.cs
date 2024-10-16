using JSD.PERNOS.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Interfaces
{
    public interface IValeRepository
    {
        IEnumerable<ValeCB> Listar(int? idAlmacen = null, int? idTipoMovimiento = null, string codigoVale = null, DateTime? fechaRegistro = null);


    }
}
