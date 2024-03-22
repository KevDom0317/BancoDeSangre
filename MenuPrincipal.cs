using System.Reflection.Emit;

namespace BancoDeSangre;

class MenuPrincipal
{
    static void Main(string[] args)
    {
        string opc = "";
        bool con = true;
        Console.Clear();
        Console.WriteLine("Bienvenido al Banco de Sangre");
        do
        {
            Console.WriteLine("¿Qué deseas realizar? \n [1]Registrarse \n [2]Encontrar usuarios compatibles \n [3]Dar de baja un donante \n [4]Reactivar Donante \n [5]Ver la cantidad de tipos de sangre disponibles \n [6]Recuperar los datos de un donante \n [7]Ver todas las bajas \n [8]Abandonar");
            opc = Console.ReadLine() ?? "";
            EncontrarEmparejamiento empa= new EncontrarEmparejamiento();
            RegistroDonante Reg = new RegistroDonante();
            ModificarDonante Mod = new ModificarDonante();
            CantidadSangre Cant = new CantidadSangre();
            RecuperarDato Recu = new RecuperarDato();
            BuscarBaja Busc = new BuscarBaja();
            switch(opc)
            {
                case "1":
                Reg.RegistrarDonante();
                break;
                case "2":
                empa.UsuariosCompatibles();
                break;
                case"3":
                Console.WriteLine("Introduce el Nombre del donante al cual dar de baja");
                string Nombre = Console.ReadLine()?? "";
                Console.WriteLine("Introduce el motivo de la baja");
                string Motivo = Console.ReadLine()??"";
                Mod.MoverDonanteABaja(Nombre, Motivo);
                break;
                case"4":
                Console.WriteLine("Introduce el Nombre del donante al cual quieras reactivar");
                string Nombre1 = Console.ReadLine()?? "";
                Mod.ReactivarDonante(Nombre1);
                break;
                case"5":
                Cant.Cantidades();
                break;
                case"6":
                Recu.enconUsuario();
                break;
                case"7":
                Busc.enconBaja();
                break;
                case"8":
                Console.WriteLine("Abandonando...");
                con = false;
                break;
                default:
                Console.WriteLine("!!! Introduce uno de los numeros en el corchete !!!");
                break;
            }
        }while(con != false);

    }
}
