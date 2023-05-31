using Microsoft.Data.SqlClient;

namespace ServiceApi.Models.Data
{
    public class ConexionBD
    {
        private readonly string _connectionString;
        public ConexionBD()
        {
            try
            {
                _connectionString = "Data Source=TECHSOFT401;Initial Catalog=Cards;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Conexion: {e.Message}");
                throw;
            }
        }
        public SqlConnection getConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}