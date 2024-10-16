using AutoMapper;
using JSD.PERNOS.Business.Entity.Layer;
using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.SUNKU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSD.PERNOS.Business.Logic.Layer.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper) => (_categoriaRepository, _mapper) = (categoriaRepository, mapper);
        public IEnumerable<Categoria> GetCategoria() => _categoriaRepository.GetCategoria();

        public bool RegistrarCategoria(Categoria categoria)
        {
            return _categoriaRepository.RegistrarCategoria(categoria);
        }

        public Result<bool> EditarCategoria(Categoria categoria)
        {
            var result = new Result<bool>();
            result.Resultado = _categoriaRepository.EditarCategoria(categoria);
            return result;
        }

        public Result<bool> EliminarCategoria(int id)
        {
            var result = new Result<bool>();
            result.Resultado = _categoriaRepository.EliminarCategoria(id);
            return result;
        }
    }
}
