using AutoMapper;
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
    public class AlmacenService : IAlmacenService
    {
        private readonly IAlmacenRepositroy _almacenRepositroy;
        private readonly IMapper _mapper;

        public AlmacenService(IAlmacenRepositroy almacenRepository, IMapper mapper) => (_almacenRepositroy, _mapper) = (almacenRepository, mapper);

        public IEnumerable<AlmacenDTO> Listar()
        {
            var almacen = _almacenRepositroy.Listar();
            return _mapper.Map<IEnumerable<AlmacenDTO>>(almacen);
        }
    }
}
