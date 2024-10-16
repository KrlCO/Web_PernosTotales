using JSD.PERNOS.Data.Access.Layer.Implementation;
using JSD.PERNOS.Data.Access.Layer.Utils;
using JSD.SUNKU.Business.Entity.Layer;
using JSD.SUNKU.Data.Access.Layer.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JSD.SUNKU.Data.Access.Layer.Implementation
{
    public class UbigeoRepository : BaseRepository, IUbigeoRepository
    {
        public UbigeoRepository(DataProtector dataProtector) : base(dataProtector) { }

        public IEnumerable<Ubigeo> GetDepartamentos()
        {
            return GetEntities<Ubigeo>("GET_DEPARTAMENTOS");
        }

        public IEnumerable<Ubigeo> GetProvincias(string codDepa)
        {
            var parameters = new SqlParameter[]
            {
                new("@CodDepa", SqlDbType.Char, 2){ Value = codDepa}
            };
            return GetEntities<Ubigeo>("GET_PROVINCIAS", parameters);
        }

        public IEnumerable<Ubigeo> GetDitritos(string codDepa, string codProv)
        {
            var parameters = new SqlParameter[]
            {
                new("@CodDepa", SqlDbType.Char, 2){ Value = codDepa},
                new("@CodProv", SqlDbType.Char, 2){ Value = codProv}
            };
            return GetEntities<Ubigeo>("GET_DISTRITOS", parameters);
        }


    }
}
