using JSD.PERNOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Interfaces
{
    public interface ISalidaService
    {
        bool RegistrarSalida(VentasCBDTO ventasCBDTO, List<VentasDTDTO> ventasDTDTO, ValeCBDTO valeCbdto, List<ValeDTDTO> valeDTdto);
    }
}
