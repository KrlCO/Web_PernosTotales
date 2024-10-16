using JSD.PERNOS.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Interfaces
{
    public interface IUnidadMedidaRepository
    {
        IEnumerable<UnidadMedida> GetUnidadMedida();
        bool RegistrarUnidadMedida(UnidadMedida unidadMedida);
        bool EditarUnidadMedida(UnidadMedida unidadMedida);
        bool EliminarUnidadMedida(int id);

    }
}
