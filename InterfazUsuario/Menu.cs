

namespace InterfazUsuario
{

    using System;
    using Utils;
    
    
    using Controlador;


    public class Menu
    {


       private ControladorProducto Controlador ;
        

        

        public Menu()
        {
         
            Controlador = new ControladorProducto();
            Interaccion();
        }

/*------------------------------*/
/*           Menus switch       */
/*------------------------------*/
        
        //Menú Principal
        public bool Interaccion()
        {
            
            switch (UsuarioInput.Opcion(MostrarMenu(TipoMenu.Principal)))
            {
                case 1: //Insertar
                    Controlador.AutoInserccion();
                    break;
                    
                case 2: // Consultar
                    MenuConsulta();
                    break;
                case 3: // Modificar
                    MenuModificar();
                    break;
                case 4: // Eliminar 
                    Controlador.Autoeliminar();
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
            
            switch (UsuarioInput.Opcion(MostrarMenu(TipoMenu.Modificar)))
            {
                case 1: //Modificar->Todo
                    Controlador.AutoModificarTodo();
                    break;
                case 2: // Modificar->Nombre
                    Controlador.AutoModificarNombre();
                    break;
                case 3: // Modificar->Precio
                    Controlador.AutoModificarPrecio();
                    break;
                case 4: // Modificar->Fecha
                    Controlador.AutoModificarFecha();

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
            
            switch (UsuarioInput.Opcion(MostrarMenu(TipoMenu.Consultar)))
            {
                case 1: //Consultar->Todo
                    Controlador.AutoConsultaTodo();
                    break;
                case 2: // Consultar por Nombre
                    Controlador.AutoConsultaNombre();
                    break;
                case 3: // Consultar por Precio
                    Controlador.AutoConsultaPrecio();
                    break;
                case 4: // Consultar por Fecha
                    Controlador.AutoConsultaFecha();

                    break;
                case 5: //Consulta por Nombre y Precio
                    Controlador.AutoConsultaNombrePrecio();
                    break;
                case 6: //Consulta por Nombre y Fecha 
                    Controlador.AutoConsultaNombreFecha();
                    break;
                case 7: //Consulta por Precio y Fecha
                    Controlador.AutoConsultaPrecioFecha();
                    break;
                default:
                    Console.WriteLine("Volviendo..........................");
                    Interaccion();

                    break;
            }
        }
        
        /*------------------------------*/
        /*          Menus Ux             */
        /*------------------------------*/

        public int MostrarMenu(TipoMenu fase)
        {
            switch (fase)
            {
                case TipoMenu.Principal:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Opción: 1 -> Insertar");
                    Console.WriteLine("Opción: 2 -> Consultar");
                    Console.WriteLine("Opción: 3 -> Modificar");
                    Console.WriteLine("Opción: 4 -> Eliminar");
                    Console.WriteLine("Opción: 5 -> Salir");
                    Console.WriteLine("----------------------------");
                    return 5;

                case TipoMenu.Modificar:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Opción: 1 -> Modificar Todo");
                    Console.WriteLine("Opción: 2 -> Modificar Nombre");
                    Console.WriteLine("Opción: 3 -> Modificar Precio");
                    Console.WriteLine("Opción: 4 -> Modificar Fecha");
                    Console.WriteLine("Opción: 5 -> Volver al menú principal");
                    Console.WriteLine("----------------------------");
                    return 5;

                case TipoMenu.Consultar:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Opción: 1 -> Consulta total");
                    Console.WriteLine("Opción: 2 -> Consultar por Nombre");
                    Console.WriteLine("Opción: 3 -> Consultar por Precio");
                    Console.WriteLine("Opción: 4 -> Consultar por Fecha");
                    Console.WriteLine("Opción: 5 -> Consultar por Nombre y Precio");
                    Console.WriteLine("Opción: 6 -> Consultar por Nombre y Fecha");
                    Console.WriteLine("Opción: 7 -> Consultar por Precio y Fecha");
                    Console.WriteLine("Opción: 8 -> Volver al menú principal");
                    Console.WriteLine("----------------------------");
                    return 8;

                default:
                    return 0;
            }
        }





















    }








}