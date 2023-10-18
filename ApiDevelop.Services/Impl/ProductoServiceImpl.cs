using ApiDevelop.Data.DatabaseConfiguration;
using ApiDevelop.Domain.Domains;
using ApiDevelop.Services.Mappers.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevelop.Services.Impl
{
    public class ProductoServiceImpl : IProductoService
    {

        private readonly DataBaseContext _dataBaseContext;
        private readonly IMapper _mapper;

        public ProductoServiceImpl(DataBaseContext dataBaseContext, IMapper mapper)
        {
            _dataBaseContext = dataBaseContext;
            _mapper = mapper;
        }

        public void DeleteProducto(int id)
        {
            Producto producto = _dataBaseContext.Producto.Find(id) ?? throw new Exception("Dato no encontrado");
            _dataBaseContext.Producto.Remove(producto);
            _dataBaseContext.SaveChanges();
        }

        public List<ProductoDTO> GetAllProductos()
        {
            List<Producto> listaProductos = _dataBaseContext.Producto.Include(p => p.Categoria).ToList();
            List<ProductoDTO> products = _mapper.Map<List<ProductoDTO>>(listaProductos);
            return products;
        }

        public ProductoDTO GetProductoById(int id)
        {
            Producto producto = _dataBaseContext.Producto.Include(p => p.Categoria).FirstOrDefault(p => p.Id == id) ?? throw new Exception(message: "Producto Nulo");
            ProductoDTO productoDTO = _mapper.Map<ProductoDTO>(producto);
            return productoDTO;
        }

        public bool SaveProducto(ProductoDTO productoDTO)
        {
            if (productoDTO == null)
                throw new ArgumentNullException(paramName: "productoDTO", message: "Parametro no puede ser nulo");
            Producto producto = _mapper.Map<Producto>(productoDTO);
            if (productoDTO.Id is 0) {
                _dataBaseContext.Producto.Add(producto);
            }
            else
            {
                _dataBaseContext.Producto.Update(producto);
            }
           
            var result = _dataBaseContext.SaveChanges();
            return result > 0;
        }
    }
}
