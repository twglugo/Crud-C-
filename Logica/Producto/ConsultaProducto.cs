namespace Logica.Producto
{
    using Modelos.Producto;
    using Data;
    using System;   
    using MySql.Data.MySqlClient;

    public class ConsultaProducto
    {
        //Consulta todos los Productos
        public List<Producto> ConsultaProductoTotal()
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

        
         return lista;
         }

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