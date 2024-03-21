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
    private string? estatus;
    private string? motivo;
    private string? nuevoDato;
    private string? nuevoDato2;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Numero { get => numero; set => numero = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
    public string? Rh { get => rh; set => rh = value; }
    public string? Estatus { get => estatus; set => estatus = value; }
    public string? Motivo { get => motivo; set => motivo = value; }
    public string? NuevoDato { get => nuevoDato; set => nuevoDato = value; }
    public string? NuevoDato2 { get => nuevoDato2; set => nuevoDato2 = value; }
}