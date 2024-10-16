
using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Web.Application.Pernos.Controllers
{
    public class TiendaController : Controller
    {

        private readonly IVentaService _ventaService;

        public TiendaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public IActionResult Carrito()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarVenta()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegistrarVenta([FromBody] VentaDTO venta)
        {
            try
            {
                var ventasCBDTO = new VentasCBDTO
                {
                    FechaVenta = DateTime.Now,
                    IdAlmacen = venta.IdAlmacen  
                };

                var ventasDTDTOs = venta.Carrito.Select(c => new VentasDTDTO
                {
                    IdProducto = c.IdProducto,
                    Cantidad = c.Cantidad,
                    Precio = c.Precio,
                    UsuarioRegistro = "Admin", 
                    FechaRegistro = DateTime.Now
                }).ToList();

                var valeCBDTO = new ValeCBDTO
                {
            
                Periodo = DateTime.Now,
                Tipo = "SALIDA"

                };

                var valeDTDTOs = ventasDTDTOs.Select(v => new ValeDTDTO
                {
                    IdProducto = v.IdProducto,
                    Cantidad = v.Cantidad,
                    Precio = v.Precio,
                    UsuarioRegistro = "Admin",
                    FechaRegistro = DateTime.Now
                }).ToList();

                var success = _ventaService.RegistrarVenta(ventasCBDTO, ventasDTDTOs, valeCBDTO, valeDTDTOs);

                if (success)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "No se pudo registrar la venta" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ConfirmacionPago()
        {
            return View();
        }

    }
}
