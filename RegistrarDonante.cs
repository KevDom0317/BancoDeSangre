using System;
using Microsoft.Data.SqlClient;

namespace BancoDeSangre
{
    public class RegistroDonante:Variables
    {
        private Conexion conexion;

        public RegistroDonante()
        {
            conexion = new Conexion();
        }

        public void BDRegistrarDonante(string? nombre, string? numero, string? direccion, string? grupoSanguineo, string? rh)
        {
            // Consulta para insertar un nuevo donante en la tabla REGISTROS
            string queryInsertarDonante = @"
                INSERT INTO REGISTROS (Nombre, Numero, Direccion, GrupoSanguineo, Rh)
                VALUES (@Nombre, @Numero, @Direccion, @GrupoSanguineo, @Rh);
            ";

            try
            {
                // Abrir conexión
                using (SqlConnection? connection = conexion.AbrirConexion())
                using (SqlCommand command = new SqlCommand(queryInsertarDonante, connection))
                {
                    // Asignar parámetros
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Numero", numero);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@GrupoSanguineo", grupoSanguineo);
                    command.Parameters.AddWithValue("@Rh", rh);

                    // Ejecutar consulta
                    command.ExecuteNonQuery();
                    Console.WriteLine("Nuevo donante registrado exitosamente en la tabla REGISTROS.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar nuevo donante: {ex.Message}");
            }
            finally
            {
                // Cerrar conexión
                conexion.CerrarConexion();
            }
        }

        public void RegistrarDonante()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el nombre completo: ");
                    Nombre=Console.ReadLine();
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
                    Console.WriteLine("Ingrese el número: ");
                    Numero=Console.ReadLine();
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
                    Console.WriteLine("Ingresa la dirección completa: ");
                    Direccion=Console.ReadLine();
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
                    Console.WriteLine("Ingresa el grupo sanguíneo: ");
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
                    Console.WriteLine("Ingresa el RH: ");
                    Rh=Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Valor no aceptado.");
                }
            }

            BDRegistrarDonante(Nombre,Numero,Direccion,GrupoSanguineo,Rh);
        }
    }
}
