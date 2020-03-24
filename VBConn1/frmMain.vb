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
        End If

    End Sub

    Private Sub BtnConexion_Click(sender As Object, e As EventArgs) Handles btnConexion.Click
        _configuracion.Generar()
    End Sub
End Class