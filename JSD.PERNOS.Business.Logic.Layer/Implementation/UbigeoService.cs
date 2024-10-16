using AutoMapper;
using JSD.SUNKU.Business.Entity.Layer;
using JSD.SUNKU.Business.Logic.Layer.Interfaces;
using JSD.SUNKU.Data.Access.Layer.Interfaces;
using System.Collections.Generic;

namespace JSD.SUNKU.Business.Logic.Layer.Implementation
{
    public class UbigeoService : IUbigeoService
    {
        private readonly IUbigeoRepository _ubigeoRepository;
        private readonly IMapper _mapper;

        public UbigeoService(IUbigeoRepository UbigeoRepository, IMapper mapper)
            => (_ubigeoRepository, _mapper) = (UbigeoRepository, mapper);

        public IEnumerable<Ubigeo> GetDepartamentos() => _ubigeoRepository.GetDepartamentos();

        public IEnumerable<Ubigeo> GetProvincias(string codDepa)
            => _ubigeoRepository.GetProvincias(codDepa);

        public IEnumerable<Ubigeo> GetDistritos(string codDepa, string codProv)
            => _ubigeoRepository.GetDitritos(codDepa, codProv);

    }
}
