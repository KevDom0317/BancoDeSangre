using System;
using Microsoft.Data.SqlClient;

namespace BancoDeSangre
{
    public class ModificarDonante:Variables
    {
        private Conexion conexion;

        public ModificarDonante()
        {
            conexion = new Conexion();
        }

        public void MoverDonanteABaja(string nombreDonante, string Estatus, string Motivo)
        {
            // Query para mover los datos del donante a REGISTROSBAJA y eliminarlos de REGISTROS
            string queryModify = @$"
                -- Mover datos del donante a la tabla REGISTROSBAJA
                INSERT INTO REGISTROSBAJA (Nombre, Numero, Direccion, GrupoSanguineo, Rh, Estatus, Motivo)
                SELECT Nombre, Numero, Direccion, GrupoSanguineo, Rh, '{Estatus}', '{Motivo}'
                FROM REGISTROS
                WHERE Nombre = @NombreDonante;

                -- Eliminar datos del donante de la tabla REGISTROS
                DELETE FROM REGISTROS
                WHERE Nombre = @NombreDonante;
            ";

            try
            {
                // Abrir conexión
                using (SqlConnection? connection = conexion.AbrirConexion())
                using (SqlCommand command = new SqlCommand(queryModify, connection))
                {
                    // Asignar parámetro de nombre de donante
                    command.Parameters.AddWithValue("@NombreDonante", nombreDonante);

                    // Ejecutar consulta
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Los datos del donante '{nombreDonante}' se han movido a la tabla REGISTROSBAJA.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mover datos del donante a REGISTROSBAJA: {ex.Message}");
            }
            finally
            {
                // Cerrar conexión
                conexion.CerrarConexion();
            }
        }

        public void CambiarDonante()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el nombre del donante: ");
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
                    Console.WriteLine("Ingrese el estatus: ");
                    Estatus=Console.ReadLine();
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
                    Console.WriteLine("Ingrese el motivo: ");
                    Motivo=Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Valor no aceptado.");
                }
            }
            MoverDonanteABaja(Nombre, Estatus, Motivo);
        }
    }


}
