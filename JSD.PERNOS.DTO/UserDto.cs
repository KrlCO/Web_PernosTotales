namespace JSD.SUNKU.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public int? IdPersona { get; set; }
        public string CodUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string NomPerfil { get; set; }
        public string UserLogin { get; set; }
        public string Email { get; set; }
        public string TipoUser { get; set; }
    }
}
