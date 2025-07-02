
namespace Controlador 
{

    using Modelos.Producto;
    using Logica.Producto;
    using InterfazUsuario.Utils;

    public class ControladorProducto
    
    {

        /* Atributos */

            private Producto p ;
            private ConsultaProducto p1;
            private InserccionProducto p2;   
            private ModificarProducto p3;
            private EliminarProducto p4;


         /// Constructor
        public ControladorProducto()
        {
           
            p = new Producto () ;
            p1 = new ConsultaProducto ();
            p2 = new InserccionProducto (p);   
            p3 = new ModificarProducto ();
            p4 = new EliminarProducto ();
        }

        /* Metodos de Controlador */

        // Insertar Producto

        public void AutoInserccion()
        {

            p.SetNombre(UsuarioInput.ObtenerNombre("Insertar"));
            
            p.SetPrecio(UsuarioInput.ObtenerPrecio("Insertar"));
            p.SetFecha(UsuarioInput.ObtenerFecha("Insertar"));


            Console.WriteLine(p.GetNombre());
            Console.WriteLine("Voy aquiiii");
            Console.WriteLine(p.GetFecha()); 
            Console.WriteLine(p.GetPrecio());
            p2.InsertarProducto();

        }

        /*------------------------------*/
        /*          Consultas            */
        /*------------------------------*/


         //Consultar todo
        public void AutoConsultaTodo()
        {
            MostrarDatos.Recorrer(p1.ConsultaProductoTotal());
        }


       //Consultar por Nombre
        public void AutoConsultaNombre()
        {
            MostrarDatos.Recorrer(p1.ConsultaProductoNombre(UsuarioInput.ObtenerNombre("Consultar")));
        }

        //Consultar por Precio
        public void AutoConsultaPrecio()
        {
            MostrarDatos.Recorrer(p1.ConsultaProductoPrecio(UsuarioInput.ObtenerPrecio("Consultar")));
        }

        //Consultar por Fecha
        public void AutoConsultaFecha()
        {
             MostrarDatos.Recorrer(p1.ConsultaProductoFecha(UsuarioInput.ObtenerFecha("Consultar")));
        }

        //Consultar por Nombre y Precio
        public void AutoConsultaNombrePrecio()
        {
             MostrarDatos.Recorrer(p1.ConsultaProductoNombrePrecio(UsuarioInput.ObtenerNombre("Consultar"),UsuarioInput.ObtenerPrecio("Consultar")));
        }

        //Consultar por Nombre y Fecha
        public void AutoConsultaNombreFecha()
        {
             MostrarDatos.Recorrer(p1.ConsultaProductoNombreFecha(UsuarioInput.ObtenerNombre("Consultar"),UsuarioInput.ObtenerFecha("Consultar")));
        }

        //Consultar por Precio Y Fecha
        public void AutoConsultaPrecioFecha()
        {
             MostrarDatos.Recorrer(p1.ConsultaProductoPrecioFecha(UsuarioInput.ObtenerPrecio("Consultar"),UsuarioInput.ObtenerFecha("Consultar")));
        }


         /*------------------------------*/
        /*          Modificar            */
        /*------------------------------*/


        public void AutoModificarNombre()
        {
            p1.ConsultaProductoTotal();

            if (p3.ModificarNombre(UsuarioInput.ObtenerNombre("Modificar"), UsuarioInput.ObtenerId("Modificar"), UsuarioInput.Comprobador()))
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

            p1.ConsultaProductoTotal();
            
            if (p3.ModificarPrecio(UsuarioInput.ObtenerId("Modificar"), UsuarioInput.ObtenerPrecio("Modificar"),UsuarioInput.Comprobador()))
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
            p1.ConsultaProductoTotal();
            if (p3.ModificarFecha(UsuarioInput.ObtenerFecha("Modificar"), UsuarioInput.ObtenerId("Modificar"),UsuarioInput.Comprobador()))
            {
                Console.WriteLine("Exitos....................");
                
            }else
            {
                Console.WriteLine("No se pudo Modificar................");
            }
            
           

        }

        public void AutoModificarTodo()
        {
            if (p3.ModificarTotal(UsuarioInput.ObtenerNombre("Modificar"), UsuarioInput.ObtenerPrecio("Modificar"), UsuarioInput.ObtenerFecha("Modificar"), UsuarioInput.ObtenerId("Modificar"), UsuarioInput.Comprobador()))
            {
                Console.WriteLine("Exitos..........");
                
            }else
            {
                Console.WriteLine("No se pudo Modificar..................");
            }

        }


        /*------------------------------*/
        /*          Eliminar            */
        /*------------------------------*/


         public void Autoeliminar()
        {
            AutoConsultaTodo();
            p4.BorrarProducto(UsuarioInput.ObtenerId("Eliminar"),UsuarioInput.Comprobador());
        }








    }





}