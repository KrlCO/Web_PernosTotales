using System;

namespace JSD.SUNKU.Business.Entity.Layer
{
    public class Usuario
    {
        public int Id { get; set; }
        public int? IdPersona { get; set; }
        public string TipoUser { get; set; }
        public string CodUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string NroContacto { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PassUser { get; set; }
        public string Estado { get; set; }
        public string UsrRegistra { get; set; }
        public DateTime? FecRegistra { get; set; }
        public string UsrModifica { get; set; }
        public DateTime? FecModifica { get; set; }
    }
}
