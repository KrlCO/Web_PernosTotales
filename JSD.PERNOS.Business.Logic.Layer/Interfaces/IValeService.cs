using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Interfaces
{
    public interface IValeService
    {

        IEnumerable<ValeCBDTO> Listar(int? idAlmacen = null, int? idTipoMovimiento = null, string codigoVale = null, DateTime? fechaRegistro = null);

    }
}
