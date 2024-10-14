# Nectia Software - Gestión de Vehículos

## Descripción

Nectia Software es una aplicación web diseñada para la gestión de vehículos. Permite a los usuarios agregar, editar y eliminar vehículos, así como realizar un seguimiento en tiempo real y generar informes detallados.

## Características

- **Gestión de Vehículos**: Agrega, edita y elimina vehículos fácilmente.
- **Seguimiento en Tiempo Real**: Monitorea el estado de tus vehículos en tiempo real.
- **Informes Detallados**: Genera informes para una mejor toma de decisiones.

## Tecnologías Utilizadas

- **ASP.NET Core 8**: Framework para el desarrollo de aplicaciones web.
- **Entity Framework Core**: ORM para acceder a bases de datos.
- **SQL Server**: Base de datos utilizada para almacenar la información de los vehículos.
- **Bootstrap**: Framework CSS para el diseño responsivo y atractivo.

## Requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/frabenitez94/WebNectiaSoftware.git
   ```

2. Navega al directorio del proyecto:

   ```bash
   cd nombres-repo
   ```

3. Restaura las dependencias:

   ```bash
   dotnet restore
   ```

4. Configura la cadena de conexión en `appsettings.json`:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=NECTIASOFTWARE;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

5. **Ejecuta el archivo `Script.sql`** que se encuentra en el repositorio para crear las tablas y la estructura de la base de datos. Puedes ejecutar este script usando SQL Server Management Studio (SSMS) o cualquier herramienta de administración de bases de datos.

6. Aplica las migraciones de la base de datos (si es necesario):

   ```bash
   dotnet ef database update
   ```

7. Inicia la aplicación:

   ```bash
   dotnet run
   ```

## Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir a este proyecto, por favor sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu característica o corrección de errores:
   ```bash
   git checkout -b feature/nueva-caracteristica
   ```
3. Realiza tus cambios y haz un commit:
   ```bash
   git commit -m "Añadir nueva característica"
   ```
4. Envía tus cambios:
   ```bash
   git push origin feature/nueva-caracteristica
   ```
5. Crea un Pull Request.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Contacto

Para más información, contacta a [tu-email@example.com](mailto:frabenitez94@gmail.com).
