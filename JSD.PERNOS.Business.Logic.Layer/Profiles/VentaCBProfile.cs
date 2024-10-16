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
    public class VentaCBProfile: Profile
    {
        public VentaCBProfile() {

            CreateMap<VentasCB, VentasCBDTO>().ReverseMap();
        }

    }
}
