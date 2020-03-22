<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lblConexion = New System.Windows.Forms.Label()
        Me.btnConexion = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblConexion
        '
        Me.lblConexion.AutoSize = True
        Me.lblConexion.Location = New System.Drawing.Point(12, 9)
        Me.lblConexion.Name = "lblConexion"
        Me.lblConexion.Size = New System.Drawing.Size(87, 13)
        Me.lblConexion.TabIndex = 0
        Me.lblConexion.Text = "Conexión exitosa"
        '
        'btnConexion
        '
        Me.btnConexion.Location = New System.Drawing.Point(12, 30)
        Me.btnConexion.Name = "btnConexion"
        Me.btnConexion.Size = New System.Drawing.Size(75, 23)
        Me.btnConexion.TabIndex = 1
        Me.btnConexion.Text = "Conexión"
        Me.btnConexion.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 65)
        Me.Controls.Add(Me.btnConexion)
        Me.Controls.Add(Me.lblConexion)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblConexion As Label
    Friend WithEvents btnConexion As Button
End Class
