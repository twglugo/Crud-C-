
namespace InterfazUsuario.Utils
{

    public static class UsuarioInput
    {

        //Metodos 

        public static int Opcion(int Total)
        {
            while (true)
            {
                Console.Write("Escoge una opción: ");
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int opcion) && (opcion > 0 && opcion <= Total))
                {
                    return opcion;
                }
                else
                {
                    Console.WriteLine($"Entrada inválida. Debes ingresar un número entero mayor a 0 y menor a  {Total}");
                }
            }

        }




        // Obtener -> id
        public static int ObtenerId(string texto)
        {
            while (true)
            {
                Console.Write($"Digita el Id que vas a {texto}: ");
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int id) && id > 0)
                {
                    return id;
                }

                Console.WriteLine("ID inválido. Debes ingresar un número entero mayor que cero.");
            }
        }

        //Obtener -> nombre
        public static string ObtenerNombre(string texto)
        {
            while (true)
            {
                Console.WriteLine($"Digita el nombre que vas a {texto}:");
                string? Nombre = Console.ReadLine();
                if (Nombre != null && Nombre != "")
                {
                    return Nombre;
                }
                else
                {
                    Console.WriteLine("Debes digitar el nombre......");
                }

            }

        }

        //Obtener -> Precio
        public static int ObtenerPrecio(string texto)
        {


            while (true)
            {
                Console.WriteLine($"Digita el precio que vas a {texto}");
                String? entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int Precio) && Precio > 0)
                {

                    return Precio;



                }
                else
                {
                    Console.WriteLine("Debes digitar numero positivo mayor a 0 ");
                }
            }

        }


        //Obtener -> Fecha
        public static DateTime ObtenerFecha(string texto)
        {
            while (true)
            {
                Console.WriteLine("Si deseas la fecha actual digita -> 1");
                Console.WriteLine("Si deseas ingresar otra fecha digita -> 2");

                string? entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int op))
                {
                    switch (op)
                    {
                        case 1:
                            return DateTime.Now;

                        case 2:
                            while (true)
                            {
                                Console.WriteLine($"Digita la fecha que vas a {texto} en formato AAAA-MM-DD HH:MM:SS");
                                string? fechaEntrada = Console.ReadLine();

                                if (DateTime.TryParse(fechaEntrada, out DateTime fecha))
                                {
                                    return fecha;
                                }
                                else
                                {
                                    Console.WriteLine("Formato incorrecto. Ejemplo válido: 2025-06-16 15:30:00");
                                }
                            }

                        default:
                            Console.WriteLine("Opción no válida. Debes digitar 1 o 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Debes digitar 1 o 2.");
                }
            }
        }

        //Obtener reconfirmacion S/N    

        public static bool Comprobador()
        {
            while (true)
            {
                Console.Write("¿Deseas ejecutar el cambio? (S/N): ");
                string? op = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(op))
                {
                    Console.WriteLine("Entrada vacía. Escribe S o N.");
                    continue;
                }

                if (op.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                if (op.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                Console.WriteLine("Entrada inválida. Escribe S o N.");
            }
        }

        

        



        

        




    }



}