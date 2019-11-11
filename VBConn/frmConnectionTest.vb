Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class frmConnectionTest

#Region "Global variables"
    'Connection object for global use
    Public Shared _connection As Connection
#End Region

#Region "Events"

    Private Sub frmConnectionTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _connection = _connection.getInstance()

        ' Load the connection string into the object
        _connection.Load()

        If _connection.ExistsConfigFile Then
            lblConnection.Text = "Successful connection"
        Else
            lblConnection.Text = "Unsuccessful connection "
        End If
    End Sub
#End Region

#Region "Methods"


#End Region

End Class
