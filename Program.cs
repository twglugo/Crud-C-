using System;
using Entidad;




namespace Program
{



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema de gestión de productos.\n");

            MenuInteractivo.Menu menu = new MenuInteractivo.Menu();

            while (menu.Interaccion())
            {

            }

            Console.WriteLine("Gracias por usar el sistema. ¡Hasta pronto!");
        }
    }
}