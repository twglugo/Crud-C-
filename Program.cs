




namespace Program
{
    using System;
    using Modelos.Producto;


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema de gestión de productos.\n");

            InterfazUsuario.Menu menu = new InterfazUsuario.Menu();

            while (menu.Interaccion())
            {

            }

            Console.WriteLine("Gracias por usar el sistema. ¡Hasta pronto!");
        }
    }
}