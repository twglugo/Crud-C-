using System;

/*---------------------------*/
/*     namespace Producto     */
/*---------------------------*/
namespace Modelos.Producto
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

