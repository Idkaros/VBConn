# VBConn
# Lenguaje
Visual Basic .NET (VB.NET)

# Objetivo
Crear un proyecto que gestione una cadena de conexi�n contra un motor de base de datos Microsoft SQL Server.
Para ello el proyecto deber� poder solicitar los datos de la conexi�n al usuario, probar la conexi�n contra el motor de BD, escribir la cadena conexi�n en un archivo de texto plano, leer la cadena desde el archivo y actualizar la cadena en el archivo.

Se crear� una clase Connection con el patr�n de dise�o singleton y un formulario para la configuraci�n de la conexi�n.
La clase tendr� las siguientes funciones y m�todos:
1. getInstance	: devuelve la unica instancia de la clase que llegar� a existir.
2. ExistConfigFile	: devuelve un valor booleano tanto por si existe o no el archivo donde se guarda la cadena de conexi�n a la base de datos.
3. Generate		: levanta el formulario para generar la conexi�n.
4. Save		:
5. Read		:

# L�gica
Se deber� validar la existencia del archivo de configuraci�n para generar la conexi�n.