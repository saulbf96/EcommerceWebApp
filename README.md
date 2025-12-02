E-commerce Project

E-commerce es una aplicación de comercio electrónico desarrollada con .NET Core 8. Este proyecto está actualmente en desarrollo y busca servir como base para una plataforma de venta en línea moderna y escalable. Cada avance y actualización se sube a GitHub para mantener un historial de cambios y facilitar la colaboración.

Estructura del Proyecto

El proyecto está dividido en varios módulos para mantener un diseño limpio y modular:

ecommerce.WebApp: Aplicación principal basada en MVC, que maneja la interfaz de usuario y la lógica de presentación.

ecommerce.DataAccess: Proyecto dedicado a la capa de acceso a datos, separado para mantener independencia y facilitar pruebas.

ecommerce.Models: Contiene todas las entidades y modelos de datos del proyecto.

ecommerce.Utility: Funcionalidades y utilidades compartidas que pueden ser usadas en diferentes partes del proyecto.

ecommerceWebRazor_Temp: Proyecto experimental para aprender Razor Pages, CRUD y conexión a base de datos con EF Core. Sirve como laboratorio temporal para probar funcionalidades antes de integrarlas en la aplicación principal.

Tecnologías y Herramientas

.NET Core 8

Entity Framework Core
 (EF Core) para acceso a base de datos

MVC (Model-View-Controller)

Razor Pages (en proyecto experimental)

Git & GitHub para control de versiones

Estado del Proyecto

Actualmente el proyecto está en desarrollo. Se van agregando nuevas funcionalidades de forma incremental y cada cambio se sube al repositorio para que otros puedan seguir el progreso.

Instalación

Para ejecutar el proyecto localmente:

Clonar el repositorio:

git clone https://github.com/saulbf96/ecommerce.git


Abrir la solución en Visual Studio 2019 o superior.

Restaurar los paquetes NuGet.

Configurar la cadena de conexión en appsettings.json.

Ejecutar ecommerce.WebApp como proyecto de inicio.

Para probar ecommerceWebRazor_Temp, selecciona ese proyecto como inicio y configura su propia cadena de conexión.

Contribuciones

Este proyecto está abierto a contribuciones y sugerencias. Si deseas colaborar:

Haz un fork del repositorio.

Crea una rama para tu feature (git checkout -b feature/nueva-funcionalidad).

Haz commit de tus cambios (git commit -m "Agrega nueva funcionalidad").

Envía un pull request al repositorio principal.

Contacto

Si quieres contactarme sobre el proyecto, puedes hacerlo a través de mi perfil de GitHub.
