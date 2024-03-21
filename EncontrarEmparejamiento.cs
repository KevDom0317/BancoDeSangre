using Azure.Core.Pipeline;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace BancoDeSangre;

class EncontrarEmparejamiento
{
    public EncontrarEmparejamiento(){}

    Conexion conect=new Conexion();
    public void UsuariosCompatibles()
    {
        string? tipoSangre = "";
        string? rh = "";
        do
        {
            Console.WriteLine("Introduce el tipo de sangre [A, B, AB, O]");
            tipoSangre = Console.ReadLine();
            if(tipoSangre != "A" && tipoSangre !="B" && tipoSangre != "AB" && tipoSangre != "O")
            {
                Console.WriteLine("Ese tipo de sangre no existe. Introduce un valido");
                continue;
            }
            else
            {
                break;
            }
        }while(true);
        do
        {
            Console.WriteLine("Su RH es positiva [+] o negativa [-]?");
            rh = Console.ReadLine();
            if(rh != "+" && rh != "-")
            {
                Console.WriteLine("Ese tipo de RH no existe");
                continue;
            }
            else
            {
                break;
            }
        }while(true);
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

}