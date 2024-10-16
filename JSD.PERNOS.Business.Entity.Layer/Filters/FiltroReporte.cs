using System;

namespace JSD.SUNKU.Business.Entity.Layer.Filters
{
    public class FiltroReporte
    {
        public int? IdEstado { get; set; }
        public string IdOficina { get; set; }
        public string IdArea { get; set; }
        public int? IdCargo { get; set; }
        public int? IdTipoViaje { get; set; }
        public int? IdTipoTransporte { get; set; }
        public int? IdTipoAbono { get; set; }
        public int? IdBanco { get; set; }
        public string NroDocSolicitante { get; set; }
        public string NroDocJefe { get; set; }
        public string NroDocGerente { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

    }
}
