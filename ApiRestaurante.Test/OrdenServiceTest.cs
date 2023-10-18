using ApiRestaurante.Data.ConfigurationBD;
using ApiRestaurante.Data.Models;
using ApiRestaurante.Domain.Repositories.Impl;
using ApiRestaurante.Services.Impl;
using ApiRestaurante.Services.Mappers.Dtos;
using ApiRestaurante.Services.Mappers.Profiles;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Test
{
    public class OrdenServiceTest
    {

        private CustomerServiceImpl _customerService;

        public OrdenServiceTest()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "restaurante")
                .Options;
            var dbContext = new DataBaseContext(options);
            var repository = new RepositoryAsyncImpl<Customer>(dbContext);
            var mapperConfig = new MapperConfiguration(opt => opt.AddProfile<CustomerProfile>());
            var mapper = mapperConfig.CreateMapper();
            _customerService = new CustomerServiceImpl(repository, mapper);
        }

        [Fact]
        public async void TestGuardar()
        {
            var customer = new CustomerDTO();
            customer.Nombre = "Andres";
            customer.Celular = "3100000000";

            var customerResult = await _customerService.Guardar(customer);

            Assert.NotNull(customerResult);
            Assert.IsType<CustomerDTO>(customerResult);
            Assert.Equal(customer.Nombre, customerResult.Nombre);

        }
    }
}