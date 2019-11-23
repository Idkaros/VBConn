# VBConn
# Lenguaje
Visual Basic .NET (VB.NET)

# Objetivo
Crear un proyecto que gestione una cadena de conexión contra un motor de base de datos Microsoft SQL Server.
Para ello el proyecto deberá poder solicitar los datos de la conexión al usuario, probar la conexión contra el motor de BD, escribir la cadena conexión en un archivo de texto plano, leer la cadena desde el archivo y actualizar la cadena en el archivo.

Se creará una clase Connection con el patrón de diseño singleton y un formulario para la configuración de la conexión.
La clase tendrá las siguientes funciones y métodos:
1. getInstance	: devuelve la unica instancia de la clase que llegará a existir.
2. ExistConfigFile	: devuelve un valor booleano tanto por si existe o no el archivo donde se guarda la cadena de conexión a la base de datos.
3. Generate		: levanta el formulario para generar la conexión.
4. Save		:
5. Read		:

# Lógica
Se deberá validar la existencia del archivo de configuración para generar la conexión.