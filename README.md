# 🧩 CRUD en C# con MySQL

Este proyecto es una aplicación de consola desarrollada en **C#** que implementa operaciones **CRUD** (Crear, Leer, Actualizar, Eliminar) sobre una base de datos MySQL. Ideal para practicar conceptos fundamentales de programación y gestión de bases de datos.

---

## 📁 Estructura del Proyecto

- `Entidad/`: Clase `Producto.cs` con atributos, constructores, getters y setters.
- `Manipulacion/`: Métodos para insertar productos en la base de datos.
- `Consulta/`: Consulta de registros en la tabla `producto`.
- `Modificar/`: Métodos para modificar nombre, precio, fecha o todo el registro.
- `Eliminar/`: Eliminación de productos por ID.
- `MenuInteractivo/`: Menú principal para interactuar con las operaciones.
- `Program.cs`: Punto de entrada principal del proyecto.

---

## 💾 Base de Datos

Nombre del archivo: `bdCrud.sql`

Tabla principal: `producto`

Asegúrate de tener MySQL instalado y ejecutar el script `bdCrud.sql` para crear la base de datos y la tabla antes de ejecutar el programa.

---

## ⚙️ Requisitos

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [MySQL.Data Connector](https://www.nuget.org/packages/MySql.Data/)
- Visual Studio o Visual Studio Code

---

## 🧪 Cómo ejecutar el proyecto

```bash
git clone https://github.com/twglugo/Crud-C-.git
cd Crud-C-
dotnet restore
dotnet run
