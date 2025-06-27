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
                    foreach (Entidad.Producto p in lista)
                    {
                        Console.WriteLine("ID: " + p.GetId());
                        Console.WriteLine("Nombre: " + p.GetNombre());
                        Console.WriteLine("Precio: " + p.GetPrecio());
                        Console.WriteLine("Fecha: " + p.GetFecha());
                        Console.WriteLine("-------------------------");





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

        Producto p;

        public ModificadorProducto(Producto P)
        {
            this.p = P;
        }
        public ModificadorProducto()
        {

        }


        //Modificar Nombre -> por ID


        public bool ModificarNombre(string Nombre, int Id)
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
                    Console.Write("¿Deseas ejecutar el cambio? (S/N): ");
                    String? Op = Console.ReadLine();
                    if (Op.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Comando.ExecuteNonQuery() > 0)
                        {

                            Console.WriteLine("Cambio realizado............................");
                            return true;

                        }
                        else
                        {
                            Console.WriteLine("No se realizo el cambio no se encontro el ID");

                        }

                    }
                    else if (Op.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Cancelando..................................");

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
        public bool ModificarPrecio(int Id, int Precio)
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
                    Console.Write("¿Deseas ejecutar el cambio? (S/N): ");
                    String? Op = Console.ReadLine();

                    if (Op.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {

                        if (Comando.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido modificar ");
                            return false;
                        }



                    }
                    else if (Op.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Cancelando........................");
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

        public bool ModificarFecha(DateTime Fecha, int Id)
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
                    Console.WriteLine("¿Deseas ejecutar el cambio? (S/N): ");
                    String? Op = Console.ReadLine();
                    if (Op.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {

                        if (Comando.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Se ha actualizado con exito ");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Ha habido un error....................");
                           
                            return false;
                        }
                    }
                    else if (Op.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {

                        Console.WriteLine("Cancelando................................");
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


        public bool ModificarTotal(String Nombre, int Precio, DateTime Fecha, int Id)
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
                    Console.WriteLine("¿Deseas ejecutar el cambio? (S/N): ");
                    String? Op = Console.ReadLine();

                    if (Op.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Comando.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Modificando....................");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Error......................");
                            return false;
                        }



                    }
                    else if (Op.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Cancelando.....................");
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

        public bool BorrarProducto(int Id)
        {

            using (MySqlConnection Conexion = Conecta.ObtenerConexion())
            {

                try
                {
                    Conexion.Open();
                string Query = "DELETE FROM producto WHERE Id = @Id ";


                MySqlCommand Comando = new MySqlCommand(Query, Conexion);
                Comando.Parameters.AddWithValue("@Id", Id);
                
                Console.Write("¿Deseas Eliminar el Producto? (S/N): ");
                String? Opcion = Console.ReadLine();

                if (Opcion.Equals("S", StringComparison.OrdinalIgnoreCase))
                {

                        if (Comando.ExecuteNonQuery() > 0)
                        {

                            Console.WriteLine("Se ha borrado el producto con exito");
                            return true; 

                    }
                        else
                        {

                            Console.WriteLine("Error no se ha encontrado el id : " + Id);
                        }

                }
                else
                {
                    Console.WriteLine("Se nego la operacion");
                }

                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Error de excepcion " + e.Message);
                    throw;
                }


            }


            return false;
        }



    }


}
