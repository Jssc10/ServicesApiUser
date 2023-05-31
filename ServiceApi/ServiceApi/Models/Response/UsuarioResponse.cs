using Microsoft.Data.SqlClient;
using ServiceApi.Models.Data;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceApi.Models.Response
{
    public class UsuarioResponse
    {
        ConexionBD _conexion = new ConexionBD();
        public bool Resgistrar(Usuario usuario)
        {
            SqlConnection oConexion = _conexion.getConexion(); //new SqlConnection();
            SqlCommand cmd = new SqlCommand("Sp_Usuarios", oConexion);
            oConexion.Open();

            try
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = usuario.id;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 30)).Value = usuario.nombre;
                cmd.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 10)).Value = usuario.telefono;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 30)).Value = usuario.email;
                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 30)).Value = usuario.estado;
                cmd.Parameters.Add(new SqlParameter("@opcion", SqlDbType.VarChar, 2)).Value = "C";
                cmd.CommandType = CommandType.StoredProcedure;

                Console.WriteLine($"Filas Afectadas: {cmd.ExecuteNonQuery()}");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en Registro {e.Message}");
                return false;
            }
            finally
            {
                oConexion.Close();
            }
        }
        public List<Usuario> Presentar()
        {
            SqlConnection oConexion = _conexion.getConexion();
            SqlCommand cmd = new SqlCommand("Sp_Usuarios", oConexion);
            List<Usuario> usuarios = new List<Usuario>();

            oConexion.Open();
            cmd.Parameters.Add(new SqlParameter("@opcion", SqlDbType.VarChar, 2)).Value = "R";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        usuarios.Add(new Usuario()
                        {
                            id = row["id"].ToString(),
                            nombre = row["nombre"].ToString(),
                            email = row["email"].ToString(),
                            telefono = row["telefono"].ToString(),
                            estado = row["estado"].ToString(),
                        }) ; 
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error al llenar Lista: {e.Message}");
                }
                finally
                {
                    oConexion.Close();
                }
            }
            return usuarios;
        }
    }
}
