using ApiPrueba.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebas.Data.Repositorio
{
    public class CarRepository : ICarRepository
    {

        private readonly MySqlConfiguration _configuration;

        public CarRepository(MySqlConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }

        async Task<bool> ICarRepository.DeleteCar(Car car)
        {
            var db = dbConnection();
            var sql = @"Delete from cars where id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = car.Id});
            return result > 0;
        }

        async Task<IEnumerable<Car>> ICarRepository.GetAllCars()
        {
            var db = dbConnection();
            var sql = @"select * from cars";
            return await db.QueryAsync<Car>(sql, new { });
        }

        async Task<Car> ICarRepository.GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @"select * from cars where id = @Id";
            return await db.QueryFirstOrDefaultAsync<Car>(sql, new { Id = id });
        }

        async Task<bool> ICarRepository.InsertCar(Car car)
        {
            var db = dbConnection();
            var sql = @"insert into cars(make, model, color, year, doors) 
                        values (@Make, @Model, @Color, @Year, @Doors)";
            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors });
            return result > 0;
        }

        async Task<bool> ICarRepository.UpdateCar(Car car)
        {
            var db = dbConnection();
            var sql = @"update cars
                        set make = @Make, model=@Model, color=@Color, year=@Year, doors=@Doors 
                        where id = @Id";
            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors, car.Id });
            return result > 0;
        }
    }
}
