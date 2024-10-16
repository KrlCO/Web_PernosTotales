using JSD.PERNOS.Business.Entity.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Data.Access.Layer.Interfaces
{
    public interface ICompraRepository
    {

        bool RegistrarCompra(CompraCB compraCb, List<CompraDT> compraDT, ValeCB valeCb, List<ValeDT> valeDT);

    }
}
