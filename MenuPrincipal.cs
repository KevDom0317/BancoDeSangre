namespace BancoDeSangre;

class MenuPrincipal
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Banco de Sangre");
        EncontrarEmparejamiento empa= new EncontrarEmparejamiento();
        RegistroDonante Reg = new RegistroDonante();
        empa.UsuariosCompatibles();
        Reg.RegistrarDonante();
    }
}
