using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TiendaApi.Conexion;
using TiendaApi.Modelo;

namespace TiendaApi.Datos
{
    public class DatosProductos
    {
        private ConexionBD connectionBD;

        public DatosProductos()
        {
            connectionBD = new ConexionBD();
        }

        public async Task<List<ProductosModelo>> MostrarProductos()
        {
            var lista = new List<ProductosModelo>();
            using (MySqlConnection connection = connectionBD.GetConnection())
            {
                using MySqlCommand command = new MySqlCommand("mostrarProductos", connection);
                await connection.OpenAsync();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using DbDataReader items = await command.ExecuteReaderAsync();
                while (await items.ReadAsync())
                {
                    var producto = new ProductosModelo();
                    producto.descripcion = (string)items["descripcion"];
                    producto.id = (int)items["id"];
                    producto.precio = (decimal)items["precio"];

                    lista.Add(producto);
                }
            }
            return lista;
        }

        public async Task InsertarProductos(ProductosModelo producto)
        {
            using MySqlConnection connection = connectionBD.GetConnection();
            using MySqlCommand command = new MySqlCommand("insertarProductos", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("descripcion_tmp", producto.descripcion);
            command.Parameters.AddWithValue("precio_tmp", producto.precio);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task ActualizarProductos(ProductosModelo producto)
        {
            using MySqlConnection connection = connectionBD.GetConnection();
            using MySqlCommand command = new MySqlCommand("editarProductos", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("id_producto", producto.id);
            command.Parameters.AddWithValue("precio_producto", producto.precio);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task EliminarProducto(ProductosModelo producto)
        {
            using MySqlConnection connection = connectionBD.GetConnection();
            using MySqlCommand command = new MySqlCommand("eliminarProducto", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("id_producto", producto.id);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

    }
}
