namespace BancoDeSangre;

class MenuPrincipal
{
    static void Main(string[] args)
    {
        
        EncontrarEmparejamiento empa= new EncontrarEmparejamiento();
        RegistroDonante Reg = new RegistroDonante();
        ModificarDonante Mod= new ModificarDonante();
        CantidadDonantesPorGrupoRh cant=new CantidadDonantesPorGrupoRh();
        ModificarDatosDonante ModO=new ModificarDatosDonante();
        
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("////////////////Bood Bank+///////////////////");
            Console.WriteLine("");
            Console.WriteLine("1.Registrar nuevo donante.\n2.Cambiar estatus de donante.\n3.Encontrar emparejamiento.\n4.Cantidad de donantes por tipo y rh.\n5.Cambiar Datos del donante.");

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
                    Reg.RegistrarDonante();
                    break;
                case 2:
                    Mod.CambiarDonante();
                    break;
                case 3:
                    empa.EncontrarDonante();
                    break;
                case 4:
                    cant.ObtenerCantidadDonantesPorGrupoRh();
                    break;
                case 5:
                    ModO.CambiarDatos();
                    break;
                
                default:
                    break;
            }
            
        } while (true);
        
    }
}
