using AutoMapper;
using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Profiles
{
    internal class ValeProfile: Profile
    {
        public ValeProfile()
        {
            CreateMap<ValeCB, ValeCBDTO>().ReverseMap();
            CreateMap<Almacen, AlmacenDTO>().ReverseMap();
            CreateMap<TipoMovimiento, TipoMovimientoDTO>().ReverseMap();
        }

    }
}
