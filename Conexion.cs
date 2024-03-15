using Microsoft.Data.SqlClient;
namespace BancoDeSangre;

public class Conexion
{
    private string Stringconexion="Server=KEVDOMINICK;Database=BANCODESANGRE;Integrated Security=True;";
    public SqlConnection conexion;
    public Conexion()
    {
        conexion=new SqlConnection(Stringconexion);
    }
    public SqlConnection? AbrirConexion()
    {
        try
        {
            conexion.Open();
            return conexion;    
        }
        catch (System.Exception)
        {
            Console.WriteLine("No se realizó la conexión");
            return null;
        }
        
    }
    public SqlConnection CerrarConexion()
    {
        conexion.Close();
        return conexion;
    }

    
}