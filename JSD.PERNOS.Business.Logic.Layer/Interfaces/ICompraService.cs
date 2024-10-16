using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Interfaces
{
    public interface ICompraService
    {

        bool RegistrarCompra(CompraCBDTO compraCbdto, List<CompraDTDTO> compraDTdto, ValeCBDTO valeCbdto, List<ValeDTDTO> valeDTdto);

    }
}
