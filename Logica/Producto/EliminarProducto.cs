namespace Logica.Producto
{
    using Modelos.Producto;
    using Data;
    using System;
    using MySql.Data.MySqlClient;
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