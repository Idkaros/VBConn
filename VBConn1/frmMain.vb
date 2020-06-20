Public Class frmMain
    Dim _configuracion As Configuracion

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Se inicia el preceso para la generación del archivo de conexión.
        _configuracion = Configuracion.getInstance

        If _configuracion.ExisArchCone = False Then
            _configuracion.Generar()
        Else
            _configuracion.Leer()
        End If

        If _configuracion.ExisArchCone = False Then
            lblConexion.Text = "No hay archivo de conexión a la base de datos."
        Else
            Dim con As New Conexion(_configuracion.StringBuilder.ToString)
            lblConexion.Text = con.Probar()
        End If

    End Sub

    Private Sub btnConexion_Click(sender As Object, e As EventArgs) Handles btnConexion.Click
        Dim con As New Conexion(_configuracion.StringBuilder.ToString)
        lblConexion.Text = con.Probar()
    End Sub

End Class