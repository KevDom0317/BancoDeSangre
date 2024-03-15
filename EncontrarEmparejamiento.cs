using Microsoft.Data.SqlClient;

namespace BancoDeSangre;

class EncontrarEmparejamiento
{
    public EncontrarEmparejamiento(){}

    Conexion conect=new Conexion();
    public void UsuariosCompatibles()
    {
         try
            {
                string Query5 = "SELECT * FROM productos";
                var cmd5 = new SqlCommand(Query5, conect.conexion.AbrirConexion());

                using SqlDataReader lector = cmd5.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Console.WriteLine($"El nombre del producto con id: {lector["id"].ToString} es: {lector["nombre"].ToString}.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
    }
}