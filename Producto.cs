using System;
using System.Collections.Generic;
using Entidad;
using MySql.Data.MySqlClient;

/*---------------------------*/
/*     namespace Entidad     */
/*---------------------------*/
namespace Entidad
{
    public class Producto
    {
        private int Id = 0;
        private string Nombre = "";
        private int Precio = 0;
        private DateTime Fecha;

        public Producto() { }

        public Producto(int Id, string Nombre, int Precio, DateTime Fecha)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.Fecha = Fecha;
        }

        // Getters
        public int GetId() => Id;
        public string GetNombre() => Nombre;
        public int GetPrecio() => Precio;
        public DateTime GetFecha() => Fecha;

        // Setters
        public void SetId(int Id) => this.Id = Id;
        public void SetNombre(string Nombre) => this.Nombre = Nombre;
        public void SetPrecio(int Precio) => this.Precio = Precio;
        public void SetFecha(DateTime Fecha) => this.Fecha = Fecha;

        
    }
}

/*-------------------------------*/
/*   namespace Manipulacion      */
/*-------------------------------*/

namespace Manipulacion
{
    using Entidad;

    public class ProductoManipulacion
    {
        private Producto producto;

        public ProductoManipulacion(Producto producto)
        {
            this.producto = producto;
        }

        public ProductoManipulacion()
        {
            producto = new Producto();
        }

        //Insertar datos a la BD
        public bool InsertarProducto()
        {
            bool resultado = false;

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                try
                {
                    Conexion.Open();

                    string Query = "INSERT INTO producto (nombre, precio, fecha) VALUES (@nombre, @precio, @fecha);";
                    MySqlCommand comando = new MySqlCommand(Query, Conexion);

                    comando.Parameters.AddWithValue("@nombre", producto.GetNombre());
                    comando.Parameters.AddWithValue("@precio", producto.GetPrecio());
                    comando.Parameters.AddWithValue("@fecha", producto.GetFecha());

                    int filas = comando.ExecuteNonQuery();


                    if (resultado = filas > 0)
                    {
                        Console.WriteLine("Se ha guardado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No se ha guardado la información");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al insertar producto: " + e.Message);
                    throw;
                }
            }

            return resultado;
        }



    }





}



/*------------------------------*/
/*     namespace Consulta       */
/*------------------------------*/
namespace Consulta
{
    using Entidad;

