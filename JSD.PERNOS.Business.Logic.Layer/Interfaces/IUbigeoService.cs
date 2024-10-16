using JSD.SUNKU.Business.Entity.Layer;
using System.Collections.Generic;

namespace JSD.SUNKU.Business.Logic.Layer.Interfaces
{
    public interface IUbigeoService
    {
        IEnumerable<Ubigeo> GetDepartamentos();
        IEnumerable<Ubigeo> GetProvincias(string codDepa);
        IEnumerable<Ubigeo> GetDistritos(string codDepa, string codProv);
    }
}
