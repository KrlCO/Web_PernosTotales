using System;
using System.Collections.Generic;

namespace JSD.SUNKU.DTO
{
    public class CabeOSDto
    {
        public int? Id { get; set; }
        public string IdFormat => $"OS{Id:D6}";
        public int IdCliente { get; set; }
        public string CodDepa { get; set; }
        public string CodProv { get; set; }
        public string CodDist { get; set; }
        public string Ruc { get; set; }
        public string Cliente { get; set; }
        public int IdTecnico { get; set; }
        public string DNI { get; set; }
        public string Tecnico { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public byte CodEstado { get; set; }
        public string Estado { get; set; }
        public DateTime FecRegistra { get; set; }
        public List<DetaOSDto> Requerimientos { get; set; }

        //REPORTE
        public string Equipos { get; set; }
        public string Anotaciones { get; set; }
        public decimal Presupuesto { get; set; }
    }

    public class DetaOSDto
    {
        public int? Id { get; set; }
        public int IdOS { get; set; }
        public int? IdRequerimiento { get; set; }
        public string IdFormat => $"REQ{IdRequerimiento:D6}";
        public int IdEquipo { get; set; }
        public string NomEquipo { get; set; }
        public byte CodEstado { get; set; }
        public bool Chekeado { get; set; }
        public DateTime FecRegistra { get; set; }
        public int? IdAnotacion { get; set; }
        public string Anotacion { get; set; }
    }
}
