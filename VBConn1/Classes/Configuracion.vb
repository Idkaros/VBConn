Public Class Configuracion

#Region "Variables del singleton"
    ' For SyncLock to mark a critical section
    Private Shared classLocker As New Object()

    ' Allocate memory space to hold the 
    ' single object instance
    Private Shared _configuracion As Configuracion
#End Region

#Region "Variables SQL"
    Private _stringbuilder As SqlClient.SqlConnectionStringBuilder
#End Region

#Region "Variables del archivo de configuración"
    'Nombre y extención del archivo donde se guarda la conexión
    Private _nombre_archivo As String

    'Ruta donde se guarda el archivo de conexión
    Private _ruta_archivo_conexion As String
#End Region

#Region "Constructor"
    ' Hacemos un único constructor privado
    ' para prevenir la inicialización por fuera de la clase.
    Private Sub New()
        _ruta_archivo_conexion = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\"
        _nombre_archivo = "Conexion.txt"
    End Sub
#End Region

#Region "Propiedades"
    Public ReadOnly Property StringBuilder() As SqlClient.SqlConnectionStringBuilder
        Get
            Return _stringbuilder
        End Get
    End Property

    Public WriteOnly Property DataSource()
        Set(value)
            _stringbuilder.DataSource = value
        End Set
    End Property

    Public WriteOnly Property DataBase()
        Set(value)
            _stringbuilder.InitialCatalog = value
        End Set
    End Property

    Public WriteOnly Property User()
        Set(value)
            _stringbuilder.UserID = value
        End Set
    End Property

    Public WriteOnly Property Password()
        Set(value)
            _stringbuilder.Password = value
        End Set
    End Property

#End Region

#Region "Métodos"
    ''' <summary>
    ''' Valida que exita el archivo de configuración, posteriormente lo lee y carga en una variable local SqlConnectionStringBuilder
    ''' </summary>
    Public Sub Leer()
        Try
            If Not ExisArchCone() Then
                Throw New Exception("No existe el archivo Configuracion.txt.")
            End If
            _stringbuilder = New SqlClient.SqlConnectionStringBuilder(My.Computer.FileSystem.ReadAllText(_ruta_archivo_conexion & _nombre_archivo))
        Catch ex As Exception
            MessageBox.Show("No se pudo leer el archivo de configuracion de texto plano. La excepción dice: " & ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub


    Public Sub Guardar()
        Dim writer As System.IO.StreamWriter
        writer = My.Computer.FileSystem.OpenTextFileWriter(_ruta_archivo_conexion & _nombre_archivo, False)
        writer.WriteLine(_stringbuilder.ToString)
        writer.Close()
    End Sub

    Public Sub Generar()
        Dim frmConnectionGenerate As New frmGenerarConfiguracion()
        frmConnectionGenerate.ShowDialog()
        frmConnectionGenerate.Dispose()
    End Sub

    Public Sub ElimArch()
        My.Computer.FileSystem.DeleteFile(_ruta_archivo_conexion & _nombre_archivo)
    End Sub
#End Region

#Region "Funciones"

    ''' <summary>
    ''' Expose getInstance() for the retrieval of the single object instance.
    ''' </summary>
    ''' <returns>Returns a Connection class object</returns>
    Public Shared Function getInstance() As Configuracion

        ' Initialize singleton through lazy 
        ' initialization to prevent unused 
        ' singleton from taking up program 
        ' memory
        If (_configuracion Is Nothing) Then
            ' Mark a critical section where 
            ' threads take turns to execute
            SyncLock (classLocker)
                If (_configuracion Is Nothing) Then
                    _configuracion = New Configuracion()
                End If
            End SyncLock
        End If
        Return _configuracion

    End Function

    ''' <summary>
    ''' Verifica si existe el archivo Conexion.txt en la ruta correspondiente.
    ''' </summary>
    ''' <returns>Retorna boleano</returns>
    ''' <remarks></remarks>
    Public Function ExisArchCone() As Boolean
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(_ruta_archivo_conexion & _nombre_archivo) Then
            Return True : End If
        Return False
    End Function
#End Region
End Class
