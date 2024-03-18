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
        Console.WriteLine("Ingrese el código de registro del donante: ");
        int codigoRegistro = int.Parse(Console.ReadLine());

        Console.WriteLine("Seleccione la opción por la que desea modificar \n1. A \n2. B \n3. O \n4. AB \n5. Volver");
        int Opcion = int.Parse(Console.ReadLine());

        switch (Opcion)
        {
            case 1:
            break;

            case 2:
            break;

            case 3:
            break;

            case 4:
            break;

            case 5:
            return;
            
            default:
            break;
        }
    }

    public void ModificarRH()
    {

    }
}