using ApiDevelop.Data.DatabaseConfiguration;
using ApiDevelop.Domain.Domains;
using ApiDevelop.Services.Mappers.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevelop.Services.Impl
{
    public class CategoriaServiceImpl : ICategoriaService
    {

        private readonly DataBaseContext _dataBaseContext;
        private IMapper _mapper;

        public CategoriaServiceImpl(DataBaseContext dataBaseContext, IMapper mapper)
        {
            _dataBaseContext = dataBaseContext;
            _mapper = mapper;
        }

        public void DeleteProducto(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
            _dataBaseContext.Categoria.Remove(categoria);
            _dataBaseContext.SaveChanges();
        }

        public List<CategoriaDTO> GetAllCategorias()
        {
            List<Categoria> listaCategorias = _dataBaseContext.Categoria.ToList();
            List<CategoriaDTO> categorias = _mapper.Map<List<CategoriaDTO>>(listaCategorias);
            return categorias;
        }

        public CategoriaDTO GetCategoriaById(int id)
        {
            Categoria categoria = _dataBaseContext.Categoria.Find(id) ?? throw new Exception(message: "Categoria no encontrada");
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public bool SaveProducto(CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                throw new ArgumentNullException(paramName: "categoriaDTO", message: "Parametro no puede ser nulo");
            Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
            if (categoria.Id is 0)
            {
                _dataBaseContext.Categoria.Add(categoria);
            } else
            {
                _dataBaseContext.Categoria.Update(categoria);
            }
            var result = _dataBaseContext.SaveChanges();
            return result > 0;
        }
    }
}
