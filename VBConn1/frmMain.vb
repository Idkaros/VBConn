Public Class frmMain
    Dim _configuracion As Configuracion

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Begin: Se inicia el preceso para la generación del archivo de conexión.
        'Se instancia la clase para la configuración
        _configuracion = Configuracion.getInstance

        'Si existe el archivo de conexión genera, sino lee
        If _configuracion.ExisArchCone = False Then
            _configuracion.Generar()
        Else
            _configuracion.Leer()
        End If

        'Si no existe el archivo de conexión da por fallida la conexión, sino
        'instancia la clase conexión y prueba la conexión.
        If _configuracion.ExisArchCone = False Then
            lblConexion.Text = "No hay archivo de conexión a la base de datos."
        Else
            Dim con As New Conexion(_configuracion.StringBuilder.ToString)
            lblConexion.Text = con.Probar()
        End If
        'End
    End Sub

    Private Sub btnConexion_Click(sender As Object, e As EventArgs) Handles btnConexion.Click
        Dim con As New Conexion(_configuracion.StringBuilder.ToString)
        lblConexion.Text = con.Probar()
    End Sub

End Class