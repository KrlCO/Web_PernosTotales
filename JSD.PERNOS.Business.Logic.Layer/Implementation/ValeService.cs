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
    public class ValeService : IValeService
    {
        private readonly IValeRepository _valeRepository;
        //agregar IMapper
        public ValeService(IValeRepository valeRepository)
        {
            _valeRepository = valeRepository;
        }

        public IEnumerable<ValeCBDTO> Listar(int? idAlmacen = null, int? idTipoMovimiento = null, string codigoVale = null, DateTime? fechaRegistro = null)
        {
            //obtener los resultados filtrados
            var vales = _valeRepository.Listar(idAlmacen, idTipoMovimiento, codigoVale, fechaRegistro);

            
            var result = vales.Select(vale => new ValeCBDTO
            {
                CodigoVale = vale.CodigoVale,
                TipoMovimiento = vale.TipoMovimiento,
                Tipo = vale.Tipo,
                FechaRegistro = vale.FechaRegistro
            });

            return result;
        }
    }

}
