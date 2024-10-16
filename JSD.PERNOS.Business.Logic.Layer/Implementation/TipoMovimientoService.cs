using AutoMapper;
using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Implementation;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Implementation
{
    public class TipoMovimientoService : ITipoMovimientoService
    {
        private readonly ITipoMovimientoRepository _tipoMovimientorepository;
        private readonly IMapper _mapper;

        public TipoMovimientoService(ITipoMovimientoRepository tipoMovimientoRepository, IMapper mapper)
        {
            _tipoMovimientorepository = tipoMovimientoRepository;
            _mapper = mapper;
        }

        public IEnumerable<TipoMovimientoDTO> ListarTipoMovimientos()
        {
            var tipoMovimiento = _tipoMovimientorepository.ListarTipoMovimientos();
            return _mapper.Map<IEnumerable<TipoMovimientoDTO>>(tipoMovimiento);
        }

        public IEnumerable<TipoMovimientoDTO> ListarTipoMovimientosPorTipo(char tipo)
        {
            var tiposMovimientos = _tipoMovimientorepository.ListarTipoMovimientosPorTipo(tipo);
            return _mapper.Map<IEnumerable<TipoMovimientoDTO>>(tiposMovimientos);
        }
    }
}
