using JSD.PERNOS.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Interfaces
{
    public interface ISalidaRepository
    {
        bool RegistrarSalida(VentasCB ventaCb, List<VentasDT> ventasDT, ValeCB valeCb, List<ValeDT> valeDT);
    }
}
