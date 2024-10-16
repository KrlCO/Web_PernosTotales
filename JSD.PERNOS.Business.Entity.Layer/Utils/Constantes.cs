namespace JSD.SUNKU.Business.Entity.Layer.Utils
{
    public static class Policys
    {
        public const string Admin = "Admin";
        public const string Cliente = "Cliente";
        public const string Tecnico = "Tecnico";
        public const string Operador = "Operador";
        public const string OperadorOrAdmin = "OperadorOrAdmin";
        public const string ClienteOrTecnico = "ClienteOrTecnico";
        //public const string Administrador = "Administrador";
        //public const string Rechazadores = "Aprobadores";
        //public const string Reporteador = "Reporteador";
    }

    public static class Perfiles
    {
        public const string TECNICO = "T";
        public const string CLIENTE = "C";
        public const string OPERADOR = "O";
        //public const string FUL = "FUL";
        public const string ADMIN = "A";
    }

    public static class RegExp
    {
        public const string REG_EXP_UBIGEO = @"^\d{2}$";
    }

    public static class TipoArchivo
    {
        public const string ESPECIALIDAD = "E";
        public const string DNI = "D";
    }

    public enum StatusSolicitud
    {
        Pendiente = 1,
        Observado,
        Corregido,
        Homologado
    }

    public enum StatusOrden
    {
        Pendiente = 1,
        Revisado,
        Anulado,
        Terminado
    }

    public static class GrupoNotify
    {
        public const string OPERADOR = "O";
    }

    public enum TipoMensaje
    {
        SERVICIO_ASIGNADO = 1
    }

    public static class StatusEquipo
    {
        public const byte Optimo = 1;
        public const byte FaltaMto = 2;
    }

    public enum StatusReq
    {
        Pendiente = 1,
        Terminado,
        Anulado
    }


}
