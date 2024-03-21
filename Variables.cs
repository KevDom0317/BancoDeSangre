using System;
using Microsoft.Data.SqlClient;

namespace BancoDeSangre;

public class Variables
{
    public Variables(){}

    private string? nombre; 
    private string? numero; 
    private string? direccion;
    private string? grupoSanguineo; 
    private string? rh;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Numero { get => numero; set => numero = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
    public string? Rh { get => rh; set => rh = value; }
}