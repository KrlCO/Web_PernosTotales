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
    public class CompraProfile: Profile
    {
        public CompraProfile() 
        {
            CreateMap<CompraCB, CompraCBDTO>().ReverseMap(); 
            CreateMap<CompraDT, CompraDTDTO>().ReverseMap(); 
            CreateMap<ValeCB, ValeCBDTO>().ReverseMap();
            CreateMap<ValeDT, ValeDTDTO>().ReverseMap();
        }

    }
}
