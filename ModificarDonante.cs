using System;
using Microsoft.Data.SqlClient;
//Falta agregar el motivo por el cual se le esta dando de baja
namespace BancoDeSangre
{
    public class ModificarDonante
    {
        private Conexion conexion;

        public ModificarDonante()
        {
            conexion = new Conexion();
        }
        
        public void MoverDonanteABaja(string nombreDonante, string motivoBaja)
        {
            // Query para mover los datos del donante a REGISTROSBAJA y eliminarlos de REGISTROS
            string queryModify = @"
                -- Mover datos del donante a la tabla REGISTROSBAJA
                INSERT INTO REGISTROSBAJA (Nombre, Numero, Direccion, GrupoSanguineo, Rh, Estatus, Motivo)
                SELECT Nombre, Numero, Direccion, GrupoSanguineo, Rh, 'Baja', 'Motivo de baja'
                FROM REGISTROS
                WHERE Nombre = @NombreDonante;
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
                    command.Parameters.AddWithValue("@Motivo", motivoBaja);

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
    }
}
