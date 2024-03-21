using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace BancoDeSangre;
class CantidadSangre
{
    public CantidadSangre(){}
    Conexion conect=new Conexion();
    public void Cantidades()
    {
        string QueryCantidad = @"
        SELECT GrupoSanguineo, Rh, COUNT(*) AS cantidad
        FROM REGISTROS
        GROUP BY GrupoSanguineo, Rh";
        var cmdCantidad = new SqlCommand(QueryCantidad, conect.AbrirConexion());
        using (SqlDataReader readerCantidad = cmdCantidad.ExecuteReader())
        {
            Console.WriteLine("Cantidad de Grupos Sanguineos y Rh disponibles en todo el sistema:");
            while (readerCantidad.Read())
            {
                string grupoSanguineo = readerCantidad["GrupoSanguineo"].ToString() ?? "";
                string rhValue = readerCantidad["Rh"].ToString() ?? "";
                int cantidad = Convert.ToInt32(readerCantidad["cantidad"]);
                Console.WriteLine($"Grupo Sanguíneo: {grupoSanguineo}, RH: {rhValue}, Cantidad: {cantidad}");
            }
        }
    }
}