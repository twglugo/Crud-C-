namespace Logica.Producto
{
    using Modelos.Producto;
    using Data;
    using MySql.Data.MySqlClient;

    public class InserccionProducto
    {
        private Producto producto;

        public InserccionProducto(Producto producto)
        {
            this.producto = producto;
        }

        public InserccionProducto()
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
