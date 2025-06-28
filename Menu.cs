

namespace MenuInteractivo
{

    using System;
    using Entidad;


    public class Menu
    {



        Producto p;
        Consulta.ProductoConsulta p1;
        Manipulacion.ProductoManipulacion p2;
        Modificar.ModificadorProducto p3;

        Eliminar.EliminarProducto p4;


        public Menu()
        {
            p = new Producto();
            p1 = new Consulta.ProductoConsulta();
            p2 = new Manipulacion.ProductoManipulacion(p);
            p3 = new Modificar.ModificadorProducto();
            p4 = new Eliminar.EliminarProducto();

        }

        public Menu(bool Estado)
        {



            p = new Producto();
            p1 = new Consulta.ProductoConsulta();
            p2 = new Manipulacion.ProductoManipulacion();
            p3 = new Modificar.ModificadorProducto();
            p4 = new Eliminar.EliminarProducto();
            Interaccion();
        }

/*------------------------------*/
/*           Menus switch       */
/*------------------------------*/
        
        //Menú Principal
        public bool Interaccion()
        {
            
            switch (Opcion(MostrarMenu("Menu")))
            {
                case 1: //Insertar
                    AutoInserccion();
                    break;
                case 2: // Consultar
                    MenuConsulta();
                    break;
                case 3: // Modificar
                    MenuModificar();
                    break;
                case 4: // Eliminar 
                    Autoeliminar();
                    break;
                default:
                    Console.WriteLine("Saliendo..........................");
                    return false;

            }

            return true;
        }
        

        //Menu -> Modificar
        
        public void MenuModificar()
        {
            
            switch (Opcion(MostrarMenu("Modificar")))
            {
                case 1: //Modificar->Todo
                    AutoModificarTodo();
                    break;
                case 2: // Modificar->Nombre
                    AutoModificarNombre();
                    break;
                case 3: // Modificar->Precio
                    AutoModificarPrecio();
                    break;
                case 4: // Modificar->Fecha
                    AutoModificarFecha();

                    break;
                default:
                    Console.WriteLine("Volviendo..........................");
                    Interaccion();

                    break;

            }
        }
        //Menu -> Consultas

        public void MenuConsulta()
        {
            
            switch (Opcion(MostrarMenu("Consultar")))
            {
                case 1: //Consultar->Todo
                    AutoConsultaTodo();
                    break;
                case 2: // Consultar por Nombre
                    AutoConsultaNombre();
                    break;
                case 3: // Consultar por Precio
                    AutoConsultaPrecio();
                    break;
                case 4: // Consultar por Fecha
                    AutoConsultaFecha();

                    break;
                case 5: //Consulta por Nombre y Precio
                    AutoConsultaNombrePrecio();
                    break;
                case 6: //Consulta por Nombre y Fecha 
                    AutoConsultaNombreFecha();
                    break;
                case 7: //Consulta por Precio y Fecha
                    AutoConsultaPrecioFecha();
                    break;
                default:
                    Console.WriteLine("Volviendo..........................");
                    Interaccion();

                    break;
            }
        }


        public void AutoInserccion()
        {

            p.SetNombre(ObtenerNombre("Insertar"));
            p.SetPrecio(ObtenerPrecio("Insertar"));
            p.SetFecha(ObtenerFecha("Insertar"));
            p2.InsertarProducto();

        }





        public void Autoeliminar()
        {
            AutoConsultaTodo();
            p4.BorrarProducto(ObtenerId("Eliminar"),Comprobador());
        }


        /*------------------------------*/
        /*          Consultas            */
        /*------------------------------*/


        //Consultar todo
        public void AutoConsultaTodo()
        {
            Recorrer(p1.ConsultaProducto());
        }


       //Consultar por Nombre
        public void AutoConsultaNombre()
        {
            Recorrer(p1.ConsultaProductoNombre(ObtenerNombre("Consultar")));
        }

        //Consultar por Precio
        public void AutoConsultaPrecio()
        {
            Recorrer(p1.ConsultaProductoPrecio(ObtenerPrecio("Consultar")));
        }

        //Consultar por Fecha
        public void AutoConsultaFecha()
        {
            Recorrer(p1.ConsultaProductoFecha(ObtenerFecha("Consultar")));
        }

        //Consultar por Nombre y Precio
        public void AutoConsultaNombrePrecio()
        {
            Recorrer(p1.ConsultaProductoNombrePrecio(ObtenerNombre("Consultar"),ObtenerPrecio("Consultar")));
        }

        //Consultar por Nombre y Fecha
        public void AutoConsultaNombreFecha()
        {
            Recorrer(p1.ConsultaProductoNombreFecha(ObtenerNombre("Consultar"),ObtenerFecha("Consultar")));
        }

