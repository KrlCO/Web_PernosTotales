using JSD.PERNOS.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Interfaces
{
    public interface ICategoriaRepository
    {

        IEnumerable<Categoria> GetCategoria();
        bool RegistrarCategoria(Categoria categoria);
        bool EditarCategoria(Categoria categoria);
        bool EliminarCategoria(int id);

    }
}
