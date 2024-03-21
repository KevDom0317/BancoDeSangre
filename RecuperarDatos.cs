using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
namespace BancoDeSangre;
class RecuperarDato
{
    public RecuperarDato(){}
    Conexion conect = new Conexion();
    public void enconUsuario()
    {
        Console.WriteLine("Introduce el nombre del donante");
        string donante = Console.ReadLine()??"";
        string QueryCant = $@"
        SELECT R.Nombre, R.Numero, R.Direccion, R.GrupoSanguineo, R.Rh
        FROM REGISTROS R
        INNER JOIN REGISTROS C ON R.Nombre = C.Nombre
        WHERE C.Nombre = '{donante}'";
        var cmd5 = new SqlCommand(QueryCant, conect.AbrirConexion());
        using SqlDataReader reader = cmd5.ExecuteReader();
        try
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                Console.WriteLine("Los datos del donante que estas buscando son los siguientes: ");
                Console.WriteLine($"{reader["Nombre"]}, {reader["Numero"]}, {reader["Direccion"]}, {reader["GrupoSanguineo"]}, {reader["Rh"]}");
                }
                Console.ReadKey(); // ESPERA A QUE VERIFIQUE EL ERROR [[ BORRAR EN FUTURO ]]
            }
            else
            {
                Console.WriteLine("El usuario no existe o esta de baja");
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