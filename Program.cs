using System;
using Entidad;




namespace Program
{
    


    class Program
    {
        static void Main(string[] args)

        {
            bool Comprobador = true;
            Console.WriteLine("Bienvenido al sistema de gestión de productos.\n"); 
            while (Comprobador)
            {
                MenuInteractivo.Menu Interacion;
                Interacion = new MenuInteractivo.Menu();
                Comprobador = Interacion.Interaccion(); 
            }
            Console.WriteLine("La vie en rose ");

        }
    }
}