# (No tiene nombre aun)

Esta api res realiza un secillo crud de usuarios y cursos, ademas tambien cuenta con un end-point para la gestion de inicios de sesion y un end-point para ver todos los nombres de los cursos que se encuentran registrados en la base de datos.

## Requisitos Previos

Asegúrate de tener instalado:
- Visual Studio 2022
- .NET Core SDK (version net8.0)
- SQL Server (version 19.2)
- Git

## Instalación

### Descargar el Código Fuente

1. Abre una terminal o línea de comandos en la carpeta donde desees tener el proyecto.
2. Clona el repositorio con el siguiente comando:
git clone https://github.com/CarlosJoaoIpiales/resapi-asp.net-core-jwt-middleweare.git

### Configuración de la Base de Datos

1. Abre SQL Server Management Studio 19.
2. Conéctate a tu instancia de SQL Server.
3. En tu carpeta Databases da click derecho y busca la opcion de Restore DataBase y posteriormete busca el archivo script de la base de datos llamado dataBaseActividad6.sql

### Configuración del Proyecto

1. Abre la solución en Visual Studio.
2. Asegúrate de que las cadenas de conexión en el archivo `appsettings.json` sean correctas y apunten a tu instancia de SQL Server.
```
"ConnectionStrings": {
  "actividad_6Context": "server=localhost; database=activitie-6; integrated security=true; TrustServerCertificate=True"
}
```
(En caso de cambiar el server o el nombre de la base de datos, cambiar respectivamente sus valores en `server=` o en `database=`)
3. Restaura los paquetes NuGet.

## Uso

### Ejecución de la API

1. Ejecuta la API desde Visual Studio presionando F5 o usando el comando `dotnet run` desde la terminal.
2. La API debería estar ahora en ejecución y escuchando en los puertos especificados.
![Descripción de la imagen](https://i.ibb.co/9qpkjd4/Captura-de-pantalla-2023-12-03-160041.png)


### Autenticación y Autorización

- La API utiliza tokens JWT para autenticación.
- Envía una solicitud POST a `/api/LoginUser` con el formato json que se muestra a continuacion:
![Descripción de la imagen](https://i.ibb.co/hdR38Fh/Captura-de-pantalla-2023-12-03-160442.png)

- La respuesta incluye el token generado con JWT que posteriormente se utilizara para otro endpoint de la api, asi que guardalo (Los tokens tienen la duracion de una hora).

![Descripción de la imagen](https://i.ibb.co/PxXGDJ8/Captura-de-pantalla-2023-12-03-160807.png)

- Incluye el token en el encabezado `Authorization` de las solicitudes HTTP para acceder al endpoint de tipo  GET `/api/AllCourses` de la siguiente manera:

![Descripción de la imagen](https://i.ibb.co/qJVz98d/Captura-de-pantalla-2023-12-03-161354.png)

(Reemplaza "tu token" por el token generado por JWT al iniciar sesion, recuerda que el token tiene una duracion maxima de una hora)

![Descripción de la imagen](https://i.ibb.co/Y28K6t1/Captura-de-pantalla-2023-12-03-161745.png)


## Seguridad

- La API implementa seguridad mediante el uso de Middleware personalizado.
- Detalles sobre las medidas de seguridad implementadas (filtrado de IP, validación de solicitudes, etc.).

(Todas las peticiones se reflejaran en los logs que se muestran en la terminal debido a la implementacion de `Middleware` )

![Descripción de la imagen](https://i.ibb.co/mJtM0t8/Captura-de-pantalla-2023-12-03-161042.png)

## Contribuciones

Cualquier sugerencia comunicarse al correo cjipiales1@espe.edu.ec


###End
