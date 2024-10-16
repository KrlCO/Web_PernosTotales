using JSD.PERNOS.Business.Entity.Layer;
using JSD.SUNKU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetCategoria();
        bool RegistrarCategoria(Categoria categoria);
        Result<bool> EditarCategoria(Categoria categoria);
        Result<bool> EliminarCategoria(int id);

    }
}
