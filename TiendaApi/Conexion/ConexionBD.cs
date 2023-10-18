using MySql.Data.MySqlClient;

namespace TiendaApi.Conexion
{
    public class ConexionBD
    {

        private string connectionString = string.Empty;
        public ConexionBD(/*IConfiguration configuration*/) {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            //connectionString = builder.GetSection("ConnectionStrings:MySqlConnection").Value;
            connectionString = builder.GetConnectionString("MySqlConnection");
            //connectionString = configuration.GetConnectionString("MySqlConnection");
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public string CadenaMySql()
        {
            return connectionString;
        }

    }
}
