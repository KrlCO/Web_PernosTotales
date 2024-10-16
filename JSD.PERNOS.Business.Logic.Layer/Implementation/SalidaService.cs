using AutoMapper;
using JSD.PERNOS.Business.Entity.Layer;
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
    public class SalidaService : ISalidaService
    {
        public readonly ISalidaRepository _salidaRepository;
        public readonly IMapper _mapper;

        public SalidaService(ISalidaRepository salidaRepository, IMapper mapper)
        {
            _salidaRepository = salidaRepository;
            _mapper = mapper;
        }
        public bool RegistrarSalida(VentasCBDTO ventasCBDTO, List<VentasDTDTO> ventasDTDTO, ValeCBDTO valeCbdto, List<ValeDTDTO> valeDTdto)
        {
            var salidacb = _mapper.Map<VentasCB>(ventasCBDTO);
            var salidadt = _mapper.Map<List<VentasDT>>(ventasDTDTO);
            var valecb = _mapper.Map<ValeCB>(valeCbdto);
            var valedt = _mapper.Map<List<ValeDT>>(valeDTdto);
            return _salidaRepository.RegistrarSalida(salidacb, salidadt, valecb, valedt);
        }
    }
}
