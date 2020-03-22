Public Class frmMain
    Dim _conn As Conexion
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _conn = Conexion.getInstance

        If _conn.ExisteArchivoConfig = False Then
            _conn.Generar()
        Else
            _conn.Leer()
        End If

        If _conn.ExisteArchivoConfig = False Then
            lblConexion.Text = "No se generar la cadena de conexión a la base de datos."
        End If

    End Sub

    Private Sub BtnConexion_Click(sender As Object, e As EventArgs) Handles btnConexion.Click
        _conn.Generar()
    End Sub
End Class