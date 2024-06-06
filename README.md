# Prueba Lunaservicios
**Versión 1.0.0**

Desarrollo de una aplicación web ASP.NET con API REST para el control de Clientes (CRUD). Este proyecto utiliza el patrón de diseño MVC para proporcionar una vista simple que facilita la interacción del usuario con los controladores. Se han creado servicios y repositorios en el directorio de la aplicación debido a su tamaño reducido, con el objetivo de mejorar la comprensión y escalabilidad del proyecto. Además, se implementó la opción de eliminar un cliente de forma lógica, aunque esta funcionalidad no está disponible en las vistas.

Para la creación de la base de datos SQLite se ha utilizado el paquete `Microsoft.EntityFrameworkCore.Sqlite`, simplificando así la interacción con la base de datos.

El sistema utiliza `Microsoft.Extensions.Logging` para generar logs en la consola en tiempo de ejecución, con mensajes detallados y personalizados según la situación presentada.

## Endpoints en Postman

Los endpoints y los datos necesarios para interactuar con los controladores son los siguientes:

- **Obtener todos los clientes**: `GET https://localhost:7136/api/ClientAPI`
- **Obtener un cliente por ID**: `GET https://localhost:7136/api/ClientAPI/{id}` (donde `{id}` es el ID del cliente a buscar)
- **Crear un cliente**: `POST https://localhost:7136/api/ClientAPI`
  - **Cuerpo (raw/json)**:
    ```json
    {
        "FirstName": "Nombre",
        "LastName": "Apellido",
        "Email": "email@dominio.com",
        "State": "Estado"
    }
    ```
- **Actualizar un cliente**: `PUT https://localhost:7136/api/ClientAPI/{id}` (donde `{id}` es el ID del cliente a modificar)
  - **Cuerpo (raw/json)**:
    ```json
    {
        "Id": "valor_de_id",
        "FirstName": "Nombre",
        "LastName": "Apellido",
        "Email": "email@dominio.com",
        "State": "Estado"
    }
    ```