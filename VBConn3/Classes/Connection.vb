﻿Imports System.Threading
Public Class Connection

#Region "Singleton variables"
    ' For SyncLock to mark a critical section
    Private Shared classLocker As New Object()

    ' Allocate memory space to hold the 
    ' single object instance
    Private Shared _connection As Connection
#End Region

#Region "SQL variables"
    Private _stringbuilder As SqlClient.SqlConnectionStringBuilder
    Private _sqlconnection As SqlClient.SqlConnection
    Private _sqlcommand As SqlClient.SqlCommand
#End Region

    '#Region "Local variables"
    '    'Nombre y extención del archivo donde se guarda la conexión
    '    Private _nombre_archivo As String

    '    'Ruta donde se guarda el archivo de conexión
    '    Private _ruta_archivo_conexion As String
    '#End Region

#Region "Properties"
    Public Property DataBase() As String
        Get
            Return _stringbuilder.InitialCatalog
        End Get
        Set(value As String)
            _stringbuilder.InitialCatalog = value
        End Set
    End Property
    Public Property DataSource() As String
        Get
            Return _stringbuilder.DataSource
        End Get
        Set(value As String)
            _stringbuilder.DataSource = value
        End Set
    End Property
    Public Property User() As String
        Get
            Return _stringbuilder.UserID
        End Get
        Set(value As String)
            _stringbuilder.UserID = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _stringbuilder.Password
        End Get
        Set(value As String)
            _stringbuilder.Password = value
        End Set
    End Property
#End Region

#Region "Constructor"
    ' Hace el único constructor privado
    ' para prevenir la inicialización por fuera de la clase.
    Private Sub New()
        _stringbuilder = New SqlClient.SqlConnectionStringBuilder()
        _nombre_archivo = "Conexion.txt"
        _ruta_archivo_conexion = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\"
    End Sub
#End Region

#Region "Methods"


    Public Sub Generate()
        Dim frmConnectionGenerate As New frmGenerateConnection()
        frmConnectionGenerate.ShowDialog()
        frmConnectionGenerate.Dispose()
    End Sub
#End Region

#Region "Functions"
    ''' <summary>
    ''' Expose getInstance() for the retrieval of the single object instance.
    ''' </summary>
    ''' <returns>Returns a Connection class object</returns>
    Public Shared Function getInstance() As Connection

        ' Initialize singleton through lazy 
        ' initialization to prevent unused 
        ' singleton from taking up program 
        ' memory
        If (_connection Is Nothing) Then
            ' Mark a critical section where 
            ' threads take turns to execute
            SyncLock (classLocker)
                If (_connection Is Nothing) Then
                    _connection = New Connection()
                End If
            End SyncLock
        End If
        Return _connection

    End Function



    ''' <summary>
    ''' Executes a Transact-SQL statement against the connection and returns the number of rows affected.
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    Public Function ExecuteNonQuery(ByVal query As String) As Integer
        _sqlcommand.CommandText = query
        Try
            If _sqlcommand.Connection.State = ConnectionState.Closed Then
                _sqlcommand.Connection.Open() : End If

            Return _sqlcommand.ExecuteNonQuery
        Catch ex As Exception
            MessageBox.Show("No se pudo ejecutar la consulta sql. La excepción dice: " & ex.Message, "Conexion.cs", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return 0
        Finally
            _sqlcommand.Connection.Close()
        End Try

    End Function

    Public Function ExecuteScalar(ByVal query As String) As Object
        _sqlcommand.CommandText = query
        Try
            If _sqlcommand.Connection.State = ConnectionState.Closed Then
                _sqlcommand.Connection.Open() : End If

            Return _sqlcommand.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show("No se pudo ejecutar la consulta sql. La excepción dice: " & ex.Message, "Conexion.cs", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return Nothing
        Finally
            _sqlcommand.Connection.Close()
        End Try
    End Function

    Public Overrides Function ToString() As String
        Return _stringbuilder.ToString
    End Function
#End Region
End Class