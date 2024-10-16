using JSD.PERNOS.Business.Entity.Layer;
using JSD.SUNKU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Interfaces
{
    public interface IUnidadMedidaService
    {
        IEnumerable<UnidadMedida> GetUnidadMedida();
        bool RegistrarUnidadMedida(UnidadMedida unidadMedida);
        Result<bool> EditarUnidadMedida(UnidadMedida unidadMedida);
        Result<bool> EliminarUnidadMedida(int id);

    }
}
