using AutoMapper;
using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.DTO;
using JSD.SUNKU.DTO;
using System.Collections.Generic;
using System.Linq;


namespace JSD.PERNOS.Business.Logic.Layer.Implementation
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository productoRepository, IMapper mapper) => (_productoRepository, _mapper) = (productoRepository, mapper);

        public IEnumerable<ProductoDTO> Listar()
        {
            var productos = _productoRepository.Listar();

            return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
        }

        public ProductoDTO GetProductoById(int id)
        {
            var producto = _productoRepository.GetProductoById(id);
            if (producto == null)
            {
                return null;
            }

            var productoDto = _mapper.Map<ProductoDTO>(producto);
            return productoDto;
        }


        public bool RegistrarProducto(ProductoDTO productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            return _productoRepository.RegistrarProducto(producto);
        }

        public Result<bool> EditarProducto(ProductoDTO productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            var result = new Result<bool>
            {
                Resultado = _productoRepository.EditarProducto(producto)
            };
            return result;
        }

        public Result<bool> EliminarProducto(int id)
        {
            var result = new Result<bool>();
            result.Resultado = _productoRepository.EliminarProducto(id);
            return result;
        }

        public IEnumerable<ProductoDTO> BuscarProductoPorNombre(string nombre)
        {
            var productos = _productoRepository.BuscarProductoPorNombre(nombre);
            return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
        }

        public IEnumerable<ProductoDTO> GetProductosPaginados(string nombreProducto, int page, int pageSize, out int totalProductos)
        {
            throw new System.NotImplementedException();
        }


        public IEnumerable<ProductoDTO> GetTopProductos()
        {
            var productos = _productoRepository.GetTopProductos().Take(5);
            return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
        }


        public IEnumerable<CategoriaDTO> GetCategorias()
        {
            var categorias = _productoRepository.GetCategorias();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

        public IEnumerable<UnidadMedidaDTO> GetUnidadesMedidas()
        {
            var unidadesMedidas = _productoRepository.GetUnidadesMedidas();
            return _mapper.Map<IEnumerable<UnidadMedidaDTO>>(unidadesMedidas);
        }


    }
}
