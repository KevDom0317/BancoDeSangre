using System.Diagnostics;

namespace BancoDeSangre;

class ModificarDonante
{
    public ModificarDonante(){}

    public void MenuModificacion()
    {
        Console.WriteLine("Que tipo de modificación deséa realizar? \n1. Modificar tipo de sangre. \n2.Modificar RH.");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                ModificarTipo();
                break;

            case 2:
                ModificarRH();
                break;

            default:
                Console.WriteLine("Porfavor, selccione una opción permitida");
                break;
        }
    }

    public void ModificarTipo()
    {

    }

    public void ModificarRH()
    {

    }
}