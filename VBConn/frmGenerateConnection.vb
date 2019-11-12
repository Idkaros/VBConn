Public Class frmGenerateConnection
    ' Se instancia en el load del form
    Dim _connection As Connection

#Region "Local variables"

#End Region

#Region "Eventos"
    Private Sub btnProbar_Click(sender As Object, e As EventArgs) Handles btnProbar.Click
        Try
            ValidarCampos()
            ProbarConexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'cancelar_todo = True
        Me.Close()
    End Sub

    Private Sub frmParametrizarConexion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Escape)
                Me.Close()
        End Select
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ValidarCampos()
            LoadStringBuilder()
            'Validar conexión para guardar
            If ValidarConexion() Then
                _connection.Save()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
        Me.Close()
    End Sub

    Private Sub frmParametrizarConexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _connection = _connection.getInstance()

        ' If config file exists loads the connection string
        ' This is meant for connection string modification
        If _connection.ExistsConfigFile Then
            LoadControls() : End If
    End Sub
#End Region

#Region "Métodos propios"
    Private Sub ProbarConexion()
        Dim stringbuilder As New SqlClient.SqlConnectionStringBuilder
        stringbuilder.DataSource = txtServidor.Text
        stringbuilder.InitialCatalog = txtBaseDatos.Text
        stringbuilder.UserID = txtUsuario.Text
        stringbuilder.Password = txtContrasena.Text

        Dim sqlcon As New SqlClient.SqlConnection(stringbuilder.ToString)

        Try
            sqlcon.Open()
            If sqlcon.State = ConnectionState.Open Then
                MessageBox.Show("Conexión exitosa!", "Excelente!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            sqlcon.Close()
        End Try
    End Sub

    Private Sub ValidarCampos()
        If txtServidor.Text.Trim = "" Then
            Throw New Exception("Debe definir un servidor de base de datos ha conectar.")
        End If

        If txtBaseDatos.Text.Trim = "" Then
            Throw New Exception("Debe definir una base de datos de trabajo.")
        End If

        If txtUsuario.Text.Trim = "" Then
            Throw New ArgumentException("Debe definir un usuario para la conexión.")
        End If

        If txtContrasena.Text.Trim = "" Then
            Throw New ArgumentException("Debe definir una contraseña de usuario para la conexión.")
        End If
    End Sub

    'Private Sub GuardarConexionEnTexto()
    '    Dim escritor As System.IO.StreamWriter
    '    escritor = My.Computer.FileSystem.OpenTextFileWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Conexion.txt", False)
    '    escritor.WriteLine(_connection.ToString)
    '    escritor.Close()
    '    Me.Close()
    'End Sub

    ''' <summary>
    ''' Loads the string builder connection object from the parameters controls
    ''' </summary>
    Private Sub LoadStringBuilder()
        _connection.DataSource = txtServidor.Text
        _connection.DataBase = txtBaseDatos.Text
        _connection.User = txtUsuario.Text
        _connection.Password = txtContrasena.Text
    End Sub

    Private Sub LoadControls()
        Try
            'Loads de config file into the connection object
            'cadcon = New SqlClient.SqlConnectionStringBuilder(My.Computer.FileSystem.ReadAllText(frmPrincipal.Conexion.ruta_archivo_conexion))
            _connection.Read()
            txtServidor.Text = _connection.DataSource
            txtBaseDatos.Text = _connection.DataBase
            txtUsuario.Text = _connection.User
            txtContrasena.Text = _connection.Password
        Catch ex As Exception
            MessageBox.Show("Inconvenientes al carga parametros. La excepción dice: " & ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub

    Private Sub txtContrasena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                'Funciona
                'btnProbar.Select()
                Me.SelectNextControl(txtContrasena, True, True, True, True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Functions"
    Private Function ValidarConexion() As Boolean
        Dim sqlcon As New SqlClient.SqlConnection(_connection.ToString)
        Dim result As Boolean = False
        Try
            sqlcon.Open()
            'Si la conexión se abrió de forma exitosa
            If sqlcon.State = ConnectionState.Open Then
                result = True
            End If
        Catch ex As Exception
            If MessageBox.Show(ex.Message & vbCrLf & "¿Desea guardar la configuración igual?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                result = True
            End If
        Finally
            sqlcon.Close()
        End Try
        Return result
    End Function

#End Region

End Class