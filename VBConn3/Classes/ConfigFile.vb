Public Class ConfigFile

#Region "SQL variables"
    Private _stringbuilder As SqlClient.SqlConnectionStringBuilder
    'Private _sqlconnection As SqlClient.SqlConnection
    'Private _sqlcommand As SqlClient.SqlCommand
#End Region

#Region "Local variables"
    'Nombre y extención del archivo donde se guarda la conexión
    Private _nombre_archivo As String

    'Ruta donde se guarda el archivo de conexión
    Private _ruta_archivo_conexion As String
#End Region

#Region "Métodos"
    Public Sub Read()
        Try
            If Not ExistConfigFile() Then
                Throw New Exception("No existe el archivo Configuracion.txt.")
            End If
            _stringbuilder = New SqlClient.SqlConnectionStringBuilder(My.Computer.FileSystem.ReadAllText(_ruta_archivo_conexion & _nombre_archivo))
            '_sqlconnection = New SqlClient.SqlConnection(_stringbuilder.ToString)
            '_sqlcommand = New SqlClient.SqlCommand
            '_sqlcommand.Connection = _sqlconnection


        Catch ex As Exception
            MessageBox.Show("No se pudo leer la parametrización. La excepción dice: " & ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub

    Public Sub Save()
        Dim writer As System.IO.StreamWriter
        writer = My.Computer.FileSystem.OpenTextFileWriter(_ruta_archivo_conexion & _nombre_archivo, False)
        writer.WriteLine(_stringbuilder.ToString)
        writer.Close()
    End Sub

#End Region


    ''' <summary>
    ''' Verifica si existe el archivo Conexion.txt en la ruta correspondiente.
    ''' </summary>
    ''' <returns>Retorna boleano</returns>
    ''' <remarks></remarks>
    Public Function ExistConfigFile() As Boolean
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(_ruta_archivo_conexion & _nombre_archivo) Then
            Return True : End If
        Return False
    End Function
End Class
