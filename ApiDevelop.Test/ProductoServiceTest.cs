using ApiDevelop.Data.DatabaseConfiguration;
using ApiDevelop.Domain.Domains;
using ApiDevelop.Services.Impl;
using ApiDevelop.Services.Mappers.Dtos;
using ApiDevelop.Services.Mappers.Profiles;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiDevelop.Test
{
    public class ProductoServiceTest
    {

        private readonly string connection = "server=localhost;port=3306;database=db_api;uid=mariodev;password=Mario12345";
        private Mapper _mapper;
        private DataBaseContext _dataBaseContext;
        private ProductoServiceImpl _productoService;

        public ProductoServiceTest()
        {
            var config = new MapperConfiguration(cfg => {
                /*cfg.CreateMap<Producto, ProductoDTO>();
                cfg.CreateMap<ProductoDTO, Producto>();*/
                cfg.AddProfile<ProductoProfile>();
                cfg.AddProfile<CategoriaProfile>();
            });
            _mapper = (Mapper?)config.CreateMapper();

            var options = new DbContextOptionsBuilder<DataBaseContext>()
                                .UseMySql(connection, ServerVersion.AutoDetect(connection))
                                .Options;
            _dataBaseContext = new DataBaseContext(options);
            _productoService = new ProductoServiceImpl(_dataBaseContext, _mapper);
        }

        [Fact]
        public void Test1()
        {
            var result = _productoService.GetAllProductos();
            Assert.NotNull(result);
            Assert.IsType<List<ProductoDTO>>(result);
        }
    }
}