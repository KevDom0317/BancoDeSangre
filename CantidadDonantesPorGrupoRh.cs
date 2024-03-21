using System;
using Microsoft.Data.SqlClient;

namespace BancoDeSangre
{
    public class CantidadDonantesPorGrupoRh
    {
        private Conexion conexion;

        public CantidadDonantesPorGrupoRh()
        {
            conexion = new Conexion();
        }

        public void ObtenerCantidadDonantesPorGrupoRh()
        {
            // Consulta SQL para obtener la cantidad de donantes por GrupoSanguineo y Rh
            string queryCantidadDonantes = @"
                SELECT GrupoSanguineo, Rh, COUNT(*) AS CantidadDonantes
                FROM REGISTROS
                GROUP BY GrupoSanguineo, Rh;
            ";

            try
            {
                // Abrir conexión
                using (SqlConnection? connection = conexion.AbrirConexion())
                using (SqlCommand command = new SqlCommand(queryCantidadDonantes, connection))
                {
                    // Ejecutar consulta
                    SqlDataReader reader = command.ExecuteReader();

                    // Mostrar resultados
                    Console.WriteLine("Cantidad de donantes por GrupoSanguineo y Rh:");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("GrupoSanguineo\tRh\tCantidad");
                    Console.WriteLine("------------------------------------------");
                    while (reader.Read())
                    {
                        string? grupoSanguineo = reader["GrupoSanguineo"].ToString();
                        string? rh = reader["Rh"].ToString();
                        int cantidadDonantes = Convert.ToInt32(reader["CantidadDonantes"]);

                        Console.WriteLine($"{grupoSanguineo}\t\t{rh}\t{cantidadDonantes}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la cantidad de donantes por GrupoSanguineo y Rh: {ex.Message}");
            }
            finally
            {
                // Cerrar conexión
                conexion.CerrarConexion();
            }
        }
    }
}
