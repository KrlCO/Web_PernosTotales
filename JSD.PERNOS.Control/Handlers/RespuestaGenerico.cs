namespace JSD.SUNKU.Control.Handlers
{
    class RespuestaGenerico
    {
    }

    public class RespuestaError
    {
        public RespuestaErrorDetalle error { get; set; }
    }

    public class RespuestaErrorDetalle
    {
        public string titulo { get; set; }
        public string codigo { get; set; }
        public string mensaje { get; set; }
    }
}
