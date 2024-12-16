# API CRUD Students

Este proyecto contiene una API web que realiza un CRUD sobre la tabla **Students** de la base de datos.

## Ejecución Local

Para ejecutar el proyecto de manera local, sigue estos pasos:

1. **Cambiar la cadena de conexión**:
   - En el archivo `appsettings.json`, actualiza la cadena de conexión bajo la propiedad `ConnectionStrings` para que apunte a una base de datos válida en tu entorno local.

2. **Instalar la herramienta dotnet-ef**:
   - Para ejecutar las migraciones y mantener la base de datos actualizada, necesitas instalar la herramienta `dotnet-ef`. Ejecuta el siguiente comando desde tu terminal o consola:
     ```bash
     dotnet tool install --global dotnet-ef
     ```

3. **Ejecutar las migraciones**:
   - Luego de instalar `dotnet-ef`, navega a la raíz del proyecto y ejecuta el siguiente comando para aplicar las migraciones y crear la base de datos:
     ```bash
     dotnet ef database update
     ```
   - Esto aplicará las migraciones definidas en el proyecto y generará una base de datos con datos de ejemplo.

4. **Ejecutar el proyecto**:
   - Finalmente, ejecuta el proyecto utilizando el botón **Play** en **Visual Studio**.
   - Esto iniciará el servidor y abrirá una ventana en tu navegador con Swagger UI, donde podrás ver y probar todos los endpoints de la API.

## Endpoints disponibles

### GET /api/students
Obtiene la lista de todos los estudiantes registrados.

### GET /api/students/{studentId}
Obtiene los detalles de un estudiante específico basado en su `StudentId`.

### POST /api/students
Crea un nuevo estudiante en la base de datos.

### PUT /api/students/{studentId}
Actualiza los detalles de un estudiante existente en la base de datos.

### DELETE /api/students/{studentId}
Elimina un estudiante específico basado en su `StudentId`.

## Tecnología utilizada

- **.NET 8** para la implementación de la API.
- **Entity Framework Core** para la gestión de la base de datos y las migraciones.
- **Swagger** para la documentación interactiva de la API.
- **SQL Server** como base de datos.

## Notas

- Asegúrate de tener una versión compatible de .NET Core (versión 8 o superior) instalada en tu máquina para ejecutar el proyecto correctamente.
- Si tienes algún problema al ejecutar las migraciones o al correr la API, asegúrate de revisar la configuración de tu base de datos y la cadena de conexión.



