namespace Logica.Producto
{
    using System;
    using Modelos.Producto;
    using Data;
    using MySql.Data.MySqlClient;
    

    public class ModificarProducto
    {

        private Producto? p;

        public ModificarProducto(Producto P)
        {
            this.p = P;
        }
        public ModificarProducto()
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