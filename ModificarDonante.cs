using System;
using Microsoft.Data.SqlClient;

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
            string queryModify = @"
                -- Mover datos del donante a la tabla REGISTROSBAJA
                INSERT INTO REGISTROSBAJA (Nombre, Numero, Direccion, GrupoSanguineo, Rh, Estatus, Motivo)
                SELECT Nombre, Numero, Direccion, GrupoSanguineo, Rh, 'Baja', @Motivo
                FROM REGISTROS
                WHERE Nombre = @NombreDonante;
                DELETE FROM REGISTROS
                WHERE Nombre = @NombreDonante;
            ";

            try
            {

                using (SqlConnection? connection = conexion.AbrirConexion())
                using (SqlCommand command = new SqlCommand(queryModify, connection))
                {
                    command.Parameters.AddWithValue("@NombreDonante", nombreDonante);
                    command.Parameters.AddWithValue("@Motivo", motivoBaja);

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
                conexion.CerrarConexion();
            }
        }

        public void ReactivarDonante(string nombreDonante)
        {
            string queryModify = @"
                -- Mover los datos del donante de la tabla REGISTROSBAJA a REGISTROS
                INSERT INTO REGISTROS (Nombre, Numero, Direccion, GrupoSanguineo, Rh)
                SELECT Nombre, Numero, Direccion, GrupoSanguineo, Rh
                FROM REGISTROSBAJA
                WHERE Nombre = @NombreDonante;

                DELETE FROM REGISTROSBAJA
                WHERE Nombre = @NombreDonante;
            ";

            try
            {
                using (SqlConnection? connection = conexion.AbrirConexion())
                using (SqlCommand command = new SqlCommand(queryModify, connection))
                {
                    command.Parameters.AddWithValue("@NombreDonante", nombreDonante);

                    command.ExecuteNonQuery();
                    Console.WriteLine($"El donante '{nombreDonante}' se ha reactivado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al reactivar al donante: {ex.Message}");
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
