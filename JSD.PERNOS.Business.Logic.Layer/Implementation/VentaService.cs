using AutoMapper;
using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Implementation
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public VentaService(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        public bool RegistrarVenta(VentasCBDTO ventaCbDto, List<VentasDTDTO> ventasDtDto, ValeCBDTO valeCbDto, List<ValeDTDTO> valeDtDto)
        {
            var ventacb = _mapper.Map<VentasCB>(ventaCbDto);
            var ventadt = _mapper.Map<List<VentasDT>>(ventasDtDto);
            var valecb = _mapper.Map<ValeCB>(valeCbDto);
            var valedt = _mapper.Map<List<ValeDT>>(valeDtDto);
            return _ventaRepository.RegistrarVenta(ventacb, ventadt, valecb, valedt);
        }
    }
}
