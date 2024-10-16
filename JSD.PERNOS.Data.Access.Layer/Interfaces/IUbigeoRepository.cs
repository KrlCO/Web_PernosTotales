using JSD.SUNKU.Business.Entity.Layer;
using System.Collections.Generic;

namespace JSD.SUNKU.Data.Access.Layer.Interfaces
{
    public interface IUbigeoRepository
    {
        IEnumerable<Ubigeo> GetDepartamentos();
        IEnumerable<Ubigeo> GetProvincias(string codDepa);
        IEnumerable<Ubigeo> GetDitritos(string codDepa, string codProv);
    }
}
