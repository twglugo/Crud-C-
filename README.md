
# 🛠️ CRUD de Productos en C# y MySQL

Este es un sistema de consola en C# que permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre productos, utilizando una base de datos MySQL. Está organizado por namespaces para mantener una arquitectura limpia y modular.

---

## 📦 Funcionalidades

- ✅ Insertar productos (nombre, precio y fecha) *(¡próximamente campo "cantidad"!)*
- ✅ Consultar productos:
  - Todos
  - Por nombre
  - Por precio
  - Por fecha
  - Por combinaciones (nombre y precio, nombre y fecha, etc.)
- ✅ Modificar:
  - Nombre
  - Precio
  - Fecha
  - Todos los campos a la vez
- ✅ Eliminar productos por ID

---

### 🧩 Organización por capas

| Capa             | Función principal                                      |
|------------------|--------------------------------------------------------|
| `Modelo`         | Entidades que representan la estructura de datos      |
| `Logica`         | Operaciones de negocio (CRUD puro)                    |
| `Controlador`    | Coordina acciones entre lógica y entrada de usuario   |
| `InterfazUsuario`| Entrada/salida por consola y navegación de menús      |
| `Data`           | Manejo de la conexión a la base de datos              |
| `Script`         | Documento de Bd o relacionados a información          |

---

## 💽 Base de datos

Usa MySQL y el script `bdCrud.sql` para crear la tabla `producto`.

### Estructura esperada:

```sql
CREATE TABLE producto (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100),
    Precio INT,
    Fecha DATETIME
);
```

---

## 🚀 ¿Cómo ejecutar?

1. Clona el repositorio:
```bash
git clone https://github.com/twglugo/Crud-C-.git
```

2. Abre el proyecto con Visual Studio o Visual Studio Code.

3. Asegúrate de tener una base de datos MySQL corriendo y actualiza la cadena de conexión en `Conecta.cs`.

4. Ejecuta el proyecto desde el archivo `Program.cs`.

---

## 🧠 Tecnologías usadas

- Lenguaje: `C#`
- Base de datos: `MySQL`
- Acceso a datos: `MySql.Data` (via NuGet)
- IDE sugerido: `Visual Studio 2022`

---

## 📸 Ejemplo de uso 

Proximamente fotos de proyecto

---

## 🙋 Autor

- **Miguel Lugo**
- GitHub: [@twglugo](https://github.com/twglugo)

---

## 📃 Licencia

Este proyecto es de uso libre para aprendizaje.
