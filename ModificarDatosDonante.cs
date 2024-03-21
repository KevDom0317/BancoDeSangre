using System;
using Microsoft.Data.SqlClient;

namespace BancoDeSangre
{
    public class ModificarDatosDonante:Variables
    {
        private Conexion conexion;

        public ModificarDatosDonante()
        {
            conexion = new Conexion();
        }

        public void ModificarDireccion()
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
                    Console.WriteLine("Opción no válida");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la nueva dirección: ");
                    NuevoDato=Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Opción no válida");
                }
            }
            // Consulta SQL para modificar la dirección del donante
            string queryModificarDireccion = @"
                UPDATE REGISTROS
                SET Direccion = @NuevaDireccion
                WHERE Nombre = @NombreDonante;
            ";

            try
            {
                // Abrir conexión
                using (SqlConnection? connection = conexion.AbrirConexion())
                using (SqlCommand command = new SqlCommand(queryModificarDireccion, connection))
                {
                    // Asignar parámetros
                    command.Parameters.AddWithValue("@NombreDonante", Nombre);
                    command.Parameters.AddWithValue("@NuevaDireccion", NuevoDato);

                    // Ejecutar consulta
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine($"La dirección del donante '{Nombre}' se ha modificado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ningún donante con el nombre '{Nombre}'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar la dirección del donante: {ex.Message}");
            }
            finally
            {
                // Cerrar conexión
                conexion.CerrarConexion();
            }
        }

        public void ModificarNumero()
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
                    Console.WriteLine("Opción no válida");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el nuevo número: ");
                    NuevoDato=Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Opción no válida");
                }
            }
            // Consulta SQL para modificar la dirección del donante
            string queryModificarDireccion = @"
                UPDATE REGISTROS
                SET Numero = @NuevoNumero
                WHERE Nombre = @NombreDonante;
            ";

            try
            {
                // Abrir conexión
                using (SqlConnection? connection = conexion.AbrirConexion())
                using (SqlCommand command = new SqlCommand(queryModificarDireccion, connection))
                {
                    // Asignar parámetros
                    command.Parameters.AddWithValue("@NombreDonante", Nombre);
                    command.Parameters.AddWithValue("@NuevoNumero", NuevoDato);

                    // Ejecutar consulta
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine($"El número del donante '{Nombre}' se ha modificado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ningún donante con el nombre '{Nombre}'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar la dirección del donante: {ex.Message}");
            }
            finally
            {
                // Cerrar conexión
                conexion.CerrarConexion();
            }
        }
        public void ModificarAmbos()
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
                    Console.WriteLine("Opción no válida");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el nuevo número: ");
                    NuevoDato=Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Opción no válida");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la nueva dirección: ");
                    NuevoDato2=Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Opción no válida");
                }
            }
            // Consulta SQL para modificar la dirección del donante
            string queryModificarDireccion = @"
                UPDATE REGISTROS
                SET Numero = @NuevoNumero
                SET Direccion = @NuevaDireccion
                WHERE Nombre = @NombreDonante;
            ";

            try
            {
                // Abrir conexión
                using (SqlConnection? connection = conexion.AbrirConexion())
                using (SqlCommand command = new SqlCommand(queryModificarDireccion, connection))
                {
                    // Asignar parámetros
                    command.Parameters.AddWithValue("@NombreDonante", Nombre);
                    command.Parameters.AddWithValue("@NuevoNumero", NuevoDato);
                    command.Parameters.AddWithValue("@NuevaDireccion", NuevoDato2);

                    // Ejecutar consulta
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine($"El número del donante '{Nombre}' se ha modificado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ningún donante con el nombre '{Nombre}'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar la dirección del donante: {ex.Message}");
            }
            finally
            {
                // Cerrar conexión
                conexion.CerrarConexion();
            }
        }

        public void CambiarDatos()
        {   int opcion;

            Console.WriteLine("1.Cambiar dirección.\n2.Cambiar número.\n3.Cambiar dirección y número.");
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese la opción deseada: ");
                    opcion=Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Opción no válida");
                }
            }
              
                switch (opcion)
                {   
                    case 1:
                        ModificarDireccion();
                        break;
                    case 2:
                        ModificarNumero();
                        break;
                    case 3:
                        ModificarAmbos();
                        break;
                    default:
                        return;
                }
                
           
        }
    }
}
