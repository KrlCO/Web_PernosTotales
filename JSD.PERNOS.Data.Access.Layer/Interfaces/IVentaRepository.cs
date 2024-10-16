using JSD.PERNOS.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Interfaces
{
    public interface IVentaRepository
    {
        bool RegistrarVenta(VentasCB ventaCb, List<VentasDT> ventasDt, ValeCB valeCb, List<ValeDT> valeDt);

    }
}
