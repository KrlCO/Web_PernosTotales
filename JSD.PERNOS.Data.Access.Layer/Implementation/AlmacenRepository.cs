using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Implementation
{
    public class AlmacenRepository : BaseRepository, IAlmacenRepositroy
    {
        public AlmacenRepository(DataProtector dataProtector) : base(dataProtector)
        {
        }

        public IEnumerable<Almacen> Listar()
        {
            
            return GetEntities<Almacen>("usp_Listar_Almacenes");
        }
    }
}