    public class ProductoConsulta
    {
        //Consulta todos los Productos
        public List<Producto> ConsultaProducto()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                try
                {
                    Conexion.Open();

                    string Query = "SELECT * FROM producto;";
                    MySqlCommand comando = new MySqlCommand(Query, Conexion);
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto p = new Producto();
                        p.SetId(reader.GetInt32(0));
                        p.SetNombre(reader.GetString(1));
                        p.SetPrecio(reader.GetInt32(2));
                        p.SetFecha(reader.GetDateTime(3));

                        lista.Add(p);
                    }






                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al consultar productos: " + e.Message);
                    throw;
                }
            }

            return lista;
        }

        //Consulta los productos con cierto nombre
        public List<Producto> ConsultaProductoNombre(string Nombre)
        {
            List<Producto> lista = new List<Producto>();
            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {


                try
                {
                    Conexion.Open();
                    string Query = "SELECT * FROM producto WHERE Nombre = @Nombre";
                    MySqlCommand Comando = new MySqlCommand(Query, Conexion);
                    Comando.Parameters.AddWithValue("@Nombre", Nombre);
                    MySqlDataReader Reader = Comando.ExecuteReader();

                    while (Reader.Read())
                    {

                        Producto p = new Producto();
                        p.SetId(Reader.GetInt32(0));
                        p.SetNombre(Reader.GetString(1));
                        p.SetPrecio(Reader.GetInt32(2));
                        p.SetFecha(Reader.GetDateTime(3));

                        lista.Add(p);


                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine($"Error en -> {e.Message}");
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"Error en -> {e.Message}");
                    throw;
                }




            }
            return lista;
        }

        //Consulta los productos por precio
        public List<Producto> ConsultaProductoPrecio(int Precio)
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                Conexion.Open();

                string Query = "SELECT * FROM producto WHERE Precio = @Precio";
                MySqlCommand Comando = new MySqlCommand(Query, Conexion);
                Comando.Parameters.AddWithValue("@Precio", Precio);
                MySqlDataReader Reader = Comando.ExecuteReader();

                while (Reader.Read())
                {
                    Producto p = new Producto();
                    p.SetId(Reader.GetInt32(0));
                    p.SetNombre(Reader.GetString(1));
                    p.SetPrecio(Reader.GetInt32(2));
                    p.SetFecha(Reader.GetDateTime(3));

                    lista.Add(p);

                }
            }

            return lista;
        }

        //Consulta los productos por Fecha

        public List<Producto> ConsultaProductoFecha(DateTime Fecha)
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                try
                {

                    Conexion.Open();

                    string Query = "SELECT * FROM producto WHERE Fecha = @Fecha";

                    MySqlCommand Comando = new MySqlCommand(Query, Conexion);
                    Comando.Parameters.AddWithValue("@Fecha", Fecha);
                    MySqlDataReader Reader = Comando.ExecuteReader();

                    while (Reader.Read())
                    {
                        Producto p = new Producto();
                        p.SetId(Reader.GetInt32(0));
                        p.SetNombre(Reader.GetString(1));
                        p.SetPrecio(Reader.GetInt32(2));
                        p.SetFecha(Reader.GetDateTime(3));
                        lista.Add(p);

                    }

                }
                catch (MySqlException e)
                {

                    Console.WriteLine($"{e.Message}");

                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    throw;
                }


            }

            return lista;
        }
        public List<Producto> ConsultaProductoNombrePrecio(string Nombre, int Precio)
        {
            List<Producto>lista = new List<Producto>();

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                try
                {
                    string Query = "SELECT * FROM producto WHERE Nombre = @Nombre AND Precio = @Precio";
                    MySqlCommand Comando = new MySqlCommand(Query,Conexion);
                    Comando.Parameters.AddWithValue("@Nombre",Nombre);
                    Comando.Parameters.AddWithValue("@Precio",Precio);
                    MySqlDataReader Reader = Comando.ExecuteReader();
                    while (Reader.Read())
                    {
                        Producto p = new Producto();
                        p.SetId(Reader.GetInt32(0));
                        p.SetNombre(Reader.GetString(1));
                        p.SetPrecio(Reader.GetInt32(2));
                        p.SetFecha(Reader.GetDateTime(3));

                    }
                }
                catch(MySqlException e ){
                    Console.WriteLine($"{e.Message}");
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    throw;
                }
            }

        
         return lista;}
        public List<Producto> ConsultaProductoNombreFecha(string Nombre, DateTime Fecha)
        {
            List<Producto>lista = new List<Producto>();

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                try
                {
                    string Query = "SELECT * FROM producto WHERE Nombre = @Nombre AND Fecha = @Fecha";
                    MySqlCommand Comando = new MySqlCommand(Query,Conexion);
                    Comando.Parameters.AddWithValue("@Nombre", Nombre);
                    Comando.Parameters.AddWithValue("@Fecha",Fecha);
                    MySqlDataReader Reader = Comando.ExecuteReader();
                    while (Reader.Read())
                    {
                        Producto p = new Producto();
                        p.SetId(Reader.GetInt32(0));
                        p.SetNombre(Reader.GetString(1));
                        p.SetPrecio(Reader.GetInt32(2));
                        p.SetFecha(Reader.GetDateTime(3));

                    }
                }
                catch(MySqlException e ){
                    Console.WriteLine($"{e.Message}");
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    throw;
                }
            }

        
         return lista;}
        public List<Producto> ConsultaProductoPrecioFecha(int Precio, DateTime Fecha)
        {
            List<Producto>lista = new List<Producto>();

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                try
                {
                    string Query = "SELECT * FROM producto WHERE Precio = @Precio AND Fecha = @Fecha";
                    MySqlCommand Comando = new MySqlCommand(Query,Conexion);
                    Comando.Parameters.AddWithValue("@Precio",Precio);
                    Comando.Parameters.AddWithValue("@Fecha",Fecha);
                    MySqlDataReader Reader = Comando.ExecuteReader();
                    while (Reader.Read())
                    {
                        Producto p = new Producto();
                        p.SetId(Reader.GetInt32(0));
                        p.SetNombre(Reader.GetString(1));
                        p.SetPrecio(Reader.GetInt32(2));
                        p.SetFecha(Reader.GetDateTime(3));

                    }
                }
                catch(MySqlException e ){
                    Console.WriteLine($"{e.Message}");
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    throw;
                }
            }

        
         return lista;}


    }
}



/*------------------------------*/
/*     namespace Modificar      */
/*------------------------------*/



namespace Modificar
{
    using System;
    using MySql.Data.MySqlClient;
    using Entidad;
    

    public class ModificadorProducto
    {

        private Producto? p;

        public ModificadorProducto(Producto P)
        {
            this.p = P;
        }
        public ModificadorProducto()
        {

        }


        //Modificar Nombre -> por ID