        //Consultar por Precio Y Fecha
        public void AutoConsultaPrecioFecha()
        {
            Recorrer(p1.ConsultaProductoPrecioFecha(ObtenerPrecio("Consultar"),ObtenerFecha("Consultar")));
        }

        





        /* Modificadores */
        /*------------------------------*/
        /*          Modificar            */
        /*------------------------------*/


        public void AutoModificarNombre()
        {
            p1.ConsultaProducto();

            if (p3.ModificarNombre(ObtenerNombre("Modificar"), ObtenerId("Modificar"), Comprobador()))
            {
                Console.WriteLine("Exito............");

            }
            else
            {
                Console.WriteLine("No se Modifico..............");
            }

        }

        public void AutoModificarPrecio()
        {

            p1.ConsultaProducto();
            
            if (p3.ModificarPrecio(ObtenerId("Modificar"), ObtenerPrecio("Modificar"),Comprobador()))
            {
                Console.WriteLine("Exito.....");
                
            }
            else
            {
                Console.WriteLine("Error al Modificar.........");
            }
            

            


        }

        public void AutoModificarFecha()
        {
            p1.ConsultaProducto();
            if (p3.ModificarFecha(ObtenerFecha("Modificar"), ObtenerId("Modificar"),Comprobador()))
            {
                Console.WriteLine("Exitos....................");
                
            }else
            {
                Console.WriteLine("No se pudo Modificar................");
            }
            
           

        }

        public void AutoModificarTodo()
        {
            if (p3.ModificarTotal(ObtenerNombre("Modificar"), ObtenerPrecio("Modificar"), ObtenerFecha("Modificar"), ObtenerId("Modificar"), Comprobador()))
            {
                Console.WriteLine("Exitos..........");
                
            }else
            {
                Console.WriteLine("No se pudo Modificar..................");
            }

        }

        //Automatizaciones


        /*------------------------------*/
        /*   Opciones y automatizado    */
        /*------------------------------*/


        //Opcion -> Switch

        public int Opcion(int Total)
        {
            while (true)
            {
                Console.Write("Escoge una opción: ");
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int opcion)&& (opcion > 0 && opcion <= Total))
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
        public int ObtenerId(string texto)
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
        public string ObtenerNombre(string texto)
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
        public int ObtenerPrecio(string texto)
        {

            
            while (true)
            {
                Console.WriteLine($"Digita el precio que vas a {texto}");
                String? entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int Precio)&& Precio > 0 )
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
        public DateTime ObtenerFecha(string texto)
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
        
        public bool Comprobador()
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
        
        //Mostrar datos o tuplas
        public void Recorrer(List<Producto> lista)
        {
            foreach (Entidad.Producto p in lista)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("ID: " + p.GetId());
                Console.WriteLine("Nombre: " + p.GetNombre());
                Console.WriteLine("Precio: " + p.GetPrecio());
                Console.WriteLine("Fecha: " + p.GetFecha());
                Console.WriteLine("-------------------------");

            }
        }
        
        /*------------------------------*/
        /*          Menus Ux             */
        /*------------------------------*/

        public int MostrarMenu(string fase)
        {
            int total = 0; ;

            if (fase.Equals("Menu"))
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Opcion: 1 -> Insertar");
                Console.WriteLine("Opcion: 2 -> Consultar");
                Console.WriteLine("Opcion: 3 -> Modificar");
                Console.WriteLine("Opcion: 4 -> Eliminar");
                Console.WriteLine("Opcion: 5 -> Salir");
                Console.WriteLine("----------------------------");
                total = 5;
                return total;

            }
            else if (fase.Equals("Modificar"))
            {

                Console.WriteLine("----------------------------");
                Console.WriteLine("Opcion: 1 -> Modificar Todo ");
                Console.WriteLine("Opcion: 2 -> Modificar Nombre");
                Console.WriteLine("Opcion: 3 -> Modificar Precio");
                Console.WriteLine("Opcion: 4 -> Modificar Fecha");
                Console.WriteLine("Opcion: 5 -> Volver al menú principal");
                Console.WriteLine("----------------------------");
                total = 5;
                return total;

            }
            else if (fase.Equals("Consultar"))
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Opcion: 1 -> Consulta total");
                Console.WriteLine("Opcion: 2 -> Consultar por Nombre");
                Console.WriteLine("Opcion: 3 -> Consultar por Precio");
                Console.WriteLine("Opcion: 4 -> Consultar por Fecha");
                Console.WriteLine("Opcion: 5 -> Consultar por Nombre y Precio");
                Console.WriteLine("Opcion: 6 -> Consultar por Nombre y Fecha");
                Console.WriteLine("Opcion: 7 -> Consultar por Precio y Fecha");
                Console.WriteLine("Opcion: 8 -> Volver al menú principal");
                Console.WriteLine("----------------------------");
                total = 8;
                return total;

            }


            return total;
        }




















    }








}