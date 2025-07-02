
namespace InterfazUsuario.Utils
{

    using Modelos.Producto;
    using System;

    public static class MostrarDatos
    {

            //Metodo que muestra datos list<>
        
        

        public static void Recorrer(List<Producto> lista)
        {
            foreach (Producto p in lista)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("ID: " + p.GetId());
                Console.WriteLine("Nombre: " + p.GetNombre());
                Console.WriteLine("Precio: " + p.GetPrecio());
                Console.WriteLine("Fecha: " + p.GetFecha());
                Console.WriteLine("-------------------------");

            }
        }



        

        
    }



}