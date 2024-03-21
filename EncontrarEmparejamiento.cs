using Microsoft.Data.SqlClient;

namespace BancoDeSangre;

class EncontrarEmparejamiento:Variables
{
    public EncontrarEmparejamiento(){}

    Conexion conect=new Conexion();
    
    public void UsuariosCompatibles(string? tipoSangre, string? rh)
    {
        try
        {
            string Query5 = $@"
            SELECT R.Nombre, R.Numero, R.Direccion, R.GrupoSanguineo, R.Rh
            FROM REGISTROS R
            INNER JOIN COMPATIBILIDAD C ON R.GrupoSanguineo = C.Tipo AND R.Rh = C.Rh
            WHERE C.TipoCompatible = '{tipoSangre}'
                AND C.RhCompatible = '{rh}'";
            var cmd5 = new SqlCommand(Query5, conect.AbrirConexion());

            using SqlDataReader reader = cmd5.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                Console.WriteLine($"{reader["Nombre"]}, {reader["Numero"]}, {reader["Direccion"]}, {reader["GrupoSanguineo"]}, {reader["Rh"]}");
                }
                Console.ReadKey(); // ESPERA A QUE VERIFIQUE EL ERROR [[ BORRAR EN FUTURO ]]
            }
            else
            {
                Console.WriteLine("No tiene bro");
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

    public void EncontrarDonante()
    {
        while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el grupo sanguíneo: ");
                    GrupoSanguineo=Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Valor no aceptado.");
                }
            }
        while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el RH: ");
                    GrupoSanguineo=Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Valor no aceptado.");
                }
            }
        UsuariosCompatibles(GrupoSanguineo,Rh);
    }
}