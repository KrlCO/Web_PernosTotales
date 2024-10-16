using System.Collections.Generic;

namespace JSD.SUNKU.Business.Entity.Layer.Filters
{
    public class FilterTecnico
    {
        public byte? IdEspecialidad { get; set; }
        public List<int> Areas { get; set; }
        public string CodUbigeo { get; set; }
    }
}
