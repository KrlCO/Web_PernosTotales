using JSD.PERNOS.DTO;

namespace Web.Application.Pernos.Models
{
    public class VentaViewModel
    {
        public string? NombreTitular { get; set; }
        public string? NumeroTarjeta { get; set; }
        public string? FechaExpiracion { get; set; }
        public string? CVV { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Envio { get; set; }
        public decimal Total { get; set; }
        public List<ProductoDTO>? Carrito { get; set; }
    }
}
