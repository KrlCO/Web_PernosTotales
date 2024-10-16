using AutoMapper;
using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.SUNKU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Implementation
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly IUnidadMedidaRepository _unidadMedidaRepository;
        private readonly IMapper _mapper;

        public UnidadMedidaService(IUnidadMedidaRepository unidadMedidaRepository, IMapper mapper) =>(_unidadMedidaRepository, _mapper) = (unidadMedidaRepository, mapper);

        public IEnumerable<UnidadMedida> GetUnidadMedida() => _unidadMedidaRepository.GetUnidadMedida();

        public bool RegistrarUnidadMedida(UnidadMedida unidadMedida)
        {
            return _unidadMedidaRepository.RegistrarUnidadMedida(unidadMedida);
        }

        public Result<bool> EditarUnidadMedida(UnidadMedida unidadMedida)
        {
            var result = new Result<bool>();
            result.Resultado = _unidadMedidaRepository.EditarUnidadMedida(unidadMedida);
            return result;
        }

        public Result<bool> EliminarUnidadMedida(int id)
        {
            var result = new Result<bool>();
            result.Resultado = _unidadMedidaRepository.EliminarUnidadMedida(id);
            return result;
        }

    }
}
