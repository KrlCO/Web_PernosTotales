namespace Web.Application.Pernos.Models
{
    public class CompraViewModel
    {
        public int IdAlmacen { get; set; }
        public string RUC { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }

        public List<DetalleCompraViewModel> Detalles { get; set; } = new List<DetalleCompraViewModel>();
    }

    public class DetalleCompraViewModel
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }

}
