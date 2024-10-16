using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Business.Logic.Layer.Implementation;
using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Pernos.Models;

namespace Web.Application.Pernos.Controllers
{
    public class AlmacenController : Controller
    {
        private readonly IValeService _valeService;
        private readonly ITipoMovimientoService _tipoMovimientoService;
        private readonly IAlmacenService _almacenService;
        private readonly IProductoService _productoService;
        private readonly ICompraService _compraService;
        private readonly IVentaService _ventaService;
        private readonly ISalidaService _salidaService;

        public AlmacenController(IValeService valeService, ITipoMovimientoService tipoMovimientoService, IAlmacenService almacenService, IProductoService productoService, ICompraService compraService, IVentaService ventaService, ISalidaService salidaService)
        {
            _valeService = valeService;
            _tipoMovimientoService = tipoMovimientoService;
            _almacenService = almacenService;
            _productoService = productoService;
            _compraService = compraService;
            _ventaService = ventaService;
            _salidaService = salidaService;
        }

        [HttpGet]
        public IActionResult Vales()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ListarVales(int? idAlmacen, int? idTipoMovimiento, string codigoVale, DateTime? fechaRegistro)
        {
            try
            {
                var vales = _valeService.Listar(idAlmacen, idTipoMovimiento, codigoVale, fechaRegistro);

                var result = new
                {
                    data = vales.Select(vale => new
                    {
                        CodigoVale = vale.CodigoVale,
                        TipoMovimiento = vale.TipoMovimiento,
                        Tipo = vale.Tipo,
                        FechaRegistro = vale.FechaRegistro.ToString("yyyy-MM-dd")
                    }).ToList()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                
                return Json(new { error = ex.Message });
            }
        }

        public IActionResult ValeSalida()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerTiposMovimiento(string tipo)
        {
            try
            {
                char tipoChar = !string.IsNullOrEmpty(tipo) ? tipo[0] : ' ';
                var tiposMovimiento = _tipoMovimientoService.ListarTipoMovimientosPorTipo(tipoChar);

                return Json(tiposMovimiento);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return Json(new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ListarTiposMovimiento()
        {
            try
            {
                var tiposMovimiento = _tipoMovimientoService.ListarTipoMovimientos();
                var tiposMovimientoDto = tiposMovimiento.Select(t => new
                {
                    idTipoMovimiento = t.IdTipoMovimiento,
                    tipoMovimiento = t.TipoMovimiento,
                }).ToList();
                return Json(tiposMovimiento);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult ObtenerAlmacenes()
        {
            try
            {
                var almacenes = _almacenService.Listar(); // Asegúrate de que este método retorne una lista de almacenes.
                var almacenesDTO = almacenes.Select(a => new
                {
                    idAlmacen = a.IdAlmacen,
                    nombreAlmacen = a.NombreAlmacen
                }).ToList();

                return Json(almacenesDTO);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        [HttpGet]
        public JsonResult ObtenerProductos()
        {
            try
            {
                var productos = _productoService.Listar(); // Obtener la lista de productos
                return Json(productos.Select(p => new
                {
                    p.IdProducto,
                    p.Nombre,
                    p.CategoriaNombre,
                    p.UnidadMedidaNombre,
                    p.Stock,
                    p.PrecioCompra,
                    p.Estado
                }));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult RegistrarCompra()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarCompra([FromBody] CompraDTO compraDTO)
        {
            try
            {

                // Crear DTOs para CompraCB y CompraDT
                var compraCBDTO = new CompraCBDTO
                {
                    IdAlmacen = compraDTO.IdAlmacen,
                    FechaCompra = DateTime.Now,
                };

                var compraDTDTO = compraDTO.detalleCompra.Select(d => new CompraDTDTO
                {
                    IdProducto = d.IdProducto,
                    Cantidad = d.Cantidad,
                    Precio = d.Precio,
                    UsuarioRegistro = "Admin",
                    FechaRegistro = DateTime.Now
                }).ToList();

                // Crear DTOs para ValeCB y ValeDT
                var valeCBDTO = new ValeCBDTO
                {
                    Periodo = DateTime.Now,
                    Tipo = "ENTRADA",
                    IdAlmacen = compraDTO.IdAlmacen,
                    IdTipoMovimiento = compraDTO.IdTipoMovimiento,
                    FechaRegistro = DateTime.Now
                };

                var valeDTDTOs = compraDTDTO.Select(c => new ValeDTDTO
                {
                    IdProducto = c.IdProducto,
                    Cantidad = c.Cantidad,
                    Precio = c.Precio,
                    UsuarioRegistro = "Admin",
                    FechaRegistro = DateTime.Now
                }).ToList();

                // Registrar la compra
                var success = _compraService.RegistrarCompra(compraCBDTO, compraDTDTO, valeCBDTO, valeDTDTOs);

                if (success)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "No se pudo registrar la compra" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ConfirmacionCompra()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RegistrarValeSalida()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarValeSalida([FromBody] SalidaDTO salidaDto)
        {
            try
            {

                // Crear DTOs para CompraCB y CompraDT
                var ventaCBDTO = new VentasCBDTO
                {
                    IdAlmacen = salidaDto.IdAlmacen,
                    FechaVenta = DateTime.Now,
                };

                var ventaDTDTO = salidaDto.detalleSalida.Select(d => new VentasDTDTO
                {
                    IdProducto = d.IdProducto,
                    Cantidad = d.Cantidad,
                    Precio = d.Precio,
                    UsuarioRegistro = "Admin",
                    FechaRegistro = DateTime.Now
                }).ToList();

                // Crear DTOs para ValeCB y ValeDT
                var valeCBDTO = new ValeCBDTO
                {
                    Periodo = DateTime.Now,
                    Tipo = "SALIDA",
                    IdAlmacen = salidaDto.IdAlmacen,
                    IdTipoMovimiento = salidaDto.IdTipoMovimiento,
                    FechaRegistro = DateTime.Now
                };

                var valeDTDTOs = ventaDTDTO.Select(c => new ValeDTDTO
                {
                    IdProducto = c.IdProducto,
                    Cantidad = c.Cantidad,
                    Precio = c.Precio,
                    UsuarioRegistro = "Admin",
                    FechaRegistro = DateTime.Now
                }).ToList();

                // Registrar el vale de salida
                var success = _salidaService.RegistrarSalida(ventaCBDTO, ventaDTDTO, valeCBDTO, valeDTDTOs);

                if (success)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "No se pudo registrar el vale de salida" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult RegistrarCompras()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult RegistrarCompras(CompraViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var transaction = _context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                // Insertar la cabecera de la compra
        //                var compraCB = new ComprasCB
        //                {
        //                    IdAlmacen = model.IdAlmacen,
        //                    RUC = model.RUC,
        //                    Nombre = model.Nombre,
        //                    RazonSocial = model.RazonSocial,
        //                    Direccion = model.Direccion,
        //                    Telefono = model.Telefono,
        //                    Contacto = model.Contacto,
        //                    FechaCompra = DateTime.Now
        //                };
        //                _context.ComprasCB.Add(compraCB);
        //                _context.SaveChanges();

        //                // Insertar los detalles de la compra
        //                foreach (var detalle in model.Detalles)
        //                {
        //                    var compraDT = new ComprasDT
        //                    {
        //                        IdCompraCB = compraCB.IdCompraCB,
        //                        IdProducto = detalle.IdProducto,
        //                        Cantidad = detalle.Cantidad,
        //                        Precio = detalle.Precio
        //                    };
        //                    _context.ComprasDT.Add(compraDT);

        //                    // Actualizar el stock y el precio promedio en Productos
        //                    var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == detalle.IdProducto);
        //                    if (producto != null)
        //                    {
        //                        int stockAnterior = producto.Stock;
        //                        producto.Stock += detalle.Cantidad;
        //                        producto.PrecioCompra = ((producto.PrecioCompra * stockAnterior) + (detalle.Precio * detalle.Cantidad)) / producto.Stock;
        //                    }
        //                }
        //                _context.SaveChanges();

        //                // Registrar el vale de entrada
        //                var valeCB = new ValeCB
        //                {
        //                    IdCompra = compraCB.IdCompraCB,
        //                    IdAlmacen = model.IdAlmacen,
        //                    Periodo = DateTime.Now,
        //                    Tipo = "ENTRADA",
        //                    IdTipoMovimiento = 1 // Suponiendo que "1" representa el movimiento de entrada
        //                };
        //                _context.ValeCB.Add(valeCB);
        //                _context.SaveChanges();

        //                foreach (var detalle in model.Detalles)
        //                {
        //                    var valeDT = new ValeDT
        //                    {
        //                        IdVale = valeCB.IdValeCB,
        //                        IdProducto = detalle.IdProducto,
        //                        Cantidad = detalle.Cantidad,
        //                        Precio = detalle.Precio
        //                    };
        //                    _context.ValeDT.Add(valeDT);
        //                }
        //                _context.SaveChanges();

        //                transaction.Commit();
        //                return RedirectToAction("ListarCompras");
        //            }
        //            catch (Exception)
        //            {
        //                transaction.Rollback();
        //                ModelState.AddModelError(string.Empty, "Ocurrió un error al registrar la compra.");
        //            }
        //        }
        //    }
        //    return View(model);
        //}

    }
}
