using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace BancoDeSangre;

class ModificarDonante
{
    public ModificarDonante(){}

    string NuevoGrupoSanguineo = "";

    public void MenuModificacion()
    {
        Console.WriteLine("Que tipo de modificación deséa realizar? \n1. Modificar tipo de sangre. \n2.Modificar RH.");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                ModificarTipo();
                break;

            case 2:
                ModificarRH();
                break;

            default:
                Console.WriteLine("Porfavor, selccione una opción permitida");
                break;
        }
    }

    public void ModificarTipo()
    {
        Console.WriteLine("Ingrese el código de registro del donante: ");
        int codigoRegistro = int.Parse(Console.ReadLine());

        Console.WriteLine("Seleccione la opción por la que desea modificar \n1. A \n2. B \n3. O \n4. AB \n5. Volver");
        int Opcion = int.Parse(Console.ReadLine());

        switch (Opcion)
        {
            case 1:
                NuevoGrupoSanguineo = "A";
            break;

            case 2:
                NuevoGrupoSanguineo = "B";
            break;

            case 3:
                NuevoGrupoSanguineo = "O";
            break;

            case 4:
                NuevoGrupoSanguineo = "AB";
            break;

            case 5:
            return;
            
            default:
                Console.WriteLine("Seleciona una opción valida");
            break;
        }

        Conexion conexionDB = new Conexion();
        SqlConnection conexion = conexionDB.AbrirConexion();

        if (conexion != null)
        {
            string query = "UPDATE REGISTROS SET GrupoSanguineo = @nuevoGrupoSanguineo WHERE codigo_registro = @codigoregistro";
            SqlCommand comando = new SqlCommand(query, conexion );
            comando.Parameters.AddWithValue("@nuevoGrupoSanguineo", NuevoGrupoSanguineo);
            comando.Parameters.AddWithValue("@codigoRegistro", codigoRegistro);
            
            try
            {
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("El grupo sanguíneo se actualizó correctamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró ningún registro con el código ingresado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }
    }

    public void ModificarRH()
    {

    }
}