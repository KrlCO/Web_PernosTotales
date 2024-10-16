using System;

namespace JSD.SUNKU.Control.DTO
{
    public class AccessDTO
    {
        public string CorreoElectronico { get; set; }
        public string NombreUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
        public string Perfil { get; set; }
    }
}
