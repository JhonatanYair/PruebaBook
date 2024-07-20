# Proyecto de Prueba Técnica

Este proyecto es una prueba técnica que demuestra el uso de tecnologías modernas para el desarrollo de aplicaciones. El proyecto utiliza PostgreSQL como sistema de gestión de bases de datos, .NET 8 para la API, y Blazor para el frontend. 

## Tecnologías Utilizadas

- **Base de Datos:** PostgreSQL
- **API:** .NET 8
- **Frontend:** Blazor

## Requisitos

- Docker
- Docker Compose

## Instalación y Despliegue

Para construir y desplegar el proyecto, sigue estos pasos:

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/JhonatanYair/PruebaBook.git
   cd PruebaBook
   ```

2. **Construye y levanta los contenedores utilizando Docker Compose:**

   ```bash
   docker-compose up -d
   ```

   Este comando creará e iniciará los contenedores necesarios para PostgreSQL, la API en .NET 8 y el frontend Blazor.

3. **Accede a la aplicación:**

   - La API estará disponible en: `http://localhost:<PUERTO_API>`
   - El frontend Blazor estará disponible en: `http://localhost:<PUERTO_BLazor>`

   Asegúrate de reemplazar `<PUERTO_API>` y `<PUERTO_BLazor>` con los puertos configurados en tu archivo `docker-compose.yml`.

## Estructura del Proyecto

- **API (.NET 8):** Implementada en el contenedor correspondiente, contiene los controladores y servicios necesarios para manejar la lógica de negocio.
- **Frontend (Blazor):** Proporciona la interfaz de usuario y está disponible en el contenedor de Blazor.
- **Base de Datos (PostgreSQL):** Gestionada a través de un contenedor Docker, se utiliza para almacenar los datos de la aplicación.

## Configuración

1. **Archivos de Configuración:**

   - Ajusta los parámetros de conexión a la base de datos en el archivo `appsettings.json` según los valores definidos en el archivo `docker-compose.yml`.

2. **Modificación de Puertos:**

   - Si necesitas cambiar los puertos de la API o del frontend, edita el archivo `docker-compose.yml` y actualiza los valores correspondientes.

## Notas Adicionales

- Asegúrate de tener Docker y Docker Compose instalados y en ejecución en tu máquina.
- Puedes revisar los logs de los contenedores con el comando:

   ```bash
   docker-compose logs
   ```