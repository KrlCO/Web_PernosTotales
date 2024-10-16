using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Pernos.Models;


namespace Web.Application.Pernos.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;


        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;

        }


        [HttpGet]
        public IActionResult Listar()
        {
            var productosDto = _productoService.Listar();
            // Convirtiendo ProductoDTO a ProductoViewModel
            var productos = productosDto.Select(p => new ProductoViewModel
            {
                IdProducto = p.IdProducto,
                IdCategoria = p.IdCategoria,
                CategoriaNombre = p.CategoriaNombre,
                IdUnidadMedida = p.IdUnidadMedida,
                UnidadMedidaNombre = p.UnidadMedidaNombre,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Stock = p.Stock,
                PrecioCompra = p.PrecioCompra,
                PrecioVenta = p.PrecioVenta,
                Estado = p.Estado
            }).ToList();

            return View(productos);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            CargarViewBags();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(ProductoDTO productoDto, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                if (Imagen != null && Imagen.Length > 0)
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", Imagen.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        Imagen.CopyTo(stream);
                    }
                    productoDto.ImagenRuta = "/Images/" + Imagen.FileName;
                }

                bool resultado;
                if (productoDto.IdProducto == 0)
                {
                    resultado = _productoService.RegistrarProducto(productoDto);
                }
                else
                {
                    resultado = _productoService.EditarProducto(productoDto).Resultado;
                }

                if (resultado)
                {
                    return RedirectToAction("Listar");
                }

                ModelState.AddModelError(string.Empty, "Error al guardar el producto.");
            }

            CargarViewBags();
            return View(productoDto);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var productoDto = _productoService.GetProductoById(id);
            if (productoDto == null)
            {
                return NotFound();
            }

            var productoViewModel = new ProductoViewModel
            {
                IdProducto = productoDto.IdProducto,
                IdCategoria = productoDto.IdCategoria,
                IdUnidadMedida = productoDto.IdUnidadMedida,
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                Stock = productoDto.Stock,
                PrecioCompra = productoDto.PrecioCompra,
                PrecioVenta = productoDto.PrecioVenta,
                Estado = productoDto.Estado,
                ImagenRuta = productoDto.ImagenRuta,
                CategoriaNombre = productoDto.CategoriaNombre,
                UnidadMedidaNombre = productoDto.UnidadMedidaNombre
            };

            CargarViewBags();
            return View(productoViewModel);
        }

        [HttpPost]
        public IActionResult Editar(ProductoViewModel modelo, IFormFile Imagen)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _productoService.GetCategorias();
                ViewBag.UnidadesMedidas = _productoService.GetUnidadesMedidas();
                return View(modelo);
            }

            // Manejar la imagen si se ha proporcionado
            if (Imagen != null && Imagen.Length > 0)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", Imagen.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Imagen.CopyTo(stream);
                }
                modelo.ImagenRuta = "/Images/" + Imagen.FileName;
            }
            else
            {
                // Mantener la ruta de la imagen actual si no se ha proporcionado una nueva
                modelo.ImagenRuta = modelo.ImagenRuta ?? string.Empty;
            }

            var productoDto = new ProductoDTO
            {
                IdProducto = modelo.IdProducto,
                IdCategoria = modelo.IdCategoria,
                IdUnidadMedida = modelo.IdUnidadMedida,
                Nombre = modelo.Nombre,
                Descripcion = modelo.Descripcion,
                Stock = modelo.Stock,
                PrecioCompra = modelo.PrecioCompra,
                PrecioVenta = modelo.PrecioVenta,
                Estado = modelo.Estado,
                ImagenRuta = modelo.ImagenRuta ?? string.Empty,
                UsuarioModificacion = "admin"
            };

            var resultado = _productoService.EditarProducto(productoDto);

            if (resultado.Resultado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                // Manejar el error
                ModelState.AddModelError("", "No se pudo actualizar el producto.");
                ViewBag.Categorias = _productoService.GetCategorias();
                ViewBag.UnidadesMedidas = _productoService.GetUnidadesMedidas();
                return View(modelo);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var resultado = _productoService.EliminarProducto(id);
            if (resultado.Resultado)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Error al eliminar el producto." });
            }
        }

        private void CargarViewBags()
        {
            ViewBag.Categorias = _productoService.GetCategorias();
            ViewBag.UnidadesMedidas = _productoService.GetUnidadesMedidas();
        }


        public IActionResult Catalogo()
        {
            var productosDto = _productoService.Listar();

            // Mapear los DTOs a ViewModels
            var productosViewModel = productosDto.Select(dto => new ProductoViewModel
            {
                IdProducto = dto.IdProducto,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                PrecioVenta = dto.PrecioVenta,
                ImagenRuta = dto.ImagenRuta, 
            }).ToList();

            // Pasar los ViewModels a la vista
            return View(productosViewModel);
        }

        public IActionResult DetalleProducto(int id)
        {
            var productoDTO = _productoService.GetProductoById(id);

            if (productoDTO == null)
            {
                return NotFound(); // O redirigir a una vista de error si el producto no se encuentra.
            }

            var productoViewModel = new ProductoViewModel
            {
                IdProducto = productoDTO.IdProducto,
                Nombre = productoDTO.Nombre,
                Descripcion = productoDTO.Descripcion,
                PrecioVenta = productoDTO.PrecioVenta,
                ImagenRuta = productoDTO.ImagenRuta,
                Stock = productoDTO.Stock
            };

            return View(productoViewModel); 
        }

        public IActionResult BuscarProductos(string searchTerm)
        {
            var productos = _productoService.BuscarProductoPorNombre(searchTerm); // Método que busca productos
            return PartialView("_ProductosPartial", productos); // Retorna una vista parcial con los resultados
        }

        public IActionResult ValeSalidaEntrada()
        {
            CargarViewBags();
            return View();
        }

    }
}
