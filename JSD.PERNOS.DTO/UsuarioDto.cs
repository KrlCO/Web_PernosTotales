using System;
using System.Collections.Generic;

namespace JSD.SUNKU.DTO
{
    public class UsuarioDto
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
        public string PassUser { get; set; }
    }

    public class UsuarioPasswordDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
