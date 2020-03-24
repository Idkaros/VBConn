Public Class Conexion

#Region "SQL variables"
    Private _stringbuilder As SqlClient.SqlConnectionStringBuilder
    Private _sqlconnection As SqlClient.SqlConnection
    Private _sqlcommand As SqlClient.SqlCommand
#End Region

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
    Sub New()
        _stringbuilder = New SqlClient.SqlConnectionStringBuilder()
    End Sub
#End Region


#Region "Functions"

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