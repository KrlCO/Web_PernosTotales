using System;

namespace JSD.SUNKU.Business.Entity.Layer.Filters
{
    public class FiltroSolicitud
    {
        public string Funcionario { get; set; }
        public int? IdEstado { get; set; }
        public string CodigoSolicitud { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

    }
}
