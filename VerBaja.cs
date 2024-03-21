using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
namespace BancoDeSangre;
class BuscarBaja
{
    public BuscarBaja(){}
    Conexion conect = new Conexion();
    public void enconBaja()
    {
        string QueryCant = $@"
        SELECT R.Nombre, R.Numero, R.Direccion, R.GrupoSanguineo, R.Rh, R.Estatus, R.Motivo
        FROM REGISTROSBAJA R";
        var cmd5 = new SqlCommand(QueryCant, conect.AbrirConexion());
        using SqlDataReader reader = cmd5.ExecuteReader();
        try
        {
            if (reader.HasRows)
            {
                Console.WriteLine("Los siguientes donantes son los que estan de baja: ");
                while (reader.Read())
                {
                Console.WriteLine($"{reader["Nombre"]}, {reader["Numero"]}, {reader["Direccion"]}, {reader["GrupoSanguineo"]}, {reader["Rh"]}");
                }
                Console.ReadKey(); // ESPERA A QUE VERIFIQUE EL ERROR [[ BORRAR EN FUTURO ]]
            }
            else
            {
                Console.WriteLine("El usuario no existe o esta de alta");
                Console.ReadKey(); // ESPERA A QUE VERIFIQUE EL ERROR [[ BORRAR EN FUTURO ]]
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            conect.CerrarConexion();
        }
    }
}