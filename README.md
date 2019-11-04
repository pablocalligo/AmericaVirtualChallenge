# America Virtual Challenge - ![](https://www.americavirtualsa.com/favicon-32x32.png)


## **Tecnologías utilizadas:**

* [Net Core 3](https://dotnet.microsoft.com/download/dotnet-core/3.0)
* [MongoDb](https://www.mongodb.com/es)

La base de datos se encuentra hosteada gratuitamente en https://www.clever-cloud.com/en/, pero no brinda un servicio para explorala.
Para poder observar la persistencia de los logs y usuarios cree un controller llamado "Admin".

## **Iniciar el proyecto:**
* Desde Visual Studio: Simplemente ejecutar el perfil llamado "Start", Automáticamente abrirá la página http://localhost:5000/swagger
* Desde linea de comando: ubicarse en la ruta "\AmericaVirtualChallenge\AmericaVirtualApi\" y ejecutar "dotnet run", luego en el explorador ir a "http://localhost:5000/swagger"

## **Configuración:**
Dentro del archivo "AmericaVirtualChallenge/AmericaVirtualApi/appsettings.json" se podrá determinar la cantidad de productos por página, modificando el valor de "ItemsPerPage"