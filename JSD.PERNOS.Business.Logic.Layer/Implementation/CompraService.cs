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
    public class CompraService : ICompraService
    {
        public readonly ICompraRepository _compraRepository;
        public readonly IMapper _mapper;

        public CompraService(ICompraRepository compraRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        public bool RegistrarCompra(CompraCBDTO compraCbdto, List<CompraDTDTO> compraDTdto, ValeCBDTO valeCbdto, List<ValeDTDTO> valeDTdto)
        {
            var compracb = _mapper.Map<CompraCB>(compraCbdto);
            var compradt = _mapper.Map<List<CompraDT>>(compraDTdto);
            var valecb = _mapper.Map<ValeCB>(valeCbdto);
            var valedt = _mapper.Map<List<ValeDT>>(valeDTdto);
            return _compraRepository.RegistrarCompra(compracb, compradt, valecb, valedt);
        }
    }
}