        public bool ModificarNombre(string Nombre, int Id, bool Comprobador)
        {
            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {


                try
                {

                    Conexion.Open();

                    String Query = "UPDATE Producto SET Nombre = @Nombre  WHERE Id = @Id;";
                    MySqlCommand Comando = new MySqlCommand(Query, Conexion);
                    Comando.Parameters.AddWithValue("@Nombre", Nombre);
                    Comando.Parameters.AddWithValue("@Id", Id);

                    bool continuar = Comprobador;          
                    if (!continuar)
                    {
                        Console.WriteLine("Cancelando.......");
                        return false;
                    }
                     
                    int filas = Comando.ExecuteNonQuery();   

                    if (filas > 0)
                    {
                        return true;                         
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el Id......");
                        return false;                        
                    }
                    




                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);

                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Hay un error " + e.Message);
                    throw;
                }



            }

            return false;

        }

        


        // Modificar por Precio 
        public bool ModificarPrecio(int Id, int Precio, bool Comprobador)
        {

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {

                try
                {
                    Conexion.Open();

                    String Query = "UPDATE Producto SET precio = @Precio WHERE id = @Id;";
                    MySqlCommand Comando = new MySqlCommand(Query, Conexion);
                    Comando.Parameters.AddWithValue("@Precio", Precio);
                    Comando.Parameters.AddWithValue("@Id", Id);
                    bool continuar = Comprobador;          
                    if (!continuar)
                    {
                        Console.WriteLine("Cancelando.......");
                        return false;
                    }
                     
                    int filas = Comando.ExecuteNonQuery();   

                    if (filas > 0)
                    {
                        return true;                         
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el Id......");
                        return false;                        
                    }


                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }


            }


            return false;
        }

        //Modificador por Fecha 

        public bool ModificarFecha(DateTime Fecha, int Id, bool Comprobador)
        {

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                try
                {
                    Conexion.Open();

                    String Query = "UPDATE Producto SET fecha = @Fecha WHERE id = @Id ";
                    MySqlCommand Comando = new MySqlCommand(Query,Conexion);

                    Comando.Parameters.AddWithValue("@Fecha", Fecha);
                    Comando.Parameters.AddWithValue("@Id", Id);
                    bool continuar = Comprobador;          
                    if (!continuar)
                    {
                        Console.WriteLine("Cancelando.......");
                        return false;
                    }
                     
                    int filas = Comando.ExecuteNonQuery();   

                    if (filas > 0)
                    {
                        return true;                         
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el Id......");
                        return false;                        
                    }








                }
                catch (MySqlException e)
                {

                    Console.WriteLine("Error-> " + e.Message);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Error-> " + e.Message);

                    throw;
                }
            }
            return false;

        }



        //Modificar todo -> Nombre, Precio, Fecha


        public bool ModificarTotal(String Nombre, int Precio, DateTime Fecha, int Id, bool Comprobador)
        {
            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {
                try
                {
                    Conexion.Open();

                    String Query = "UPDATE producto SET Nombre = @Nombre , Precio = @Precio, Fecha = @Fecha WHERE id= @Id;";

                    MySqlCommand Comando = new MySqlCommand(Query,Conexion);
                    Comando.Parameters.AddWithValue("@Nombre", Nombre);
                    Comando.Parameters.AddWithValue("@Precio", Precio);
                    Comando.Parameters.AddWithValue("@Fecha", Fecha);

                    Comando.Parameters.AddWithValue("@Id", Id);
                    bool continuar = Comprobador;          
                    if (!continuar)
                    {
                        Console.WriteLine("Cancelando.......");
                        return false;
                    }
                     
                    int filas = Comando.ExecuteNonQuery();   

                    if (filas > 0)
                    {
                        return true;                         
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el Id......");
                        return false;                        
                    }





                }
                catch (MySqlException e)
                {

                    Console.WriteLine("Error........." + e.Message);
                }
                catch (System.Exception e)
                {

                    Console.WriteLine("Error........." + e.Message);
                    throw;
                }
            }

            return false;
        }




    }


}




/*------------------------------*/
/*     namespace Eliminar       */
/*------------------------------*/


namespace Eliminar
{
    using Entidad;
    using MySql.Data.MySqlClient;
    using System;
    public class EliminarProducto
    {

        Producto? p;

        public EliminarProducto(Producto p)
        {
            this.p = p;

        }


        public EliminarProducto()
        {

        }

        //Eliminar producto 

        public bool BorrarProducto(int Id, bool Comprobador)
        {

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {

                try
                {
                    Conexion.Open();
                string Query = "DELETE FROM producto WHERE Id = @Id ";


                MySqlCommand Comando = new MySqlCommand(Query, Conexion);
                Comando.Parameters.AddWithValue("@Id", Id);
                
                bool continuar = Comprobador;          
                    if (!continuar)
                    {
                        Console.WriteLine("Cancelando.......");
                        return false;
                    }
                     
                    int filas = Comando.ExecuteNonQuery();   

                    if (filas > 0)
                    {
                        return true;                         
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el Id......");
                        return false;                        
                    }

                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Error de excepcion " + e.Message);
                    throw;
                }


            }


            
        }



    }


}
