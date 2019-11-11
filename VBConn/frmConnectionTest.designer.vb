<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnectionTest
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblConnection = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblConnection
        '
        Me.lblConnection.AutoSize = True
        Me.lblConnection.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnection.Location = New System.Drawing.Point(12, 9)
        Me.lblConnection.Name = "lblConnection"
        Me.lblConnection.Size = New System.Drawing.Size(314, 36)
        Me.lblConnection.TabIndex = 0
        Me.lblConnection.Text = "Successful connection"
        '
        'frmConnectionTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 51)
        Me.Controls.Add(Me.lblConnection)
        Me.Name = "frmConnectionTest"
        Me.Text = "Connection test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblConnection As Label
End Class
